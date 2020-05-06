SMSHO.controller('rootCtrl', ["$scope", "$location", '$timeout', "$rootScope", '$http', 'apiService', '$cookies', function ($scope, $location, $timeout, $rootScope, $http, apiService, $cookies) {
    'use strict';
    //$scope.isLogin = false;
    $scope.userDropdown = false;
    $scope.notifications = [];
    $scope.userDropdownClicked = function () {
        if ($scope.userDropdown === true) {
            $scope.userDropdown = false;
        } else {
            $scope.userDropdown = true;
        }
    };
    $scope.growltext = function (infomsg, iserror) {
        $scope.growlmsgtime = 5000;
        $scope.growlshow = true;
        $scope.invalidNotification = false;
        $scope.notifications.push({ growlinfo: infomsg, iserror: iserror });
    };
}]);