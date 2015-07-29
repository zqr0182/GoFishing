var fishingApp = angular.module('fishingApp', ['ngRoute', 'ngResource'])
.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/Fishing/trip', { templateUrl: '/Appbuild/htmls/trip.html', controller: 'TripController' });
    $routeProvider.when('/Fishing/trophy', { templateUrl: '/Appbuild/htmls/trophy.html', controller: 'TrophyController' });
     
    $locationProvider.html5Mode(true);
}]);