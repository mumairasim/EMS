SMSHO.controller('studentCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.StudentModel = {
        RegistrationNumber: '',
        Person: $scope.Person,
        Class: $scope.Class,
        School: $scope.School,
        Image: $scope.Image,
        PreviousSchoolName: '',
        ReasonForLeaving: ''
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
        var data = $scope.StudentModel;
        var formData = new FormData();
        if ($scope.StudentModel.Image != null && $scope.StudentModel.Image != undefined) {
            $scope.CheckIsFileValid($scope.StudentModel.Image.ImageFile[0]);
            if ($scope.IsFileValid) {
                $scope.NewImageFile = $scope.StudentModel.Image.ImageFile;
                formData.append("file", $scope.NewImageFile[0]);
                data.Image.ImageFile = null;
            } else {
                $scope.growltext("Invalid Image file", true);
            }
        }
        formData.append('studentModel', JSON.stringify(data));
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
        if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') &&
            file.size <= (512 * 1024)) {
            $scope.IsFileValid = true;
        } else {
            $scope.IsFileValid = false;
        }
    };

    $scope.SelectFileForUpload = function (file) {
        $scope.StudentModel.Image.ImageFile = file[0];
    };

    $scope.Cancel = function () {
        window.location = "#!/studentBase";
    };

    $scope.GetSchools();
    $scope.GetClasses();
}]);