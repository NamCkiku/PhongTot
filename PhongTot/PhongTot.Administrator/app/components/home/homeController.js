(function (app) {
    app.controller('homeController', homeController);

    homeController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state'];

    function homeController(apiService, $scope, notificationService, commonService, $state) {
    }


})(angular.module('myApp'));