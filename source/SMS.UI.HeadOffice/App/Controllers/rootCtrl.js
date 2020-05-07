SMSHO.controller('rootCtrl', ["$scope", "$location", '$timeout', "$rootScope", '$http', 'apiService', '$cookies', function ($scope, $location, $timeout, $rootScope, $http, apiService, $cookies) {
    'use strict';
    $scope.isLogin = false;
    $scope.userDropdown = false;
    $scope.notifications = [];
    $scope.userDropdownClicked = function () {
        if ($scope.userDropdown === true) {
            $scope.userDropdown = false;
        } else {
            $scope.userDropdown = true;
        }
    };
    if ($cookies.get('SMS_Isloggedin') == 'false') {
        $scope.islogin = false;
        $scope.onload = false;
    }
    else {
        $scope.islogin = true;

        $scope.user = $cookies.get("SMS_user");
    }

    $scope.logout = function () {
        $scope.islogin = false;
        apiService.logout();
    };
    $scope.Setisloggedin = function () {
        //if ($cookies.get('SMS_Isloggedin') == 'false') {
        //    $scope.islogin = false;
        //}
        //else {
            $scope.islogin = true;
        //$scope.user = $cookies.get("SMS_user");
        //}
    };
    $scope.growltext = function (infomsg, iserror) {
        $scope.growlmsgtime = 5000;
        $scope.growlshow = true;
        $scope.invalidNotification = false;
        $scope.notifications.push({ growlinfo: infomsg, iserror: iserror });
    };
}]);