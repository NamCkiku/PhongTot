/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Administrator\bower_components/angular/angular.js" />
(function () {
    angular.module('myApp', ['ui.router', 'kendo.directives', 'blockUI', 'ngCkeditor', 'ngTagsInput', 'frapontillo.bootstrap-switch', 'ngSanitize'])
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
            //Info
            .state('infos', {
                url: "/infos",
                parent: 'base',
                templateUrl: "/app/components/info/InfoListView.html",
                controller: "InfoListController"
            })
            .state('infoedit', {
                url: "/infoedit/:id",
                parent: 'base',
                templateUrl: "/app/components/info/InfoEditView.html",
                controller: "InfoEditController"
            })
            //CategoryInfo
            .state('categoryInfo', {
                url: "/categoryInfo",
                parent: 'base',
                templateUrl: "/app/components/categoryInfo/categoryInfoListView.html",
                controller: "categoryInfoListController",
            }).state('categoryInfoAdd', {
                url: "/categoryInfoAdd",
                parent: 'base',
                templateUrl: "/app/components/categoryInfo/categoryInfoAddView.html",
                controller: "categoryInfoAddController",
            }).state('categoryInfoEdit', {
                url: "/categoryInfoEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/categoryInfo/categoryInfoEditView.html",
                controller: "categoryInfoEditController",
            })

            //Post
            .state('post', {
                url: "/post",
                parent: 'base',
                templateUrl: "/app/components/post/PostListView.html",
                controller: "postListController",
            }).state('addpost', {
                url: "/addpost",
                parent: 'base',
                templateUrl: "/app/components/post/PostAddView.html",
                controller: "postAddController",
            })
            //PostCategory
            .state('postcategory', {
                url: "/postcategory",
                parent: 'base',
                templateUrl: "/app/components/postCategory/PostCategoryListView.html",
                controller: "postCategoryListController",
            })
            .state('postcategoryadd', {
                url: "/postcategoryadd",
                parent: 'base',
                templateUrl: "/app/components/postCategory/postCategoryAddView.html",
                controller: "postCategoryAddController",
            })
            //SystemsParameter
            .state('setting', {
                url: "/setting",
                parent: 'base',
                templateUrl: "/app/components/SystemParameter/systemParameterListView.html",
                controller: "systemParameterListController",
            })
            .state('settingedit', {
                url: "/settingedit",
                parent: 'base',
                templateUrl: "/app/components/SystemParameter/systemParameterEditView.html",
                controller: "systemParameterEditController",
            })

            //SystemsParameter
            .state('membership', {
                url: "/membership",
                parent: 'base',
                templateUrl: "/app/components/membershipProfile/membershipProfileListView.html",
                controller: "membershipProfileListController",
            })
            .state('membershipeidt', {
                url: "/membershipeidt/:id",
                parent: 'base',
                templateUrl: "/app/components/membershipProfile/membershipProfileEditView.html",
                controller: "membershipProfileEditController",
            })
            .state('membershipview', {
                url: "/membershipview/:id",
                parent: 'base',
                templateUrl: "/app/components/membershipProfile/membershipProfileView.html",
                controller: "membershipProfileViewController",
            })

            .state('application-groups', {
                url: "/application-groups",
                templateUrl: "/app/components/application_groups/applicationGroupListView.html",
                parent: 'base',
                controller: "applicationGroupListController"
            })
            .state('add-application-group', {
                url: "/add-application-group",
                parent: 'base',
                templateUrl: "/app/components/application_groups/applicationGroupAddView.html",
                controller: "applicationGroupAddController"
            })
            .state('edit-application-group', {
                url: "/edit-application-group/:id",
                templateUrl: "/app/components/application_groups/applicationGroupEditView.html",
                controller: "applicationGroupEditController",
                parent: 'base',
            });
        ;
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