const path = require("path");
const webpack = require("webpack");
const VueLoaderPlugin = require("vue-loader/lib/plugin");

module.exports = {
	entry: {
		'index': "./wwwroot/clientApp/index.js"
	},
	output: {
		filename: "[name].build.js",
		path: path.resolve(__dirname, "wwwroot/js/dist"),
		libraryTarget: "this"
	},
	module: {
		rules: [
			{
				test: /\.js$/,
				include: [
					path.resolve(__dirname, "wwwroot/clientApp")
				],
				exclude: /node_modules/
			},
			{
				test: /\.vue$/,
				loader: "vue-loader"
			},
			{ test: /\.css$/, use: ['vue-style-loader','css-loader']}
		]
	},
	plugins: [
		new VueLoaderPlugin()
	],
	resolve: {
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        },
        extensions: ['*', '.js', '.vue', '.json']
    }
};