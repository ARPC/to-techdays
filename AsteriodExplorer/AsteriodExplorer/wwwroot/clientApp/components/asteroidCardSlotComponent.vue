<template>
	<div class="card card-shadow" :class="{'border-danger':isPotentiallyHazardous, 'selected':isSelected }" @click="selected">
		<div class="card-body">
			<slot name="header" :asteroid-name="name" :is-potentially-hazardous="isPotentiallyHazardous">{{name}}</slot>
			<slot name="content" :is-potentially-hazardous="isPotentiallyHazardous" :estimated-diameter="estimatedDiameter" :nasa-url="nasaUrl"></slot>
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
			},
			estimatedDiameter: function () {
				return {
					min: Math.round(this.estimatedDiameterInFeet.estimated_diameter_min),
					max: Math.round(this.estimatedDiameterInFeet.estimated_diameter_max)
				};
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