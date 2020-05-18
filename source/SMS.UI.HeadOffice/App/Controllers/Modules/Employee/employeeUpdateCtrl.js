SMSHO.controller('employeeUpdateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.employeeModel = {
        Person: $scope.Person,
        Designation: $scope.Designation
    };
    $scope.Person = {
        FirstName: '',
        LastName: '',
        Cnic: '',
        Nationality: '',
        Religion: '',
        PresentAddress: '',
        PermanentAddress: '',
        Phone: ''
    };
    $scope.Designation = {
        Name: ''
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
    $scope.Cancel = function () {
        window.location = "#!/employeeBase";
    };
}]);