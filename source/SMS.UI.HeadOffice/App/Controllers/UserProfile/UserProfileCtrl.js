
SMSHO.controller('UserProfileCtrl', ['$scope', 'apiService', '$cookies', '$routeParams', function ($scope, apiService, $cookies, $routeParams) {
    'use strict';
    $scope.UserModel = {
        Username: '',
        Email: ''
    };

    $scope.IsFormSubimtted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;
    $scope.Message = "";
    $scope.FileDescription = "";
    $scope.selectedFileForUpload = null;

    $scope.$watch("f1.$valid", function (isValid) {
        $scope.isFormValid = isValid;
    });

    $scope.CheckIsFileValid = function (file) {
        if ($scope.SelectedFileForUpload != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                $scope.IsFileValid = true;
            }
            else {
                $scope.IsFileValid = false;
            }
        }
    }

    $scope.SelectFileForUpload = function (file) {
        debugger;
        $scope.SelectedFileForUpload = file[0];
    }

    $scope.SaveFile = function () {
        debugger;
        $scope.IsFormSubimtted = true;
        $scope.Message = "";
        $scope.CheckIsFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFileValid) {
            apiService.uploadFile($scope.SelectedFileForUpload, $scope.FileDescription, 'api/v1/File/Save')
                .then(function (d) {
                    alert(d.Message);
                }, function (e) {
                    alert(e);
                });
        }
        else {
            $scope = "Fileds Required";
        }

    }

    $scope.UserUpdate = function () {
        debugger;
        var data = $scope.UserModel;
        var formData = new FormData();
        formData.append('userModel', JSON.stringify(data));
        var responsedata = apiService.masterput('/api/v1/Student/Update', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("User updated successfully.", false);
            window.location = "#!/userProfile";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("User updation failed", true);
            });
    };
    $scope.GetUser = function () {
        var id = $routeParams.Id;
        var url = '/api/Account/UserInfo';
        var responsedata = apiService.masterget(url);
        responsedata.then(function mySucces(response) {
            $scope.UserModel = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.Cancel = function () {
        window.location = "#!/";
    };

    $scope.GetUser();
}]);
