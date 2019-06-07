function squash(obj) {
	var result = [];

	if (typeof obj !== 'undefined') {
//		result = Object.values(obj).flatMap(item => item);
		for (p in obj) {
			if (obj.hasOwnProperty(p)) {
				result = result.concat(obj[p]);
			}
		}
	}

	return result;
}