SMSHO.controller('teacherDiaryUpdateCtrl', ['$scope', 'apiService', '$cookies', '$routeParams', function ($scope, apiService, $cookies, $routeParams) {
    'use strict';
    $scope.TeacherDiaryModel = {
        Name: '',
        DairyText: '',
        DairyDate: '',
        School: $scope.School,
        Employee: $scope.Employee
    };
    $scope.Employee = {
        Name: ''
    };
    $scope.School = {
        Id: '',
        Name: '',
        Location: ''
    };

    $scope.GetEmployeeByDesignation = function () {
        var responsedata = apiService.masterget('/api/v1/Employee/GetDesignationTeacher');
        responsedata.then(function mySucces(response) {
            $scope.Employees = response.data;
            $scope.FetchTeacherDiary();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            $scope.GetEmployeeByDesignation();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };

    $scope.TeacherDiaryUpdate = function () {
        var data = $scope.TeacherDiaryModel;
        var formData = new FormData();
        formData.append('teacherDiaryModel', JSON.stringify(data));
        var responsedata = apiService.masterput('/api/v1/TeacherDiary/Update', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Teacher Diary updated successfully.", false);
            window.location = "#!/teacherDiaryBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Teacher Diary updation failed", true);
            });
    };
    $scope.FetchTeacherDiary = function () {
        var id = $routeParams.Id;
        var url = '/api/v1/TeacherDiary/Get?id=' + id;
        var responsedata = apiService.masterget(url);
        responsedata.then(function mySucces(response) {
            $scope.TeacherDiaryModel = response.data;
            $scope.TeacherDiaryModel.DairyDate = new Date(response.data.DairyDate);
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };

    $scope.Cancel = function () {
        window.location = "#!/teacherDiaryBase";
    };
    $scope.GetSchools();
}]);