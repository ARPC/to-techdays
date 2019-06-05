function squash(obj) {
	var result = [];
	if (obj != undefined) {
		for (p in obj) {
			if (obj.hasOwnProperty(p)) {
				result = result.concat(obj[p]);
			}
		}
	}
	return result;
}