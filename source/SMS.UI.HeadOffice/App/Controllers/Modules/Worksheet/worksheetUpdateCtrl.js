﻿SMSHO.controller('worksheetUpdateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.StudentModel = {
        RegistrationNumber: '',
        Person: $scope.Person,
        Class: $scope.Class,
        School: $scope.School
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
    $scope.Class = {
        Id: '',
        ClassName: ''
    };
    $scope.School = {
        Id: '',
        Name: '',
        Location: ''
    };
    $scope.GetClasses = function () {
        var responsedata = apiService.masterget('/api/v1/Class/Get');
        responsedata.then(function mySucces(response) {
            $scope.Classes = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.StudentCreate = function () {
        var data = $scope.StudentModel;
        var responsedata = apiService.register('/api/v1/Student/Create', data);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Student created successfully.", false);
            window.location = "#!/dashboard";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Student creation failed", true);
            });
    };
}]);