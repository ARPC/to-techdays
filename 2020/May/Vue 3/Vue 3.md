# Motivation
* **Logic reuse and code organization**
	* small-medium scale applications
	* large scale applications need iterations and maintenance over a longer timeframe by a team of multiple developers; so needs to be readable and clean. 	Current problems:
        * Complex components become harder to reason as features grow over time i.e code readability suffers since code is organized by options. In some cases it makes more sense to organize code logically
        * Organize code as function which make it more straightforward to extract and reuse logic between components or outside components.
* **Better type inference**
	* Better typescript support for large projects
	* Vue 2 API currently does not play well with TypeScript, mostly because Vue relies heavily on `this` context
	
# Result
* Faster
	* Proxy-based Observation
		* doubles the speed and uses half the memory
    * Virtual DOM Rewrite
	* Optimized Slots Generation - parent and child can be rendered independently
	* Static Tree Hoisting - skip patching entire trees
	* Static Props Hoisting - skip patching nodes that aren’t going to change
* Smaller
	* 20kb -> 10kb (gzipped)
	* only import functions that are needed as most of the internals are now exported which helps to reduce size
	* compiler also generates tree shakeable code. Treeshaking example
    ```import Vue from 'vue'
    Vue.nextTick(() => {})
    // instead will be
	import Vue, {nextTick} from 'vue'
    nextTick(() => {});```
* Have more maintainable source code
    * typescript
    * decoupled packages -> modular
		Expose Vue's core capability by exporting them as modules - creating and observing reactive state as standalone function
* More native-friendly
* Easier to use


# Features
* Composition Api
	* Vue 3 adds a set of APIs, referred to as the Composition API, which is function-based.
	* Function-based way of writing component inspired by React Hooks - encapsulate logic into composition function and resuse it across components.
	* This is primarily to address two issues that Vue 2 ran into for very large projects.
		1. In large components that encapsulate multiple logical tasks, you want to group code by feature, but the nature of the Options API is that such code gets split up (among lifecycle hooks and so on), negatively affecting readability. 
		2. Secondly, you want to be able to reuse logic in large-scale projects, and in Vue 2, solutions like mixins don’t address either issue very well.
	* This means that you can go on building components in the way that you’re used to without encountering any problems. But, you can also start building with the Composition API, which provides more flexible code organization and logic reuse capabilities as well as other improvements.
	* @vue/composition-api for Vue 2. It will be shipped baked-in in Vue 3.

* Reactive data
	```
    const vm = new Vue({
			el: '#app',
			data() {
				return {
					a: 'a'
					books: ['book1', 'book2']
				}
			},
			created() {
				this.b = 'c' // this will not be reactive since the root object cannot be updated. vm.b will return 'c' though.
			}
		})
	```
	updating using array index does not work
	```	
	vm.books[0] = 'book1 (new)'  //Vue.Set can be used to update instead
	```	
	no more with Vue 3 (because of es6 features that was used)
	```this.books[0] = newRelease  // setting array by index
	this.obj[newKey] = value   // adding a new property to an object
	delete this.obj[newKey]  // deleting a property from an object
	```
* You don't need Vue instance to use the new reactivity API since it uses proxies (ES6).
	```
	import {reactive} from 'vue'
	const state = reactive({count: 0})
	```
	
* Global mounting/configuration Api
	```
	import Vue from 'vue'
	import App from './App.vue'
	Vue.component(.....)
	new Vue({
		render: h =h(App)
	}).$mount('#app');
	```
	will be
	```
	import {createApp} from 'vue'
	import App from './App.vue'
	const app = createApp(App);
	app.component(.....)
	app.mount('#app')
	```
	
* Mapping between 2.x Lifecycle Options and Composition API
	```
	beforeCreate -> use setup()
	created -> use setup()
	beforeMount -> onBeforeMount
	mounted -> onMounted
	beforeUpdate -> onBeforeUpdate
	updated -> onUpdated
	beforeDestroy -> onBeforeUnmount
	destroyed -> onUnmounted
	errorCaptured -> onErrorCaptured
	```
* TypeScript
	* Offers better support for TypeScript.
	* Better type inference with bindings returned form setup() and props declarations
* Fragments
	* multiple root nodes
	```
		<template>
			<div>root 1</div>
			<div>root 2</div>
		</template>
	```
	* can use vue-fragments package in Vue 2
* Suspense
    ```
	<Suspense>
	  <template >
		<Suspended-component />
	  </template>
	  <template #fallback>
		Loading...
	  </template>
	</Suspense>
	```
* Multiple `v-models`
* Portal
	* modals, popups
	* can use portal-vue in Vue 2
	```
		<portal to="destination">
		  <p>This slot content will be rendered wherever thportal-target with name 'destination'
			is  located.</p>
		</portal>
		<portal-target name="destination">
		  <!--
		  This component can be located anywhere in your App.
		  The slot content of the above portal component wilbe rendered here.
		  -->
		</portal-target>
	```
* New custom directive Api
* View declaration is same in Vue2 and Vue3
	diff algorithms have speedup and can decide what needs to be re-rendered quicker
* IE 11 compatibility in future release
	
	
	
	
	