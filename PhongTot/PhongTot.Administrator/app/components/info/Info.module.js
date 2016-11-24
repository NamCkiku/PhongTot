
(function () {
    angular.module('myApp', ['ui.router']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('infos', {
                url: "/infos",
                templateUrl: "/app/components/info/InfoListView.html",
                controller: "InfoListController"
            });
    }
})();