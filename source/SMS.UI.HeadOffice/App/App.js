var SMSHO = angular.module("SMSHO", ['ngRoute', 'ngCookies', 'LocalStorageModule', 'checklist-model', 'growlNotifications', 'ngAnimate']);
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
        .otherwise({
            redirectTo: '/'
        });
    $locationProvider.html5Mode(false);
}]);
