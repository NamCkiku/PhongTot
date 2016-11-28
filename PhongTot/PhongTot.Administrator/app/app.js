/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Administrator\bower_components/angular/angular.js" />
(function () {
    angular.module('myApp', ['ui.router', 'blockUI', 'ngCkeditor', 'ngTagsInput', 'frapontillo.bootstrap-switch'])
        .config(config)
        .config(configAuthentication);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract: true
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"

            }).state('login', {
                url: "/login",
                templateUrl: "/app/components/account/loginView.html",
                controller: "loginController"
            })
            .state('infos', {
                url: "/infos",
                parent: 'base',
                templateUrl: "/app/components/info/InfoListView.html",
                controller: "InfoListController"
            }).state('categoryInfo', {
                url: "/categoryInfo",
                parent: 'base',
                templateUrl: "/app/components/categoryInfo/categoryInfoListView.html",
                controller: "categoryInfoListController",
            }).state('categoryInfoAdd', {
                url: "/categoryInfoAdd",
                parent: 'base',
                templateUrl: "/app/components/categoryInfo/categoryInfoAddView.html",
                controller: "categoryInfoAddController",
            }).state('post', {
                url: "/post",
                parent: 'base',
                templateUrl: "/app/components/post/PostListView.html",
                controller: "postListController",
            }).state('addpost', {
                url: "/addpost",
                parent: 'base',
                templateUrl: "/app/components/post/PostAddView.html",
                controller: "postAddController",
            });
        $urlRouterProvider.otherwise('/login');
    }
    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();