var SMSHO = angular.module("SMSHO", ['ngRoute', 'ngCookies', 'LocalStorageModule', 'checklist-model', 'growlNotifications', 'ngAnimate', 'ngFileUpload']);
SMSHO.config(['$routeProvider', '$locationProvider', 'localStorageServiceProvider', function ($routeProvider, $locationProvider, localStorageServiceProvider) {

    localStorageServiceProvider.setPrefix('SMSHOLocalStorage');

    $routeProvider.when("/", {
        title: "Login",
        templateUrl: "App/Controllers/Authentication/login.html",
        controller: "loginCtrl"
    }).when("/register", {
        title: "Register",
        templateUrl: "App/Controllers/Authentication/register.html",
        controller: "registerCtrl"
    }).when("/dashboard", {
        title: "Dashboard",
        templateUrl: "App/Controllers/Dashboard/dashboard.html",
        controller: "dashboardCtrl"
    }).when("/studentSearch", {
        title: "Student Search",
        templateUrl: "App/Controllers/Modules/Student/studentSearch.html",
        controller: "studentSearchCtrl"
    }).when("/studentCreate", {
        title: "Student Create",
        templateUrl: "App/Controllers/Modules/Student/studentCreate.html",
        controller: "studentCreateCtrl"
    }).when("/studentUpdate", {
        title: "Student Update",
        templateUrl: "App/Controllers/Modules/Student/studentUpdate.html",
        controller: "studentUpdateCtrl"
    }).when("/studentBase", {
        title: "Student Search",
        templateUrl: "App/Controllers/Modules/Student/studentBase.html",
        controller: "studentBaseCtrl"
    })
        .when("/schoolSearch", {
        title: "School Search",
        templateUrl: "App/Controllers/Modules/School/schoolSearch.html",
            controller: "schoolSearchCtrl"
        }).when("/schoolCreate", {
        title: "School Create",
        templateUrl: "App/Controllers/Modules/School/schoolCreate.html",
        controller: "schoolCreateCtrl"
    }).when("/schoolUpdate", {
        title: "School Update",
        templateUrl: "App/Controllers/Modules/School/schoolUpdate.html",
        controller: "schoolUpdateCtrl"
    }).when("/schoolBase", {
        title: "School Search",
        templateUrl: "App/Controllers/Modules/School/schoolBase.html",
        controller: "schoolBaseCtrl"
    })
        .when("/studentDiarySearch", {
            title: "StudentDiary Search",
            templateUrl: "App/Controllers/Modules/StudentDiary/studentDiarySearch.html",
            controller: "studentDiarySearchCtrl"
        }).when("/studentDiaryCreate", {
            title: "StudentDiary Create",
            templateUrl: "App/Controllers/Modules/StudentDiary/studentDiaryCreate.html",
            controller: "studentDiaryCreateCtrl"
        }).when("/studentDiaryUpdate", {
            title: "StudentDiary Update",
            templateUrl: "App/Controllers/Modules/StudentDiary/studentDiaryUpdate.html",
            controller: "studentDiaryUpdateCtrl"
        }).when("/studentDiaryBase", {
            title: "StudentDiary Search",
            templateUrl: "App/Controllers/Modules/StudentDiary/studentDiaryBase.html",
            controller: "studentDiarylBaseCtrl"
        })
        .when("/classSearch", {
            title: "Class Search",
            templateUrl: "App/Controllers/Modules/class/classSearch.html",
            controller: "studentDiarySearchCtrl"
        }).when("/classCreate", {
            title: "Class Create",
            templateUrl: "App/Controllers/Modules/class/classCreate.html",
            controller: "classCreateCtrl"
        }).when("/classUpdate", {
            title: "Class Update",
            templateUrl: "App/Controllers/Modules/class/classUpdate.html",
            controller: "classUpdateCtrl"
        }).when("/classBase", {
            title: "Class Search",
            templateUrl: "App/Controllers/Modules/class/classBase.html",
            controller: "classBaseCtrl"
        }).when("/employeeSearch", {
        title: "Employee Search",
        templateUrl: "App/Controllers/Modules/Employee/employeeSearch.html",
        controller: "employeeSearchCtrl"
    }).when("/employeeCreate", {
        title: "Employee Create",
        templateUrl: "App/Controllers/Modules/Employee/employeeCreate.html",
        controller: "employeeCreateCtrl"
    }).when("/employeeUpdate", {
        title: "Employee Update",
        templateUrl: "App/Controllers/Modules/Employee/employeeUpdate.html",
        controller: "employeeUpdateCtrl"
    }).when("/employeeBase", {
        title: "Employee Search",
        templateUrl: "App/Controllers/Modules/Employee/employeeBase.html",
        controller: "employeeBaseCtrl"
    })
        .when("/lessonPlanBase", {
        title: "LessonPlan Search",
        templateUrl: "App/Controllers/Modules/LessonPlan/lessonPlanBase.html",
        controller: "lessonPlanBaseCtrl"
    }).when("/lessonPlanCreate", {
        title: "LessonPlan Create",
        templateUrl: "App/Controllers/Modules/LessonPlan/lessonPlanCreate.html",
        controller: "lessonPlanCreateCtrl"
    }).when("/lessonPlanUpdate", {
        title: "LessonPlan Update",
        templateUrl: "App/Controllers/Modules/LessonPlan/lessonPlanUpdate.html",
        controller: "lessonPlanUpdateCtrl"
    }).when("/userProfile", {
        title: "User Profile View",
        templateUrl: "App/Controllers/UserProfile/UserProfile.html",
        controller: "UserProfileCtrl"
    }).when("/changePassword", {
        title: "Change Pasword",
        templateUrl: "App/Controllers/UserProfile/ChangePassword.html",
        controller: "ChangePasswordCtrl"

    })
        .when("/worksheetBase", {
            title: "Worksheet Search",
            templateUrl: "App/Controllers/Modules/Worksheet/worksheetBase.html",
            controller: "worksheetBaseCtrl"
        })
        .when("/worksheetSearch", {
            title: "Worksheet Search",
            templateUrl: "App/Controllers/Modules/Worksheet/worksheetSearch.html",
            controller: "worksheetSearchCtrl"
        })
        .when("/worksheetCreate", {
            title: "Worksheet Create",
            templateUrl: "App/Controllers/Modules/Worksheet/worksheetCreate.html",
            controller: "worksheetCreateCtrl"
        })
        .when("/worksheetUpdate", {
            title: "Worksheet Update",
            templateUrl: "App/Controllers/Modules/Worksheet/WorksheetUpdate.html",
            controller: "worksheetUpdateCtrl"
        })
        .when("/studentAttendanceSheet", {
            title: "Student Attendance",
            templateUrl: "App/Controllers/Modules/Attendance/studentAttendanceSheet.html",
            controller: "studentAttendanceSheetCtrl"
        })
        .when("/studentAttendanceSheetBase", {
            title: "Student Attendance Search",
            templateUrl: "App/Controllers/Modules/Attendance/studentAttendanceSheetBase.html",
            controller: "studentAttendanceSheetBaseCtrl"
        })
        .when("/studentAttendanceSheetUpdate", {
            title: "Student Attendance Update",
            templateUrl: "App/Controllers/Modules/Attendance/studentAttendanceSheetUpdate.html",
            controller: "studentAttendanceSheetUpdateCtrl"
        })
        .otherwise({
            redirectTo: '/'
        });
    $locationProvider.html5Mode(false);
}]);
