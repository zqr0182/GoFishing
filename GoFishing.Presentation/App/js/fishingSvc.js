fishingApp.factory('fishingService', ['$resource', function ($resource) {
    return {
        
        listAllTrips: function (tripParameters) {
            return invoke($resource, tripParameters, 'ListAllTrips');
        },
        getTrip: function (tripParameters) {
            return invoke($resource, tripParameters, 'TripDetail');
        }
    };
}]);
var invoke = function ($resource, parameters, action) {

    var resource = $resource('/api/GoFishingAPI/' + action);
    return parameters.type == 'GET' ? resource.get(parameters) : resource.save(parameters);
};
