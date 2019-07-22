<template>
	<h6>
		<slot>Current selected asteroid:</slot>
		<span class="badge badge-secondary">{{selectedAsteroidName}}</span>
	</h6>
</template>
<script>
	export default {
		props: {
			selectedAsteroidName: { type: String }
		}
	}
</script>