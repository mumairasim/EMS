SMSHO.controller('studentUpdateCtrl', ['$scope', 'apiService', '$cookies', '$routeParams', function ($scope, apiService, $cookies, $routeParams) {
    'use strict';
    $scope.StudentModel = {
        RegistrationNumber: '',
        Person: $scope.Person,
        Class: $scope.Class,
        School: $scope.School,
        Image: $scope.Image
    };
    $scope.Image = {
        Id: '',
        Name: '',
        Description: '',
        Path: '',
        Size: '',
        ImageFile: ''
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
    $scope.updatedImage = false;
    $scope.GetClasses = function () {
        var responsedata = apiService.masterget('/api/v1/Class/Get');
        responsedata.then(function mySucces(response) {
            $scope.Classes = response.data;
            $scope.FetchStudent();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            $scope.GetClasses();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };

    $scope.StudentUpdate = function () {
        var data = $scope.StudentModel;

        var formData = new FormData();

        if ($scope.StudentModel.Image != null && $scope.StudentModel.Image != undefined) {
            $scope.NewImageFile = $scope.StudentModel.Image.ImageFile;
            formData.append("file", $scope.NewImageFile[0]);
            data.Image.ImageFile = null;
        }
        formData.append('studentModel', JSON.stringify(data));
        var responsedata = apiService.masterput('/api/v1/Student/Update', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Student updated successfully.", false);
            window.location = "#!/studentBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Student updation failed", true);
            });
    };
    $scope.FetchStudent = function () {
        var id = $routeParams.Id;
        var url = '/api/v1/Student/Get?id=' + id;
        var responsedata = apiService.masterget(url);
        responsedata.then(function mySucces(response) {
            $scope.StudentModel = response.data;
            if ($scope.StudentModel.Image != null && $scope.StudentModel.Image != undefined) {
                $scope.FetchImage();
            }
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.FetchImage = function () {
        var url = '/api/v1/File/Get?id=' + $scope.StudentModel.Image.Id;
        var responsedata = apiService.masterget(url);
        responsedata.then(function mySucces(response) {
            $scope.StudentModel.Image = response.data;
            $scope.UserImage = $scope.StudentModel.Image.ImageFile;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.CheckIsFileValid = function (file) {
        if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') &&
            file.size <= (512 * 1024)) {
            $scope.IsFileValid = true;
        } else {
            $scope.IsFileValid = false;
        }
    };
    $scope.SelectFileForUpload = function (file) {
        if (file.length > 0) {
            $scope.CheckIsFileValid(file[0]);
            if ($scope.IsFileValid) {
                $scope.StudentModel.Image.ImageFile = file[0];
                $scope.updatedImage = true;
            } else {
                $scope.growltext("Invalid Image file please select image of size less than 1MB", true);
            }


        }
    };
    $scope.Cancel = function () {
        window.location = "#!/studentBase";
    };
    $scope.GetSchools();



}]);