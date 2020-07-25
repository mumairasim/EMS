SMSHO.controller('requestManagementCtrl', ['$scope', 'apiService', '$cookies', '$routeParams', function ($scope, apiService, $cookies, $routeParams) {
    'use strict';
    $scope.FetchRequests = function () {
        var url = '/api/v1/RequestManagement/GetAll';
        var responsedata = apiService.masterget(url);
        responsedata.then(function mySucces(response) {
                $scope.LessonPlanModel = response.data;
                $scope.LessonPlanModel.FromDate = new Date(response.data.FromDate);
                $scope.LessonPlanModel.ToDate = new Date(response.data.ToDate);

            },
            function myError(response) {
                $scope.response = response.data;
            });
    };
}]);