﻿SMSHO.controller('studentDiaryCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.StudentDiaryDiaryModel = {
        Diarytext: '',
        DairyDate: '',
        InstructorId: '',
    };
    $scope.GetEmployees = function () {
        var responsedata = apiService.masterget('/api/v1/Employee/Get');

        responsedata.then(function mySucces(response) {

            $scope.Employees = response.data.Employees;
            $scope.StudentDiaryModel.Employee = $scope.Employees[0];
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.StudentDiaryCreate = function () {
        var data = $scope.StudentDiaryModel;
        data.InstructorId = $scope.StudentDiaryModel.Employee.Id;
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
    $scope.GetEmployees();
}]);