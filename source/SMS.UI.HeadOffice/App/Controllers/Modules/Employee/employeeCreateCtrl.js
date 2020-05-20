SMSHO.controller('employeeCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.EmployeeModel = {
        Person: $scope.Person,
        Designation: $scope.Designation,
        School: $scope.School
    };
    $scope.Designation = {
        //Id:'',
        Name: ''
    };
    $scope.Person = {
        FirstName: '',
        LastName: '',
        Designation: '',
        Cnic: '',
        Nationality: '',
        Religion: '',
        PresentAddress: '',
        PermanentAddress: '',
        Phone: ''
    };
    $scope.School = {
        Id: '',
        Name: '',
        Location: ''
    };

    $scope.GetDesignations = function () {
        var responsedata = apiService.masterget('/api/v1/Designation/Get');
        responsedata.then(function mySucces(response) {
            $scope.Designations = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            $scope.EmployeeModel.School = $scope.Schools[0];
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
    $scope.GetDesignations();
    $scope.GetSchools();

}]);