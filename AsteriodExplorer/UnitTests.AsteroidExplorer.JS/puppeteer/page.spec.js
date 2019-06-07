describe("Page", function () {
	var puppeteer, browser, page;
	jasmine.DEFAULT_TIMEOUT_INTERVAL = 60000;
	const debug = {
		headless: false,
		slowMo: 250
	};

	beforeAll(async function() {
			puppeteer = require('puppeteer');
		}
	);

	beforeEach(async function() {
		browser = await puppeteer.launch(debug);
		page = await browser.newPage();
	});

	afterEach(async function() {
		await browser.close();
	});

	it("is titled Asteroid Explorer",
		async function () {
			await page.goto('http://localhost:5000');
			expect(await page.title()).toBe("Asteroid Explorer");
			await page.waitFor(2000);
		});

	it("NASA API is called when Go button is clicked",
		async function () {
			await page.goto('http://localhost:5000');
			var urls = startRequestLogging(page);
			await page.type("#fromDate", "01012019");
			await page.type("#toDate", "01072019");
			await page.click("button");
			await page.waitFor(200);
			expect(urls)
				.toContain(
					'https://api.nasa.gov/neo/rest/v1/feed?start_date=2019-01-01&end_date=2019-01-07&api_key=5dsCIxdak6Cfd5A3AsBW2jeo2Tic0717tEE7OYVX');
			await page.waitFor(2000);
		});

	function startRequestLogging(page) {
		var array = [];
		page.on('request', (request) => { array.push(request.url()); });
		return array;
	}
});