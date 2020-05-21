SMSHO.controller('lessonPlanUpdateCtrl', ['$scope', 'apiService', '$cookies', '$routeParams', function ($scope, apiService, $cookies, $routeParams) {
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
            $scope.FetchLessonPlan();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.LessonPlanUpdate = function () {
        var data = $scope.LessonPlanModel;
        var formData = new FormData();
        formData.append('lessonPlanModel', JSON.stringify(data));
        var responsedata = apiService.masterput('/api/v1/LessonPlan/Update', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Lesson Plan updated successfully.", false);
            window.location = "#!/lessonPlanBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Lesson Plan updation failed", true);
            });
    };
    $scope.FetchLessonPlan = function () {
        var id = $routeParams.Id;
        var url = '/api/v1/LessonPlan/Get?id=' + id;
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
    $scope.Cancel = function () {
        window.location = "#!/lessonPlanBase";
    };
    $scope.GetSchools();
}]);