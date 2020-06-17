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
        if ($scope.IsValid()) {

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
        }
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

    $scope.IsValid = function () {
        if ($scope.StudentModel.Person == undefined) {
            $scope.growltext("Invalid student data", true);
            return false;
        }
        if ($scope.StudentModel.Person.FirstName == null || $scope.StudentModel.Person.FirstName.length > 100) {
            $scope.IsError = "Name may null or exceed than 100 characters";
            $scope.growltext("FirstName may null or exceed than 100 characters", true);
            return false;
        }
        if ($scope.StudentModel.Person.LastName == null || $scope.StudentModel.Person.LastName.length > 100) {
            $scope.IsError = "Name may null or exceed than 100 characters";
            $scope.growltext("LastName may null or exceed than 100 characters", true);
            return false;
        }
        if ($scope.StudentModel.Person.Cnic == null || $scope.StudentModel.Person.Cnic.length != 13) {
            $scope.IsError = "Cnic must be of 13 digits";
            $scope.growltext("Cnic must be of 13 digits", true);
            return false;
        }
        if ($scope.StudentModel.Person.Phone == null || $scope.StudentModel.Person.Phone.length > 15) {
            $scope.IsError = "Phone cannot exceed from 15 digits";
            $scope.growltext("Phone cannot be null or cannot exceed from 15 digits", true);
            return false;
        }
        if ($scope.StudentModel.Person.Nationality == null) {
            $scope.IsError = "Nationality cannot be null";
            $scope.growltext("Nationality cannot be null", true);
            return false;
        }
        
        if ($scope.StudentModel.School == null) {
            $scope.IsError = "School cannot be null";
            $scope.growltext("School cannot be null", true);
            return false;
        }
        if ($scope.StudentModel.Class == null) {
            $scope.IsError = "Class cannot be null";
            $scope.growltext("Class cannot be null", true);
            return false;
        }
        if ($scope.StudentModel.Person.ParentName == null || $scope.StudentModel.Person.ParentName.length > 100) {
            $scope.IsError = "Name may null or exceed than 100 characters";
            $scope.growltext("ParentName may null or exceed than 100 characters", true);
            return false;
        }
        if ($scope.StudentModel.Person.ParentRelation == null) {
            $scope.IsError = "Relation cannot be null";
            $scope.growltext("ParentRelation cannot be null", true);
            return false;
        }
        if ($scope.StudentModel.Person.ParentMobile1 == null || $scope.StudentModel.Person.ParentMobile1.length > 15) {
            $scope.IsError = "Number cannot be null";
            $scope.growltext("ParentNumber1 cannot be null", true);
            return false;
        }
        if ($scope.StudentModel.Person.ParentEmergencyName == null || $scope.StudentModel.Person.ParentEmergencyName.length > 100) {
            $scope.IsError = "Name may null or exceed than 100 characters";
            $scope.growltext("ParName may null or exceed than 100 characters", true);
            return false;
        }
        if ($scope.StudentModel.Person.ParentEmergencyRelation == null) {
            $scope.IsError = "Relation cannot be null";
            $scope.growltext("Relation cannot be null", true);
            return false;
        }
        if ($scope.StudentModel.Person.ParentEmergencyMobile == null || $scope.StudentModel.Person.ParentEmergencyMobile.length > 15) {
            $scope.IsError = "Number cannot be null";
            $scope.growltext("Number cannot be null", true);
            return false;
        }
        return true;
    }
    
        
$scope.GetSchools();
$scope.GetClasses();
}]);