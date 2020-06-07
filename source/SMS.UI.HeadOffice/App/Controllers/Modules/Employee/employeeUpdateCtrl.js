SMSHO.controller('employeeUpdateCtrl', ['$scope', 'apiService', '$cookies', '$routeParams', function ($scope, apiService, $cookies, $routeParams) {
    'use strict';
    $scope.EmployeeModel = {
        Person: $scope.Person,
        Designation: $scope.Designation,
        School: $scope.School
    };
    $scope.Person = {
        FirstName: '',
        LastName: '',
        ParentName: '',
        Age: '',
        DOB: '',
        Cnic: '',
        ParentCnic: '',
        ParentCity: '',
        ParentEmail: '',
        ParentRelation: '',
        ParentOccupation: '',
        ParentHighestEducation: '',
        ParentNationality: '',
        ParentOfficeAddress: '',
        ParentMobile1: '',
        ParentMobile2: '',
        ParentEmergencyName: '',
        ParentEmergencyRelation: '',
        ParentEmergencyMobile: '',
        Nationality: '',
        Religion: '',
        PresentAddress: '',
        PermanentAddress: '',
        Phone: ''
    };
    $scope.Designation = {
        Name: ''
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
            $scope.FetchEmployee();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            $scope.GetDesignations();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };

    $scope.EmployeeUpdate = function () {
        var data = $scope.EmployeeModel;
        var formData = new FormData();
        formData.append('employeeModel', JSON.stringify(data));
        var responsedata = apiService.masterput('/api/v1/Employee/Update', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Employee updated successfully.", false);
            window.location = "#!/employeeBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Employee updation failed", true);
            });
    };
    $scope.FetchEmployee = function () {
        var id = $routeParams.Id;
        var url = '/api/v1/Employee/Get?id=' + id;
        var responsedata = apiService.masterget(url);
        responsedata.then(function mySucces(response) {
            $scope.EmployeeModel = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };

    $scope.Cancel = function () {
        window.location = "#!/employeeBase";
    };
    $scope.GetSchools();
}]);