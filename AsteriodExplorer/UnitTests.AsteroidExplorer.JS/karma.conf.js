// Karma configuration
// Generated on Fri Jun 07 2019 14:38:36 GMT-0400 (Eastern Daylight Time)
const VueLoaderPlugin = require("vue-loader/lib/plugin");

module.exports = function(config) {
  config.set({

    // base path that will be used to resolve all patterns (eg. files, exclude)
    basePath: '',


    // frameworks to use
    // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
    frameworks: ['jasmine'],


    // list of files / patterns to load in the browser
    files: [
	    '../AsteriodExplorer/wwwroot/helpers.js',
    		'spec/**/*[Ss]pec.js'
    ],


    // list of files / patterns to exclude
    exclude: [
    ],


	  // preprocess matching files before serving them to the browser
    // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
    preprocessors: {
	    // add webpack as preprocessor
	    '../AsteriodExplorer/wwwroot/clientApp/**/*.js': ['webpack'],
	    'spec/**/*[sS]pec.js': ['webpack']
    },
    webpack: {
	    // you don't need to specify the entry option because
	    // karma watches the test entry points
	    // webpack watches dependencies
	    mode: "development",
	    module: {
		    rules: [
			    {
				    test: /\.vue$/,
				    loader: "vue-loader"
				},
			    { test: /\.css$/, use: ['vue-style-loader', 'css-loader'] }
		    ]
	    },
	    plugins: [
		    new VueLoaderPlugin()
	    ]
	    // ... remainder of webpack configuration (or import)
    },
    webpackMiddleware: {
	    // webpack-dev-middleware configuration
	    // i.e.
	    noInfo: true,
	    // and use stats to turn off verbose output
	    stats: "errors-only"
    },


    // test results reporter to use
    // possible values: 'dots', 'progress'
    // available reporters: https://npmjs.org/browse/keyword/karma-reporter
    reporters: ['progress'],


    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: true,


    // start these browsers
    // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
    browsers: ['Chrome', 'Firefox', 'IE'],


    // Continuous Integration mode
    // if true, Karma captures browsers, runs the tests and exits
    singleRun: false,

    // Concurrency level
    // how many browser should be started simultaneous
    concurrency: Infinity
  })
}
