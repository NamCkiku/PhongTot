/// <reference path="E:\_Study\_SourceCode\_SourseGithub\HocOnline\SOEDU\SOEDU.Web\Content/Plugins/angular/angular.js" />
(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', '$location', 'notificationService', 'authenticationService'];

    function apiService($http, $location, notificationService, authenticationService) {
        var serviceBase = 'http://localhost:33029/';
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }
        function del(url, data, success, failure) {
            authenticationService.setHeader();
            $http.delete(serviceBase + url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(serviceBase + url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function put(url, data, success, failure) {
            authenticationService.setHeader();
            $http.put(serviceBase + url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function get(url, params, success, failure) {
            authenticationService.setHeader();
            $http.get(serviceBase + url, params).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is required.');
                }
            });
        }
    }
})(angular.module('myApp'));