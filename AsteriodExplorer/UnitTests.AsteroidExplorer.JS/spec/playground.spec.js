describe("1 + 1 expression", function() {
	it("should equal to 2",
		function() {
			expect(1 + 1).toBe(2);
		});

	it('should not equal to 3', function() {
		expect(1 + 1).not.toBe(3);
	});
})