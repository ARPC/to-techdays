describe("Page",
	function() {
		var puppeteer, browser, page;
		jasmine.DEFAULT_TIMEOUT_INTERVAL = 60000;
		const debug = {
			headless: false,
			slowMo: 120
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
			async function() {
				await page.goto('http://localhost:5000');
				expect(await page.title()).toBe("Asteroid Explorer");
				await page.waitFor(2000);
			});

		it("NASA API is called when Go button is clicked",
			async function() {
				await page.goto('http://localhost:5000');
				var urls = startRequestLogging(page);
				await page.type("#fromDate", "01012019");
				await page.type("#toDate", "01072019");
				await page.click("button");
				expect(urls)
					.toContain(
						'https://api.nasa.gov/neo/rest/v1/feed?start_date=2019-01-01&end_date=2019-01-07&api_key=5dsCIxdak6Cfd5A3AsBW2jeo2Tic0717tEE7OYVX');
				await page.waitFor(2000);
			});

		it('report the error correctly when date range exceed 8 days',
			async function() {
				await page.goto('http://localhost:5000');

				let message = null;
				page.once('dialog',
					async dialog => {
						message = dialog.message();
						await dialog.dismiss();
//					setTimeout(() => { dialog.dismiss(); }, 2500);
					});

				await page.type("#fromDate", "01012019");
				await page.type("#toDate", "01092019");
				await page.click("button");
				await page.waitForResponse(response => response.url().includes('nasa'));

				expect(message)
					.toBe(
						'Web service call failed with the following error: Date Format Exception - Expected format (yyyy-mm-dd) - The Feed date limit is only 7 Days.');
				await page.waitFor(2000);
			});

		it('displays data that we provide',
			async function () {
				await page.goto('http://localhost:5000');

				await page.setRequestInterception(true);
				page.on('request',
					async request => {
						if (!request.url().includes('nasa.gov')) {
							await request.continue();
						}

						await request.respond({
							status: 200,
							contentType: 'application/json;charset=UTF-8',
							body: testJson
						});
					});

				await page.type("#fromDate", "01012019");
				await page.type("#toDate", "01022019");
				await page.click("button");

				const tds = await page.$$eval('table tr td', tds => tds.map(td => td.innerText));

				expect(tds).toEqual(['Big momma', 'Between 100 and 200 feet', 'No', 'Fat daddy', 'Between 500 and 1000 feet', 'No']);
			});

	function startRequestLogging(page) {
		var array = [];
		page.on('request', (request) => { array.push(request.url()); });
		return array;
		}

	const testJson = `{  
"element_count":2,
"near_earth_objects":{  
  "2019-01-01":[  
	 {  
		"name":"Big momma",
		"estimated_diameter":{  
		   "feet":{  
			  "estimated_diameter_min":100,
			  "estimated_diameter_max":200
		   }
		},
		"is_potentially_hazardous_asteroid":false
	 },
	 {  
		"name":"Fat daddy",
		"estimated_diameter":{  
		   "feet":{  
			  "estimated_diameter_min":500,
			  "estimated_diameter_max":1000
		   }
		},
		"is_potentially_hazardous_asteroid":false
	 }]
}
}`;

});