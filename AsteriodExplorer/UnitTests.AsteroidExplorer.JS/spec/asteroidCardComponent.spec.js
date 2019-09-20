import { shallowMount, mount, createWrapper } from "@vue/test-utils";
import asteroidCardComponent from "../../AsteriodExplorer/wwwroot/clientApp/components/asteroidCardComponent.vue"
import asteroidCardsComponent from "../../AsteriodExplorer/wwwroot/clientApp/components/asteroidCardsComponent.vue"

fdescribe("asteroidCardComponent", () => {
	it("should emit event on selection",
		() => {
			const prop = {
				name: "test asteroid",
				estimatedDiameterInFeet: {
					estimated_diameter_min: 1000,
					estimated_diameter_max: 10000
				}
			};
			const wrapper = mount(asteroidCardComponent, { propsData: prop });

			const parentWrapper = createWrapper(wrapper.vm.$parent);
			wrapper.trigger('click');

			expect(parentWrapper.emitted('asteroid-card-selected')).toBeTruthy();
		});
	it("should set card header", () => {
		const prop = {
			name: "this asteroid has a head",
			estimatedDiameterInFeet: {
				estimated_diameter_min: 1000,
				estimated_diameter_max: 10000
			}
		};
		const wrapper = mount(asteroidCardComponent, { propsData: prop });

		expect(wrapper.html()).toContain("this asteroid has a head");
	});
});