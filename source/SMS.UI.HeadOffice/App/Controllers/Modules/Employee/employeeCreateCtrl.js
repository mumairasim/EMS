SMSHO.controller('employeeCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.employeeModel = {
        //RegistrationNumber: '',
        Person: $scope.Person,
        Designation: $scope.Designation
        //Class: $scope.Class,
        //School: $scope.School
    };
    $scope.Designation = {
        Name: '' 
    };
    $scope.Person = {
        FirstName: '',
        LastName: '',
        Designation:'',
        Cnic: '',
        Nationality: '',
        Religion: '',
        PresentAddress: '',
        PermanentAddress: '',
        Phone: ''
    };
    //$scope.Class = {
    //    Id: '',
    //    ClassName: ''
    //};
    //$scope.School = {
    //    Id: '',
    //    Name: '',
    //    Location: ''
    //};
    //$scope.GetDesignation = function () {
    //    var responsedata = apiService.masterget('/api/v1/Designation/Get');
    //    responsedata.then(function mySucces(response) {
    //        $scope.Designations = response.data;
    //    },
    //        function myError(response) {
    //            $scope.response = response.data;
    //        });
    //};
    $scope.GetDesignations = function () {
        var responsedata = apiService.masterget('/api/v1/Designation/Get');
        responsedata.then(function mySucces(response) {
            $scope.Designations = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.EmployeeCreate = function () {
        var data = $scope.EmployeeModel;
        var responsedata = apiService.register('/api/v1/Employee/Create', data);
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
}]);