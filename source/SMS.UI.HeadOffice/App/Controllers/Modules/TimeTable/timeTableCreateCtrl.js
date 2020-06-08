SMSHO.controller('timeTableCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.GetClasses = function() {
        var responsedata = apiService.masterget('/api/v1/Class/GetBySchool?schoolId=' + $scope.School.Id);
        responsedata.then(function mySucces(response) {
                $scope.Classes = response.data;
                $scope.Class = $scope.Classes[0];
            },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools = function() {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
                $scope.Schools = response.data;
                $scope.School = $scope.Schools[0];
                $scope.GetClasses();
            },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools();
}]);