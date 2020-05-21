SMSHO.controller('lessonPlanCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.LessonPlanModel = {
        Text: '',
        FromDate: '',
        ToDate: '',
        School: $scope.School
    };
    $scope.School = {
        Id: '',
        Name: '',
        Location: ''
    };
    
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            $scope.LessonPlanModel.School = $scope.Schools[0];
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.LessonPlanCreate = function () {
        var data = $scope.LessonPlanModel;
        var formData = new FormData();
        formData.append('lessonPlanModel', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/LessonPlan/Create', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Lesson Plan created successfully.", false);
            window.location = "#!/lessonPlanBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Lesson Plan creation failed", true);
            });
    };
    $scope.Cancel = function () {
        window.location = "#!/lessonPlanBase";
    };
    $scope.GetSchools();
    
}]);