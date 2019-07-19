<template>
	<div>		
		<div class="card-columns">
			<asteroid-card v-for="asteroid in asteroids"
						   :name="asteroid.name"
						   :estimated-diameter-in-feet="asteroid.estimated_diameter.feet"
						   :is-potentially-hazardous="asteroid.is_potentially_hazardous_asteroid"
						   :nasa-url="asteroid.nasa_jpl_url"
						   @asteroid-card-selected="asteroidCardSelectedHandler"
						   :selected-name="selectedAsteroidName"
						   :key="asteroid.id">
			</asteroid-card>
		</div>
	</div>
</template>
<script>
	import asteroidCardComponent from "./asteroidCardComponent.vue";
	export default {
		components: {
			'asteroid-card': asteroidCardComponent
		},
		props: {
			asteroids: { type: Array, required: true }
		},
		data: function () {
			return {
				selectedAsteroidName: "NONE"
			};
		},
		methods: {
			asteroidCardSelectedHandler: function (name) {
				this.selectedAsteroidName = name;
				console.log(name);
			}
		}
	}
</script>