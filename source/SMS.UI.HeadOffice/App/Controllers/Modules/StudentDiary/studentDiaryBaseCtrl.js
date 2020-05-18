//(function (app) {
//    'use strict';

SMSHO.controller('studentDiaryBaseCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.GetStudentDiarys = function () {
        $scope.loader(true);
        var responsedata = apiService.masterget('/api/v1/StudentDiary/Get');
        responsedata.then(function mySucces(response) {
            $scope.studentDiaryList = response.data;
            $scope.loader(false);
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetStudentDiarys();
}]);

