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
    }).when("/lessonPlanBase", {
        title: "LessonPlan Search",
        templateUrl: "App/Controllers/Modules/LessonPlan/lessonPlanBase.html",
        controller: "lessonPlanBaseCtrl"
    }).when("/lessonPlanCreate", {
        title: "LessonPlan Create",
        templateUrl: "App/Controllers/Modules/LessonPlan/lessonPlanCreate.html",
        controller: "lessonPlanCreateCtrl"
    }).when("/userProfile", {
        title: "User Profile View",
        templateUrl: "App/Controllers/UserProfile/UserProfile.html",
        controller: "UserProfileCtrl"
    }).when("/changePassword", {
        title: "Change Pasword",
        templateUrl: "App/Controllers/UserProfile/ChangePassword.html",
        controller: "ChangePasswordCtrl"
    }).otherwise({
            redirectTo: '/'
        });
    $locationProvider.html5Mode(false);
}]);
