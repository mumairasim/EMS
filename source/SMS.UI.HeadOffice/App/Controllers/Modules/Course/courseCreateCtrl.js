﻿SMSHO.controller('courseCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.CourseModel = {
        CourseName: '',
        CourseCode: ''
    };

    $scope.CourseCreate = function () {

        var data = $scope.CourseModel;
        var formData = new FormData();
        formData.append('courseModel', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/Course/Create', formData);
        responsedata.then(function mySucces(response) {

            $scope.response = response.data;
            $scope.growltext("Course created successfully.", false);
            window.location = "#!/courseBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Course creation failed", true);
            });
    };
    $scope.Cancel = function () {
        window.location = "#!/courseBase";
    };

}]);