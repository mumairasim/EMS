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
        window.location = "#!/search";
    }
    else {
        apiService.logout();
        if ($cookies.get('logout') == 'false') {
            $scope.iserror = true;
            $scope.responsemsg = 'Your session has expired please login again';
        }
    }
    $scope.logincall = function () {
        $scope.loader(true);
        //window.location = "#!/search";
        var data = "grant_type=password&username=" + $scope.logindata.userName + "&password=" + $scope.logindata.password;
        // var data = $scope.logindata;
        var responsedata = apiService.login('/Token', data);
        responsedata.then(function mySucces(response) {
            $cookies.put('token', response.data.access_token);
            $cookies.put('isloggedin', 'true');
            $cookies.put('userPIM', response.data.userName);
            $cookies.put('userIdPIM', response.data.Id);
            $cookies.put('token-expire-identity', response.data[".expires"]);
            $cookies.put('logout', false);
            $scope.Setisloggedin();
            apiService.setaccesstoken();
            $scope.iserror = false;
            window.location = "#!/search";
            $scope.loader(false);
        }, function myError(response) {
            if (response.status != 200) {
                $scope.iserror = true;
                $scope.responsemsg = response.data.error_description;
            }
            $scope.loader(false);

        });
    };


}]);

