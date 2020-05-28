SMSHO.controller('studentDiaryUpdateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.StudentDiaryDiaryModel = {
        Diarytext: '',
        DairyDate: '',
        Employee: $scope.Employee,
    };
    $scope.Employee = {
        Person: '',
        Designation: ''
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
    $scope.Designation = {
        Name: ''
    };
    $scope.GetEmployees = function () {
        var responsedata = apiService.masterget('/api/v1/Employee/Get');
        responsedata.then(function mySucces(response) {
            $scope.Employees = response.data;
            
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.StudentDiaryUpdate = function () {
        var data = $scope.StudentDiaryModel;
        var formData = new FormData();
        formData.append('studentDiaryModel', JSON.stringify(data));
        var responsedata = apiService.masterput('/api/v1/StudentDiary/Update', formData);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("StudentDiary updated successfully.", false);
            window.location = "#!/studentDiaryBase";
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("StudentDiary updation failed", true);
            });
    };
    $scope.FetchStudentDiary = function () {
        var id = $routeParams.Id;
        var url = '/api/v1/StudentDiary/Get?id=' + id;
        var responsedata = apiService.masterget(url);
        responsedata.then(function mySucces(response) {
            $scope.StudentDiaryModel = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.Cancel = function () {
        window.location = "#!/studentDiaryBase";
    };
    $scope.FetchStudentDiary();
}]);