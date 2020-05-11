//(function (app) {
//    'use strict';

SMSHO.controller('studentBaseCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.GetStudents = function () {
        $scope.loader(true);
        var responsedata = apiService.masterget('/api/v1/Student/Get');
        responsedata.then(function mySucces(response) {
            $scope.studentList = response.data;
            $scope.loader(false);
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetStudents();
}]);

