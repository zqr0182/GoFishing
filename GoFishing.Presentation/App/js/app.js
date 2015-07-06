var fishingApp = angular.module('fishingApp', ['ngRoute', 'ngResource'])
.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/Fishing/trip', { templateUrl: '/app/templates/trip.html', controller: 'TripController' });
    $routeProvider.when('/Fishing/trophy', { templateUrl: '/app/templates/trophy.html', controller: 'TrophyController' });
     
    $locationProvider.html5Mode(true);
}]);