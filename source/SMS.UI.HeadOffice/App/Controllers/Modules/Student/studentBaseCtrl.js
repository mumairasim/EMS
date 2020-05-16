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
    $scope.ConfirmDelete = function (id) {
        $scope.StudentToDelete = id;
    };
    $scope.NoDelete = function () {
        $scope.StudentToDelete = 0;
    };
    $scope.StudentDelete = function () {
        var url = '/api/v1/Student/Delete?id=' + $scope.StudentToDelete;
        var responsedata = apiService.masterdelete(url);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Student deleted successfully.", false);
            window.location.reload();
            $scope.StudentToDelete = 0;
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Student deletion failed", true);
                $scope.StudentToDelete = 0;
            });
    };
    $scope.GetStudents();
}]);

