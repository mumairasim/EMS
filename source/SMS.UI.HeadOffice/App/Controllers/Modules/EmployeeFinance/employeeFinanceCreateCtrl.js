//(function (app) {
//    'use strict';

SMSHO.controller('employeeFinanceCreateCtrl', ['$scope', 'apiService', '$cookies', function ($scope, apiService, $cookies) {
    'use strict';
    var fullDate = new Date();
    $scope.Year = fullDate.getFullYear();

    $scope.Months = [{ value: '0', text: 'January' }, { value: '1', text: 'February' }, { value: '2', text: 'March' },
    { value: '3', text: 'April' }, { value: '4', text: 'May' }, { value: '5', text: 'June' }, { value: '6', text: 'July' },
    { value: '7', text: 'August' }, { value: '8', text: 'September' }, { value: '9', text: 'October' }, { value: '10', text: 'November' }, { value: '11', text: 'December' }];

    $scope.Month = $scope.Months[fullDate.getMonth()];

    $scope.EmployeeFinanceDelete = function () {
        var url = '/api/v1/EmployeeFinance/Delete?id=' + $scope.EmployeeFinanceToDelete;
        var responsedata = apiService.masterdelete(url);
        responsedata.then(function mySucces(response) {
            $scope.response = response.data;
            $scope.growltext("EmployeeFinance deleted successfully.", false);
            window.location.reload();
            $scope.EmployeeFinanceToDelete = 0;
        },
            function myError(response) {
                $scope.response = response.data;
                $scope.growltext("EmployeeFinance deletion failed", true);
                $scope.EmployeeFinanceToDelete = 0;
            });
    };

    $scope.ConfirmDelete = function (id) {
        $scope.EmployeeFinanceToDelete = id;
    };


    $scope.GetSchools = function () {
        var responsedata = apiService.masterget('/api/v1/School/Get');
        responsedata.then(function mySucces(response) {
            $scope.Schools = response.data;
            var temp = {
                Name: '-- Ignore --',
                Id: '0'
            }
            $scope.Schools.unshift(temp);
            $scope.School = $scope.Schools[0];
        },
            function myError(response) {

                $scope.response = response.data;
            });
    };



    $scope.GetFinances = function () {
        var responsedata = apiService.masterget('/api/v1/EmployeeFinance/GetDetailByFilter/' + $scope.School.Id);
        responsedata.then(function mySucces(response) {
            $scope.FinanceList = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };

    $scope.SaveFinances = function () {
        var data = $scope.FinanceList;
        for (var i = 0; i < data.length; i++) {
            data[i].SalaryMonth = $scope.Months[$scope.Month.value].text;
            data[i].SalaryYear = $scope.Year;
        }
        var formData = new FormData();
        formData.append('form', JSON.stringify(data));
        var responsedata = apiService.post('/api/v1/EmployeeFinance/Create', formData);
        responsedata.then(function mySucces(response) {
            $scope.FinanceList = response.data;
        },
            function myError(response) {
                $scope.response = response.data;
            });
    };




    $scope.GetSchools();

}]);

