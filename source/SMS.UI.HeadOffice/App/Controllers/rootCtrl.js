﻿SMSHO.controller('rootCtrl', ["$scope", "$location", '$timeout', "$rootScope", '$http', 'apiService', '$cookies', function ($scope, $location, $timeout, $rootScope, $http, apiService, $cookies) {
    'use strict';
    $scope.isLogin = false;
    $scope.dropDownVisible = false;
    $scope.notifications = [];
    $scope.CheckUser = function () {
        if ($cookies.get('SMS_Isloggedin') == 'false') {
            $scope.islogin = false;
        } else {
            $scope.islogin = true;
            $scope.user = $cookies.get("SMS_user");
        }
    };
    $scope.CheckUser();
    $scope.Setisloggedin = function () {
        if ($cookies.get('SMS_Isloggedin') == 'false') {
            $scope.islogin = false;
        }
        else {
            $scope.islogin = true;
            $scope.user = $cookies.get("SMS_user");
        }
    };
    $scope.Setisloggedinfalse = function () {
        $scope.islogin = false;
    };
    $scope.growltext = function (infomsg, iserror) {
        $scope.growlmsgtime = 5000;
        $scope.growlshow = true;
        $scope.invalidNotification = false;
        $scope.notifications.push({ growlinfo: infomsg, iserror: iserror });
    };
    $scope.loader = function (value) {
        $scope.onload = value;
    };
    $scope.logout = function () {
        $scope.islogin = false;
        var logoutResponse = apiService.logout('/api/Account/Logout');
        logoutResponse.then(function mySucces(response) {
            $cookies.remove('SMS_token');
            $cookies.put('SMS_Isloggedin', false);
            $cookies.put('SMS_logout', true);
            window.location = "#!/";
            $scope.growltext('User logged out successfully', false);
        },
            function myError(response) {
                if (response.status != 200) {
                    if ($cookies.get('SMS_logout') == 'false') {
                        $scope.iserror = true;
                        $scope.growltext('Your session has expired please login again', true);
                    }
                }
            });
    };
    $scope.showDropdown = function () {
        if ($scope.dropDownVisible == false) {
            $("#profileCaret").removeClass('reverseProfileCaretDisplay');
            $("#profileCaret").addClass('profileCaretDisplay');
            $scope.dropDownVisible = true;
        } else {
            $("#profileCaret").removeClass('profileCaretDisplay');
            $("#profileCaret").addClass('reverseProfileCaretDisplay');
            $scope.dropDownVisible = false;
        }
    };
}]);