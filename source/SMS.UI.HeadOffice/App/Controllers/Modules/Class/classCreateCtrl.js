﻿SMSHO.controller('classCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.ClassModel = {
        Name: '',
        Id: '',
    };

   
    
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/Schools/Get');

        responsedata.then(function mySucces(response) {

            $scope.Schools = response.data.Employees;
            $scope.ClassModel.School = $scope.Schools[0];
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.ClassCreate = function () {
        var data = $scope.ClassModel;
        data.Id = $scope.ClassModel.School.Id;
        var formData = new FormData();
        formData.append('classModel', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/Class/Create', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Class created successfully.", false);
            window.location = "#!/classBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Class creation failed", true);
            });
    };
    $scope.Cancel = function () {
        window.location = "#!/classBase";
    };
    $scope.GetSchools();
}]);