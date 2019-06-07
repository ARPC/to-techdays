describe("Page", function () {
	jasmine.DEFAULT_TIMEOUT_INTERVAL = 60000;
	const debug = {
		headless: false,
		slowMo: 250
	};

	it("NASA API is called when Go button is clicked [Promise version]",
		function (done) {
			var urls;
			var puppeteer = require('puppeteer');
			var page;
			puppeteer.launch(debug)
				.then((browser) => {
					return browser.newPage();
				}).then((p) => {
					page = p;
					return p.goto('http://localhost:5000');
				}).then(() => {
					urls = startRequestLogging(page);
					return page.type("#fromDate", "01012019");
				}).then(() => {
					return page.type("#toDate", "01072019");
				}).then(() => {
					return page.click("button");
				}).then(() => {
					expect(urls)
						.toContain(
						'https://api.nasa.gov/neo/rest/v1/feed?start_date=2019-01-01&end_date=2019-01-07&api_key=5dsCIxdak6Cfd5A3AsBW2jeo2Tic0717tEE7OYVX');
					done();
				}).catch((error) => { console.log(error); });
		});

	function startRequestLogging(page) {
		var array = [];
		page.on('request', (request) => { array.push(request.url()); });
		return array;
	}
});