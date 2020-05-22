﻿SMSHO.controller('studentCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
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
            $scope.StudentModel.Class = $scope.Classes[0];
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            $scope.StudentModel.School = $scope.Schools[0];
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.StudentCreate = function () {
        debugger;
        var data = $scope.StudentModel;
        var formData = new FormData();
        formData.append('studentModel', JSON.stringify(data));
        $scope.CheckIsFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFileValid) {
            formData.append("file", $scope.SelectedFileForUpload);
        } else {
            $scope.growltext("Invalid file", true);
        }
        var responsedata = apiService.post('/api/v1/Student/Create', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Student created successfully.", false);
            window.location = "#!/studentBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Student creation failed", true);
            });
    };

    $scope.CheckIsFileValid = function (file) {
        if ($scope.SelectedFileForUpload != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') &&
                file.size <= (512 * 1024)) {
                $scope.IsFileValid = true;
            } else {
                $scope.IsFileValid = false;
            }
        }
    };

    $scope.SelectFileForUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    };

    $scope.Cancel = function () {
        window.location = "#!/studentBase";
    };
    $scope.GetSchools();
    $scope.GetClasses();
}]);