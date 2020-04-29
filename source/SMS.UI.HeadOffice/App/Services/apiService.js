
//(function (app) {
SMSHO.factory('apiService', ['$http', '$cookies', function ($http, $cookies) {
    "use strict";
    var accesstoken = '';
    var isauthorize = true;
    var unauthorizemsg = '';
    function setaccesstoken() {
        accesstoken = $cookies.get('token');
    }
    function login(url, datatosend) {
        return $http({
            method: "POST",
            url: url,
            data: datatosend,
            headers: { 'Content-Type': "application/x-www-form-urlencoded" }
        })
    }
    function logout() {
        $cookies.remove('token');
        $cookies.put('isloggedin', false);
        $cookies.put('logout', true);
        unauthorizemsg = '';
        var isauthorize = true;
    }
    function register(url, datatosend) {
        return $http({
            method: "POST",
            url: url,
            data: JSON.stringify(datatosend),
            headers: {
                'Content-Type': "application/json; charset=utf-8",
                'Authorization': "Bearer " + $cookies.get('token')
            }
        })
    }
    function masterpost(url, datatosend) {
        return $http({
            method: "POST",
            url: url,
            data: JSON.stringify(datatosend),
            headers: {
                'Content-Type': "application/json; charset=utf-8",
                'Authorization': "Bearer " + $cookies.get('token'),
                'UserId': $cookies.get('userIdPIM'),
                'UserName': $cookies.get('userPIM'),
            }
        })
    }
    function editBook(url, datatosend) {
        return $http({
            method: "POST",
            url: url,
            data: datatosend,
            headers: {
                'Content-Type': undefined,
                'Authorization': "Bearer " + $cookies.get('token'),
                'UserId': $cookies.get('userIdPIM'),
                'UserName': $cookies.get('userPIM'),
            }
        })
    }
    function masterget(url) {
        return $http({
            method: "GET",
            url: url,
            headers: {
                'Content-Type': "application/json; charset=utf-8",
                'Authorization': "Bearer " + $cookies.get('token'),
                'UserId': $cookies.get('userIdPIM'),
                'UserName': $cookies.get('userPIM'),
            }
        })
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
        authorizationbit: authorizationbit,
        editBook: editBook

    };
    //app.factory("apiService", apiService);
    //apiService.$inject = ["$http","$scope"];
}]);