import Vue from "vue";
import { squash } from "./helpers.js";
import asteroidCardColumnsSlotComponent from "./components/asteroidCardColumnsSlotComponent.vue";
import selectedAsteroidComponent from "./components/selectedAsteroidComponent.vue";
import axios from "axios";

var vm = new Vue({
	el: "#app",
	components: {
		"asteroid-card-columns-slot": asteroidCardColumnsSlotComponent,
		"selected-asteroid": selectedAsteroidComponent
	},
	data: {
		fromDate: '2019-06-05',
		toDate: '2019-06-05',
		asteroids: [],
		selectedAsteroidName: "NONE"
	},
	methods: {
		fetchData: function (startDate, toDate) {
			var url = 'https://api.nasa.gov/neo/rest/v1/feed';
			var params = {
				start_date: startDate,
				end_date: toDate,
				api_key: 'nwujdlu5sEZnQOcXgSGWoebtdhIiZLwmIfiDW7yT'
			};

			axios.get(url, { params: params })
				.then(response => {
					vm.asteroids = squash(response.data.near_earth_objects);
				});
		},
		reloadGrid: function () {
			this.fetchData(this.fromDate, this.toDate);
		}
	},
	created: function () {
		this.reloadGrid();
	},
	mounted: function () {
		this.$on("asteroid-card-selected", function(name) {
			console.log('here + ' + name);
			vm.selectedAsteroidName = name;
		});
	}
});