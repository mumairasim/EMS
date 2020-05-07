
//(function (app) {
SMSHO.factory('apiService', ['$http', '$cookies', function ($http, $cookies) {
    "use strict";
    var accesstoken = '';
    var isauthorize = true;
    var unauthorizemsg = '';
    var baseUrl = 'http://localhost:44358/';
    function setaccesstoken() {
        accesstoken = $cookies.get('SMS_token');
    }
    function login(url, datatosend) {
        return $http({
            method: "POST",
            url: baseUrl + url,
            data: datatosend,
            headers: { 'Content-Type': "application/x-www-form-urlencoded" }
        });
    }
    function logout() {
        $cookies.remove('SMS_token');
        $cookies.put('SMS_Isloggedin', false);
        $cookies.put('SMS_logout', true);
        unauthorizemsg = '';
        var isauthorize = true;
    }
    function register(url, datatosend) {
        return $http({
            method: "POST",
            url: baseUrl + url,
            data: JSON.stringify(datatosend),
            headers: {
                'Content-Type': "application/json; charset=utf-8",
                'Authorization': "Bearer " + $cookies.get('SMS_token')
            }
        });
    }
    function masterpost(url, datatosend) {
        return $http({
            method: "POST",
            url: baseUrl + url,
            data: JSON.stringify(datatosend),
            headers: {
                'Content-Type': "application/json; charset=utf-8",
                'Authorization': "Bearer " + $cookies.get('SMS_token'),
                'UserId': $cookies.get('SMS_userId'),
                'UserName': $cookies.get('SMS_user')
            }
        });
    }
    function masterget(url) {
        return $http({
            method: "GET",
            url: baseUrl + url,
            headers: {
                'Content-Type': "application/json; charset=utf-8",
                'Authorization': "Bearer " + $cookies.get('SMS_token'),
                'UserId': $cookies.get('SMS_userId'),
                'UserName': $cookies.get('SMS_user')
            }
        });
    }

    function IsUserAuthorized(data, msg) {
        isauthorize = data;
        unauthorizemsg = msg;

    }
    function authorizationbit() {

        return {
            authorize: isauthorize,
            authorizemsg: unauthorizemsg
        }
    }
    return {
        login: login,
        register: register,
        masterpost: masterpost,
        masterget: masterget,
        logout: logout,
        setaccesstoken: setaccesstoken,
        IsUserAuthorized: IsUserAuthorized,
        authorizationbit: authorizationbit

    };
    //app.factory("apiService", apiService);
    //apiService.$inject = ["$http","$scope"];
}]);