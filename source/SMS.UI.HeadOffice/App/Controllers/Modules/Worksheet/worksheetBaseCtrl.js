//(function (app) {
//    'use strict';

SMSHO.controller('worksheetBaseCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.GetWorksheets = function () {
        $scope.loader(true);
        var responsedata = apiService.masterget('/api/v1/Worksheet/GetAll');
        responsedata.then(function mySucces(response) {
            $scope.worksheetList = response.data;
            $scope.loader(false);
        },
            function myError(response) {
                $scope.loader(false);
                $scope.response = response.data;
            });
    };
    $scope.GetWorksheets();
}]);

