SMSHO.controller('studentDiaryCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.StudentDiaryDiaryModel = {
        Diarytext: '',
        DairyDate: '',
    };
    $scope.StudentDiaryCreate = function () {
        var data = $scope.StudentDiaryModel;
        var formData = new FormData();
        formData.append('studentDiaryModel', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/StudentDiary/Create', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("StudentDiary created successfully.", false);
            window.location = "#!/studentDiaryBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("StudentDiary creation failed", true);
            });
    };
    $scope.Cancel = function () {
        window.location = "#!/studentDiaryBase";
    };
}]);