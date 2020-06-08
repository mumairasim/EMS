SMSHO.controller('teacherDiaryCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.TeacherDiaryModel = {
        DairyText: '',
        DairyDate:'',
        School: $scope.School
        //Employee: $scope.Employee
    };
    //$scope.Employee = {
    //    Name: ''
    //};
    $scope.School = {
        Id: '',
        Name: '',
        Location: ''
    };
    //$scope.GetEmployees = function () {
    //    var responsedata = apiService.masterget('/api/v1/Employee/Get');
    //    responsedata.then(function mySucces(response) {
    //        $scope.Employees = response.data;
    //        $scope.TeacherDiaryModel.Employee = $scope.Employees[0];
    //    },
    //        function myError(response) {
    //            $scope.response = response.data;
    //        });
    //};
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


    $scope.EmployeeCreate = function () {
        var data = $scope.EmployeeModel;
        var formData = new FormData();
        formData.append('employeeModel', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/Employee/Create', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Employee created successfully.", false);
            window.location = "#!/dashboard";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Employee creation failed", true);
            });
    };
    $scope.GetSchools();
    //$scope.GetEmployees();
}]);