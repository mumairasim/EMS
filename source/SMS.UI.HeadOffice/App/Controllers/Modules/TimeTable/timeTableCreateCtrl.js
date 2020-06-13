SMSHO.controller('timeTableCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.Days = [];
    $scope.Day = {
        Id: "",
        Day: "",
        Periods: []
    };
    $scope.Period = {
        Course: "",
        Employee: "",
        StartTime: "",
        EndTime: ""

    };
    $scope.Initializer = function () {
        $scope.monday = true;
        $scope.tuesday = true;
        $scope.wednesday = true;
        $scope.thursday = true;
        $scope.friday = true;
        $scope.saturday = false;
        $scope.sunday = false;
        $scope.PopulateRows();

    };
    $scope.GetClasses = function () {
        var responsedata = apiService.masterget('/api/v1/Class/GetBySchool?schoolId=' + $scope.School.Id);
        responsedata.then(function mySucces(response) {
            $scope.Classes = response.data;
            $scope.Class = $scope.Classes[0];
            $scope.GetCourses();
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
    $scope.GetCourses = function () {
        var responsedata = apiService.masterget('/api/v1/Course/GetAllBySchool?schoolId=' + $scope.School.Id);
        responsedata.then(function mySucces(response) {
            $scope.Courses = response.data;
            $scope.Course = $scope.Courses[0];
            $scope.GetEmployeeByDesignation();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.GetEmployeeByDesignation = function () {
        var responsedata = apiService.masterget('/api/v1/Employee/GetDesignationTeacher');
        responsedata.then(function mySucces(response) {
            $scope.Employees = response.data;
            $scope.Employee = $scope.Employees[0];
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.AddPeriod = function () {
        for (var i = 0; i < $scope.Days.length; i++) {
            if (($scope.Days[i] !== null) && ($scope.Days[i] !== undefined)) {
                if ($scope.Days[i].Day == $scope.Day.Day) {
                    if ($scope.Days[i].Periods == undefined) {
                        $scope.Days[i].Periods = [];
                    }
                    $scope.Days[i].Periods.push({
                        Course: $scope.Course,
                        Employee: $scope.Employee,
                        StartTime: $scope.StartTime,
                        EndTime: $scope.EndTime
                    });
                }
            }
        }
    };
    $scope.PopulateRows = function () {

        if ($scope.monday) {
            if (!$scope.IsAlreadyExist("Monday")) {
                $scope.Days.push(
                    {
                        Day: "Monday"
                    });
            }
        } else {
            $scope.remove("Monday");
        }
        if ($scope.tuesday) {
            if (!$scope.IsAlreadyExist("Tuesday")) {
                $scope.Days.push(
                    {
                        Day: "Tuesday"
                    });
            }
        } else {
            $scope.remove("Tuesday");
        }
        if ($scope.wednesday) {
            if (!$scope.IsAlreadyExist("Wednesday")) {
                $scope.Days.push(
                    {
                        Day: "Wednesday"
                    });
            }
        } else {
            $scope.remove("Wednesday");
        }
        if ($scope.thursday) {
            if (!$scope.IsAlreadyExist("Thursday")) {
                $scope.Days.push(
                    {
                        Day: "Thursday"
                    });
            }
        } else {
            $scope.remove("Thursday");
        }
        if ($scope.friday) {
            if (!$scope.IsAlreadyExist("Friday")) {
                $scope.Days.push(
                    {
                        Day: "Friday"
                    });
            }
        } else {
            $scope.remove("Friday");
        }
        if ($scope.saturday) {
            if (!$scope.IsAlreadyExist("Saturday")) {
                $scope.Days.push(
                    {
                        Day: "Saturday"
                    });
            }
        } else {
            $scope.remove("Saturday");
        }
        if ($scope.sunday) {
            if (!$scope.IsAlreadyExist("Sunday")) {
                $scope.Days.push(
                    {
                        Day: "Sunday"
                    });
            }
        } else {
            $scope.remove("Sunday");
        }
    };
    $scope.remove = function (item) {
        for (var i = 0; i < $scope.Days.length; i++) {
            if (($scope.Days[i] !== null) && ($scope.Days[i] !== undefined)) {
                if ($scope.Days[i].Day == item) {
                    $scope.Days.splice(i, 1);
                }
            }
        }
    };
    $scope.IsAlreadyExist = function (item) {
        for (var i = 0; i < $scope.Days.length; i++) {
            if (($scope.Days[i] !== null) && ($scope.Days[i] !== undefined)) {
                if ($scope.Days[i].Day == item) {
                    return true;
                }
            }
        }
        return false;
    };

    $scope.Initializer();
    $scope.GetSchools();
}]);