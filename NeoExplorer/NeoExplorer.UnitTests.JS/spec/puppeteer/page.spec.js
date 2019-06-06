const puppeteer = require('puppeteer');

jasmine.DEFAULT_TIMEOUT_INTERVAL = 25000;

const puppeteerLaunchArgs = {
	headless: false,
	slowMo: 250
};

describe("Page", function () {

	let browser, page;

	beforeEach(async () => {
		browser = await puppeteer.launch(puppeteerLaunchArgs);
		page = await browser.newPage();
	});

	afterEach(async () => {
		await browser.close();
	});

	it('should be titled NEO explorer',
		async () => {
			await page.goto('http://localhost:5000');
			expect(await page.title()).toEqual('NEO explorer');
		});

	it('should call NASA API when Go button is clicked',
		async () => {
			await page.goto('http://localhost:5000');

			var urls = startRequestLogging(page);
			await enterStartAndEndDateAndClickGo('01012019', '01072019');

			expect(urls)
				.toContain(
					'https://api.nasa.gov/neo/rest/v1/feed?start_date=2019-01-01&end_date=2019-01-07&api_key=DEMO_KEY');
		});

	async function enterStartAndEndDateAndClickGo(startDate, endDate) {
		var fromDate = await page.$("#fromDate");
		await fromDate.type(startDate);

		var toDate = await page.$("#toDate");
		await toDate.type(endDate);

		var goButton = await page.$('button');
		await goButton.click();
	}

	function startRequestLogging(page) {
		var array = [];
		page.on('request', request => { array.push(request.url()); });
		return array;
	}
});