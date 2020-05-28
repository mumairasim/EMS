
SMSHO.controller('studentAttendanceSheetCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';

    $scope.StudentAttendanceModel = {
        Class: $scope.Class,
        School: $scope.School
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
    $scope.StudentsAttendanceListDetail = {
        StudentsAttendances: []
    };
    $scope.GetStudents = function () {
        var responsedata = apiService.masterget('/api/v1/Student/Get?classId=' + $scope.Class.Id + '&schoolId=' + $scope.School.Id);
        responsedata.then(function mySucces(response) {
            $scope.studentList = response.data.Students;
            $scope.TotalStudents = response.data.StudentsCount;
            for (var i = 0; i < response.data.Students.length; i++) {
                $scope.StudentAttendanceModel.SchoolId = $scope.School.Id;
                $scope.StudentAttendanceModel.ClassId = $scope.Class.Id;
                for (var j = 0; j < $scope.AttendanceStatusList.length; j++) {
                    if ($scope.AttendanceStatusList[j].Status == 'Present') {
                        $scope.StudentAttendanceModel.AttendanceStatusId = $scope.AttendanceStatusList[j].Id;
                    }
                }
                $scope.StudentAttendanceModel.StudentId = response.data.Students[i].Id;
                $scope.StudentsAttendanceListDetail.StudentsAttendances.push($scope.StudentAttendanceModel);
            }
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetAttendanceStatus = function () {
        var responsedata = apiService.masterget('/api/v1/AttendanceStatus/Get');
        responsedata.then(function mySucces(response) {
            $scope.AttendanceStatusList = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetClasses = function () {
        var responsedata = apiService.masterget('/api/v1/Class/GetBySchool?schoolId=' + $scope.School.Id);
        responsedata.then(function mySucces(response) {
            $scope.Classes = response.data;
            $scope.Class = $scope.Classes[0];
            $scope.GetStudents();
            $scope.GetAttendanceStatus();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            $scope.School = $scope.Schools[0];
            $scope.GetClasses();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.StatusUpdation = function (studentId, status) {
        for (var i = 0; i < $scope.StudentsAttendanceListDetail.StudentsAttendances.length; i++) {
            if ($scope.StudentsAttendanceListDetail.StudentsAttendances.StudentId == studentId) {
                for (var j = 0; j < $scope.AttendanceStatusList.length; j++) {
                    if ($scope.AttendanceStatusList[j].Status == status) {
                        $scope.StudentsAttendanceListDetail.StudentsAttendances[i].AttendanceStatusId = $scope.AttendanceStatusList[i].Id;
                    }
                }
            }
        }
    };
    $scope.SubmitAttendance = function () {
        var data = $scope.StudentsAttendanceListDetail;
        var formData = new FormData();
        formData.append('StudentsAttendanceListDetail', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/StudentAttendance/BulkCreate', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("Attendance marked successfully.", false);
            window.location = "#!/dashboard";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Attendance marking failed.", true);
            });
    };
    $scope.GetSchools();
}]);

