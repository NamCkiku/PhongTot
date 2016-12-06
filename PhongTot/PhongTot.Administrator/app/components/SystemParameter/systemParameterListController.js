(function (app) {
    app.controller('systemParameterListController', systemParameterListController);
    systemParameterListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function systemParameterListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
    }
})(angular.module('myApp'));