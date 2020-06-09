SMSHO.controller('teacherDiaryCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.TeacherDiaryModel = {
        DairyText: '',
        DairyDate:'',
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
    
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            $scope.TeacherDiaryModel.School = $scope.Schools[0];
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };

    $scope.GetEmployeeByDesignation = function () {
        var responsedata = apiService.masterget('/api/v1/Employee/GetDesignationTeacher');
        responsedata.then(function mySucces(response) {
            $scope.Employees = response.data;
            $scope.TeacherDiaryModel.Employee = $scope.Employees[0];
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };

    $scope.TeacherDiaryCreate = function () {
        var data = $scope.TeacherDiaryModel;
        var formData = new FormData();
        formData.append('teacherDiaryModel', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/TeacherDiary/Create', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Teacher Diary created successfully.", false);
            window.location = "#!/dashboard";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Teacher Diary creation failed", true);
            });
    };
    $scope.GetSchools();
    $scope.GetEmployeeByDesignation();
}]);