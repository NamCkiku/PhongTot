(function (app) {
    app.controller('membershipProfileListController', membershipProfileListController);
    membershipProfileListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function membershipProfileListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.membership = [];
        $scope.data = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.filter = {
            Keywords: "",
            Status: true
        }
        $scope.Search = Search;
        function Search() {
            getAllMembership();
        }
        function getAllMembership(page) {
            var myBlockUI = blockUI.instances.get('myBlockUI');
            myBlockUI.start();
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 10,
                    Keywords: $scope.filter.Keywords,
                    Status: $scope.filter.Status
                }
            }
            apiService.get('api/applicationUser/getlistpaging', config, function (result) {
                $scope.data = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                if ($scope.filterExpression && $scope.filterExpression.length) {
                    notificationService.displayInfo(result.data.Items.length + ' items found');
                }
                $timeout(function (result) {
                    // Stop the block after some async operation.
                    myBlockUI.stop();
                }, 100);
            }, function () {
                notificationService.displayError(response.data);
            });
        }
        getAllMembership();
    }
})(angular.module('myApp'));