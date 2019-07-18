describe("Page", function() {
	jasmine.DEFAULT_TIMEOUT_INTERVAL = 60000;
	var puppeteer, browser, page;

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
			await page.waitFor(200);
			expect(urls)
				.toContain(
					'https://api.nasa.gov/neo/rest/v1/feed?start_date=2019-01-01&end_date=2019-01-07&api_key=5dsCIxdak6Cfd5A3AsBW2jeo2Tic0717tEE7OYVX');
			await page.waitFor(2500);
		});

	it("should display readable error when date range exceed 7 days",
		async function () {
			await page.goto('http://localhost:5000');

			let message = null;
			page.once('dialog', async d => {
				message = d.message();
				await setTimeout(async () => { await d.dismiss(); }, 2500);
				//await d.dismiss();
			});

			await page.setRequestInterception(true);
			page.on('request', r => {
				if (!r.url().includes("api.nasa.gov")) {
					r.continue();
					return;
				}
				r.respond({
					status: 400,
					contentType: 'application/json;charset=UTF-8',
					body: '{"error_message": "Javascript is a mistake"}'
				});
			});

			await page.type("#fromDate", "01012010");
			await page.type("#toDate", "01012015");
			await page.click("button");
			await page.waitFor(2500);

			expect(message).toBeTruthy();
			expect(message).toContain('Javascript is a mistake');
		});

	it("Data are displayed in the grid",
		async function() {
			await page.setRequestInterception(true);
			page.on('request', r => {
				if (r.url().includes("api.nasa.gov")) {
					r.respond({
						status: 200,
						contentType: 'application/json;charset=UTF-8',
						body: testJson
					});
				} else {
					r.continue();
				}
			});

			await page.goto('http://localhost:5000');
			let data = await page.$$eval('table tr td', tds => tds.map(td => { return td.innerText }));
			expect(data).toEqual(['Big momma', 'Between 100 and 200 feet', 'No', 'Fat daddy', 'Between 500 and 1000 feet', 'No']);
			await page.waitFor(5000);
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