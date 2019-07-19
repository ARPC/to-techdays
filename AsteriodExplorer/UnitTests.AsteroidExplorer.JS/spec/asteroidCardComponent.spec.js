import { mount } from "@vue/test-utils";
import asteroidCardComponent from "../../AsteriodExplorer/wwwroot/clientApp/components/asteroidCardComponent.vue";

fdescribe("The asteroidCardComponent", function () {
	it("should emit custom event on click",
		() => {
			const props = {
				name: "AsteroidOnSteroid",
				estimatedDiameterInFeet: { estimated_diameter_min: 0, estimated_diameter_max: 100 }
			};
			const wrapper = mount(asteroidCardComponent, { propsData: props });

			wrapper.trigger("click");

			expect(wrapper.emitted().asteroidCardSelected).toBeTruthy();
		});
});