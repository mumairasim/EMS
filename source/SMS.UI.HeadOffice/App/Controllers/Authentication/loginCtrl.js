//(function (app) {
//    'use strict';

SMSHO.controller('loginCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    //$scope.identitydate = $cookies.get('token-expire-identity');
    $scope.iserror = false;
    $scope.authorizeobj = apiService.authorizationbit();
    $scope.logindata = {
        grant_type: 'password',
        userName: '',
        password: ''
    };
    $scope.responsebadrequest = '';
    $scope.responsemsg = 'This is for showing any error that may occur during login.';
    if (!$scope.authorizeobj.authorize) {
        $scope.responsemsg = $scope.authorizeobj.authorizemsg;
        $scope.iserror = true;
    }
    else {
        $scope.responsemsg = '';
        $scope.iserror = false;
    }
    if ($cookies.get('token') != null) {
        window.location = "#!/dashboard";
    }
    else {
        apiService.logout();
        if ($cookies.get('logout') == 'false') {
            $scope.iserror = true;
            $scope.responsemsg = 'Your session has expired please login again';
        }
    }
    $scope.logincall = function () {
        //$scope.loader(true);
        var data = "grant_type=password&username=" + $scope.logindata.userName + "&password=" + $scope.logindata.password;
        var responsedata = apiService.login('/Token', data);
        responsedata.then(function mySucces(response) {
            $cookies.put('SMS_token', response.data.access_token);
            $cookies.put('SMS_Isloggedin', 'true');
            $cookies.put('SMS_user', response.data.userName);
            $cookies.put('SMS_userId', response.data.Id);
            $cookies.put('SMS_token-expire-identity', response.data[".expires"]);
            $cookies.put('SMS_logout', false);
            $scope.Setisloggedin();
            apiService.setaccesstoken();
            $scope.iserror = false;
            $scope.growltext("Login sucessfull.", false);
            window.location = "#!/dashboard";
        }, function myError(response) {
            if (response.status != 200) {
                $scope.iserror = true;
                //$scope.responsemsg = response.data.error_description;
                $scope.growltext("Login failed.", true);
            }

        });
    };
    $scope.test = function () {
        $scope.growltext("login notification test.", false);
    }

}]);

