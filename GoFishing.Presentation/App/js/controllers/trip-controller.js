fishingApp.controller("TripController", ['$scope', 'fishingService', function ($scope, fishingService) {

     $scope.tripParameters = {};
     $scope.tripParameters.type = 'GET';
    

    
    $scope.listAllTrips = function (tripParameters) {
        fishingService.listAllTrips(tripParameters).$promise.then(
            function (result) {
                $scope.bindResult(result);

          },
            function (error) {
                $scope.bindResult(error);;
            });
    };
    
    $scope.getTrip = function (tripParameters) {
        fishingService.getTrip(tripParameters).$promise.then(
            function (result) {
                $scope.bindResult(result);
            },
            function (error) {
                $scope.bindResult(error);;
            });
    };

    $scope.bindResult = function (result) {
        $scope.result = angular.toJson(result, true);
    };

}]);