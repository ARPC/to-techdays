function squash(obj) {
	let result = [];

	if (typeof obj !== 'undefined') {
		for (const p in obj) {
			if (obj.hasOwnProperty(p)) {
				result = result.concat(obj[p]);
			}
		}
	}

	return result;
}

export {squash};