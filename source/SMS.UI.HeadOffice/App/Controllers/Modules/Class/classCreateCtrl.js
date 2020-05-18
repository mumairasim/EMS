SMSHO.controller('classCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.ClassModel = {
        Id: '',
        School: $scope.School
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
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.ClassCreate = function () {
        var data = $scope.ClassModel;
        var responsedata = apiService.register('/api/v1/Class/Create', data);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Class created successfully.", false);
            window.location = "#!/dashboard";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Class creation failed", true);
            });
    };
}]);