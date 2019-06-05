/// <reference path="../../neoexplorer.web/wwwroot/helpers.js" />

describe("Squash", function() {
	it("should return empty array when called without arguments",
		function() {
			var result = squash();
			expect(result).toEqual([]);
		});

	it("Should squash the object", function () {
		var result = squash({
			prop1: ['a', 'b'],
			prop2: ['c', 'd']
		});
		expect(result).toEqual(['a', 'b', 'c', 'd']);
	});

	it("Should accept non-alphanumeric property names", function () {
		var result = squash({
			"2019-01-01": ['a', 'b'],
			"Not a valid identifier": ['c', 'd']
		});
		expect(result).toEqual(['a', 'b', 'c', 'd']);
	});
});
