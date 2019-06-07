/// <reference path="../../asteriodexplorer/wwwroot/helpers.js" />

describe("squash function", function() {
	it("should return empty array when called without arguments",
		function() {
			var result = squash();
			expect(result).toEqual([]);
		});

	it("should squash the object into a single array",
		function () {
			var result = squash({
				prop1: ['a', 'b'],
				prop2: ['c', 'd']
			});
			expect(result).toEqual(['a', 'b', 'c', 'd']);
		});

	it("should accept property names that are not valid identifiers",
		function () {
			var result = squash({
				'2020-01-01': ['a', 'b'],
				'This is certainly, not @ valid identifier#': ['c', 'd']
			});
			expect(result).toEqual(['a', 'b', 'c', 'd']);
		});
});