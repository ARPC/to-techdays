import { mount } from "@vue/test-utils";
import selectedAsteroidComponent from "../../AsteriodExplorer/wwwroot/clientApp/components/selectedAsteroidComponent.vue";

describe("The selectedAsteroidComponent", function () {
	it("should render selected asteroid name",
		() => {
			const props = {
				selectedAsteroidName: "AsteroidOnSteroid"
			};
			const wrapper = mount(selectedAsteroidComponent, { propsData: props });

			expect(wrapper.html()).toContain("AsteroidOnSteroid");
		});
});