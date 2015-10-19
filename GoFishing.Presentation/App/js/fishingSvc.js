fishingApp.factory('fishingService', ['$resource', function ($resource) {
    return {
        
        listAllTrips: function (tripParameters) {

            var resource = $resource('/api/GoFishingAPI/' + 'ListAllTrips', {},
                {
                  query: {
                           method: 'Get',
                           isArray: true
                         }
                
                });

            return resource.query(tripParameters);
        },
        getTrip: function (tripParameters) {
            return invoke($resource, tripParameters, 'TripDetail'); 
        },
        addTrip: function (tripParameters) {
            
            return invoke($resource, tripParameters, 'AddTrip'); 
        },
    };
}]);
var invoke = function ($resource, parameters, action) {

    var resource = $resource('/api/GoFishingAPI/' + action);
    return parameters.type == 'GET' ? resource.get(parameters) : resource.save(parameters);
};
