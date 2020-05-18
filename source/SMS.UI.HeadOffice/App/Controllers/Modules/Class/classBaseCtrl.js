//(function (app) {
//    'use strict';

SMSHO.controller('classBaseCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.GetClasss = function () {
        $scope.loader(true);
        var responsedata = apiService.masterget('/api/v1/Class/Get');
        responsedata.then(function mySucces(response) {
            $scope.classList = response.data;
            $scope.loader(false);
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetClasss();
}]);

