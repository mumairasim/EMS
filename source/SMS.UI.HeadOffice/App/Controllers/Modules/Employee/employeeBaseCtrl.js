//(function (app) {
//    'use strict';

SMSHO.controller('employeeBaseCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.GetEmployees = function () {
        $scope.loader(true);
        var responsedata = apiService.masterget('/api/v1/Employee/Get');
        responsedata.then(function mySucces(response) {
            $scope.employeeList = response.data;
            $scope.loader(false);
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetEmployees();
}]);

