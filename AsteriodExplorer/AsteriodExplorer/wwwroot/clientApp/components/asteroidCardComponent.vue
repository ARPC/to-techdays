<template>
	<div class="card card-shadow" :class="{'border-danger':isPotentiallyHazardous, 'selected':isSelected }" @click="selected">
		<div class="card-body">
			<h5 class="card-title" :class="{'text-danger':isPotentiallyHazardous}">{{name}}</h5>
			<p class="card-text" :class="{'text-danger':isPotentiallyHazardous}">Between {{Math.round(estimatedDiameterInFeet.estimated_diameter_min)}} and {{Math.round(estimatedDiameterInFeet.estimated_diameter_max)}} feet</p>
			<a :href="nasaUrl" class="card-link">More info...</a>
		</div>
	</div>
</template>
<script>
	export default {
		props: {
			name: { type: String, required: true },
			estimatedDiameterInFeet: { type: Object },
			isPotentiallyHazardous: { type: Boolean },
			nasaUrl: { type: String },
			selectedName: {type: String}
		},
		computed: {
			isSelected: function (){
				return this.name === this.selectedName;
			}
		},
		methods: {
			selected: function () {
				this.$root.$emit("asteroid-card-selected", this.name);
				this.$emit("asteroid-card-selected", this.name);
			}
		}
	}
</script>
<style>
	.selected{
		background-color: lightblue;
	}
	.card-shadow {
		box-shadow: 1px 1px 4px 2px #eee;
	}
</style>