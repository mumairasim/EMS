//(function (app) {
//    'use strict';

SMSHO.controller('studentFinanceBaseCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.GetStudentFinances = function () {
        var responsedata = apiService.masterget('/api/v1/StudentFinance/GetAll');
        responsedata.then(function mySucces(response) {
            $scope.studentFinanceList = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });

    };
    $scope.StudentFinanceDelete = function () {
        var url = '/api/v1/StudentFinance/Delete?id=' + $scope.StudentFinanceToDelete;
        var responsedata = apiService.masterdelete(url);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("StudentFinance deleted successfully.", false);
            window.location.reload();
            $scope.StudentFinanceToDelete = 0;
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("StudentFinance deletion failed", true);
                $scope.StudentFinanceToDelete = 0;
            });
    };

    $scope.ConfirmDelete = function (id) {
        $scope.StudentFinanceToDelete = id;
    };

    $scope.GetStudentFinances();
}]);

