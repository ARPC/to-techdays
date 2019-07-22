<template>
	<div>		
		<div class="card-columns">
			<asteroid-card-slot v-for="asteroid in asteroids"
						   :name="asteroid.name"
						   :estimated-diameter-in-feet="asteroid.estimated_diameter.feet"
						   :is-potentially-hazardous="asteroid.is_potentially_hazardous_asteroid"
						   :nasa-url="asteroid.nasa_jpl_url"
						   @asteroid-card-selected="asteroidCardSelectedHandler"
						   :selected-name="selectedAsteroidName"
						   :key="asteroid.id">
				<template v-slot:header="headerData">
					<h5 class="card-title" :class="{'text-danger': headerData.isPotentiallyHazardous}">Name: {{headerData.asteroidName}}</h5>
				</template>
				<template v-slot:content="contentData">
					<p class="card-text" :class="{'text-danger':contentData.isPotentiallyHazardous}">Between {{contentData.estimatedDiameter.min}} and {{contentData.estimatedDiameter.max}} feet</p>
					<a :href="contentData.nasaUrl" class="card-link">More info...</a>
				</template>
			</asteroid-card-slot>
		</div>
	</div>
</template>
<script>
	import asteroidCardSlotComponent from "./asteroidCardSlotComponent.vue";
	export default {
		components: {
			'asteroid-card-slot': asteroidCardSlotComponent
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