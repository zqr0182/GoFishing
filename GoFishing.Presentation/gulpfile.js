var gulp = require('gulp');

var changed = require('gulp-changed');
var minifyHTML = require('gulp-minify-html');
var concat = require('gulp-concat');
var autoprefix = require('gulp-autoprefixer');
var minifyCSS = require('gulp-minify-css');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');


gulp.task('minify-html', function () {
    var opts = { empty: true, quotes: true };
    var htmlPath = { htmlSrc: ['./App/templates/*.html'], htmlDest: './Appbuild/htmls/' };

    return gulp.src(htmlPath.htmlSrc)
        .pipe(changed(htmlPath.htmlDest))
        .pipe(minifyHTML(opts))
        .pipe(gulp.dest(htmlPath.htmlDest));
});


gulp.task('minify-css', function () {
    var cssPath = { cssSrc: ['./Content/*.css', '!*.min.css', '!/**/*min.css'], cssDest: './Appbuild/css/' };

    return gulp.src(cssPath.cssSrc)
        .pipe(concat('styles.css'))
        .pipe(autoprefix('last 2 versions'))
        .pipe(minifyCSS())
        .pipe(rename({ suffix: '.min'}))
        .pipe(gulp.dest(cssPath.cssDest));
});


gulp.task('bundle-scripts', function () {

    var jsPath = { jsSrc: ['./Scripts/jquery-1.9.1.min.js', './Scripts/angular.min.js', './Scripts/angular-resource.min.js', './Scripts/angular-route.min.js', './Scripts/bootstrap.min.js', './App/**/*.js'], jsDest: './Appbuild/js/' };
    gulp.src(jsPath.jsSrc)
        .pipe(concat('all.js'))
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(jsPath.jsDest));
});

gulp.task('watch', function() {

    gulp.watch('./App/templates/*.html', 'minify-html');
    gulp.watch(['./Content/*.css', '!*.min.css', '!/**/*min.css'], 'minify-css');
    gulp.watch(['./Scripts/jquery-1.9.1.min.js', './Scripts/angular.min.js', './Scripts/angular-resource.min.js', './Scripts/angular-route.min.js', './Scripts/bootstrap.min.js', './App/**/*.js'], 'bundle-scripts');
});


gulp.task('default', ['minify-html', 'minify-css', 'bundle-scripts', 'watch']);
 