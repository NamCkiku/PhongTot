/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Administrator\bower_components/angular/angular.js" />
(function () {
    angular.module('myApp', ['ui.router', 'blockUI', 'ngCkeditor', 'ngTagsInput', 'frapontillo.bootstrap-switch']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
        .state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"

        }).state('infos', {
            url: "/infos",
            templateUrl: "/app/components/info/InfoListView.html",
            controller: "InfoListController"
        }).state('post', {
            url: "/post",
            templateUrl: "/app/components/post/PostListView.html",
            controller: "postListController",
        }).state('addpost', {
            url: "/addpost",
            templateUrl: "/app/components/post/PostAddView.html",
            controller: "postAddController",
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();