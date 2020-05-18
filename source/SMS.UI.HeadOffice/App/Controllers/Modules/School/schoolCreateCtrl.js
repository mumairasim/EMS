SMSHO.controller('schoolCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    
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
    $scope.SchoolCreate = function () {
        var data = $scope.SchoolModel;
        var responsedata = apiService.register('/api/v1/School/Create', data);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("School created successfully.", false);
            window.location = "#!/dashboard";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("School creation failed", true);
            });
    };
}]);