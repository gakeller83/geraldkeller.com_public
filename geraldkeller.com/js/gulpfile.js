var gulp = require('gulp');
var babelify = require('babelify');
var browserify = require('browserify');
var minify = require('gulp-minify');
var uglify = require('gulp-uglify');
var envify = require('envify');
var source = require('vinyl-source-stream');
var buffer = require('vinyl-buffer');
var bundlecollapser = require('bundle-collapser/plugin');
var uglifyify = require('uglifyify');
var gutil = require('gulp-util');
 
// Lets bring es6 to es5 with this.
// Babel - converts ES6 code to ES5 - however it doesn't handle imports.
// Browserify - crawls your code for dependencies and packages them up 
// into one file. can have plugins.
// Babelify - a babel plugin for browserify, to make browserify 
// handle es6 including imports.
gulp.task('build-dev', function() {
	browserify({
    	entries: './app.js',
    	debug: true
  	})
    .transform('babelify',{presets: ['react','es2015','stage-0']})
    .on('error',gutil.log)
    .bundle()
    .on('error',gutil.log)
    .pipe(source('bundle.js'))
    .pipe(gulp.dest(''));
});

gulp.task('build-prod', function() {
	browserify({
    	entries: './app.js',
    	debug: false,
      transform: 
        [['babelify', {presets: ['react', 'es2015', 'stage-0']}],
        [envify, {global: true, NODE_ENV: 'production'}],
        [uglifyify, {global: true}]],
      plugin:
        [bundlecollapser]
  	})
    .on('error',gutil.log)
    .bundle()
    .on('error',gutil.log)
    .pipe(source('bundle.js'))
    .on('error',gutil.log)
    .pipe(buffer())
    .on('error',gutil.log)
    .pipe(minify())
    .on('error',gutil.log)
    .pipe(uglify())
    .on('error',gutil.log)
    .pipe(gulp.dest(''));
});
 
gulp.task('watch',function() {
	gulp.watch('**/*.js',['build-dev'])
});
 
gulp.task('default', ['watch']);