SMSHO.controller('timeTableCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    $scope.TimeTable = {
        Days: [{
            Id: "",
            DayName: "",
            Periods: [{
                Course: "",
                Employee: "",
                StartTime: "",
                EndTime: ""
            }]
        }]
    };
    $scope.Day = {
        Id: "",
        DayName: "",
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
            $scope.TimeTable.Class = $scope.Classes[0];
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
            $scope.TimeTable.School = $scope.Schools[0];
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
            $scope.Initializer();
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };
    $scope.TimeTableCreate = function () {
        var data = $scope.TimeTable;
        var formData = new FormData();
        formData.append('timeTableModel', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/TimeTable/Create', formData);
        responsedata.then(function mySucces(response) {
                $scope.response = response.data;
                $scope.growltext("TimeTable created successfully.", false);
                //window.location = "#!/lessonPlanBase";
            },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("Lesson Plan creation failed", true);
            });
    };
    $scope.AddPeriod = function () {
        for (var i = 0; i < $scope.TimeTable.Days.length; i++) {
            if (($scope.TimeTable.Days[i] !== null) && ($scope.TimeTable.Days[i] !== undefined)) {
                if ($scope.TimeTable.Days[i].DayName == $scope.SelectedDay) {
                    if ($scope.TimeTable.Days[i].Periods == undefined) {
                        $scope.TimeTable.Days[i].Periods = [];
                    }
                    $scope.TimeTable.Days[i].Periods.push({
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
                $scope.TimeTable.Days.push(
                    {
                        Id: $scope.GuidGenerator(),
                        DayName: "Monday"
                    });
            }
        } else {
            $scope.remove("Monday");
        }
        if ($scope.tuesday) {
            if (!$scope.IsAlreadyExist("Tuesday")) {
                $scope.TimeTable.Days.push(
                    {
                        Id: $scope.GuidGenerator(),
                        DayName: "Tuesday"
                    });
            }
        } else {
            $scope.remove("Tuesday");
        }
        if ($scope.wednesday) {
            if (!$scope.IsAlreadyExist("Wednesday")) {
                $scope.TimeTable.Days.push(
                    {
                        Id: $scope.GuidGenerator(),
                        DayName: "Wednesday"
                    });
            }
        } else {
            $scope.remove("Wednesday");
        }
        if ($scope.thursday) {
            if (!$scope.IsAlreadyExist("Thursday")) {
                $scope.TimeTable.Days.push(
                    {
                        Id: $scope.GuidGenerator(),
                        DayName: "Thursday"
                    });
            }
        } else {
            $scope.remove("Thursday");
        }
        if ($scope.friday) {
            if (!$scope.IsAlreadyExist("Friday")) {
                $scope.TimeTable.Days.push(
                    {
                        Id: $scope.GuidGenerator(),
                        DayName: "Friday"
                    });
            }
        } else {
            $scope.remove("Friday");
        }
        if ($scope.saturday) {
            if (!$scope.IsAlreadyExist("Saturday")) {
                $scope.TimeTable.Days.push(
                    {
                        Id: $scope.GuidGenerator(),
                        DayName: "Saturday"
                    });
            }
        } else {
            $scope.remove("Saturday");
        }
        if ($scope.sunday) {
            if (!$scope.IsAlreadyExist("Sunday")) {
                $scope.TimeTable.Days.push(
                    {
                        Id: $scope.GuidGenerator(),
                        DayName: "Sunday"
                    });
            }
        } else {
            $scope.remove("Sunday");
        }
        $scope.PreparePeriodDaysList();
    };
    $scope.remove = function (item) {
        for (var i = 0; i < $scope.TimeTable.Days.length; i++) {
            if (($scope.TimeTable.Days[i] !== null) && ($scope.TimeTable.Days[i] !== undefined)) {
                if ($scope.TimeTable.Days[i].DayName == item) {
                    $scope.TimeTable.Days.splice(i, 1);
                }
            }
        }
    };
    $scope.IsAlreadyExist = function (item) {
        for (var i = 0; i < $scope.TimeTable.Days.length; i++) {
            if (($scope.TimeTable.Days[i] !== null) && ($scope.TimeTable.Days[i] !== undefined)) {
                if ($scope.TimeTable.Days[i].DayName == item) {
                    return true;
                }
            }
        }
        return false;
    };
    $scope.PreparePeriodDaysList = function () {
        $scope.Day = $scope.TimeTable.Days[0];
    };
    $scope.test = function (x, index) {
        console.log(x);
        console.log(index);
        $scope.head = x.DayName;
    };
    $scope.GuidGenerator = function uuidv4() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
    $scope.GetSchools();
}]);