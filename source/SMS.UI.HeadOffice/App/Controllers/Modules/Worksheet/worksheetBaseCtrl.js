//(function (app) {
//    'use strict';

SMSHO.controller('worksheetBaseCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.GetWorksheets = function () {
        var responsedata = apiService.masterget('/api/v1/Worksheet/GetAll');
        responsedata.then(function mySucces(response) {
            $scope.worksheetList = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });

    };
    $scope.WorksheetDelete = function () {
        var url = '/api/v1/Worksheet/Delete?id=' + $scope.WorksheetToDelete;
        var responsedata = apiService.masterdelete(url);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Worksheet deleted successfully.", false);
            window.location.reload();
            $scope.WorksheetToDelete = 0;
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Worksheet deletion failed", true);
                $scope.WorksheetToDelete = 0;
            });
    };

    $scope.ConfirmDelete = function (id) {
        $scope.WorksheetToDelete = id;
    };

    $scope.GetWorksheets();
}]);

