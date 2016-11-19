(function (app) {
    app.controller('infoDetailController', infoDetailController);

    infoDetailController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$window', '$timeout'];

    function infoDetailController(apiService, $scope, notificationService, commonService, $window, $timeout) {

        $scope.moreImages = [];


        function getID() {
            var path = $window.location.href;
            var result = String(path).split("/");
            if (result != null && result.length > 0) {
                var id = result[result.length - 1];
                return id;
            }
        }
        //$timeout(function () {
        //    $(".owl-carousel").owlCarousel();
        //});
        
        function InitCarousel() {
            $timeout(function () {
                var sync1 = $("#sync1");
                var sync2 = $("#sync2");
                sync1.owlCarousel({
                    singleItem: true,
                    slideSpeed: 1000,
                    navigation: false,
                    pagination: true,
                    afterAction: syncPosition,
                    responsiveRefreshRate: 200,
                    autoPlay: 10000,
                });
                sync2.owlCarousel({
                    items: 12,
                    itemsDesktop: [1199, 10],
                    itemsDesktopSmall: [979, 10],
                    itemsTablet: [768, 8],
                    itemsMobile: [479, 4],
                    pagination: false,
                    responsiveRefreshRate: 100,
                    afterInit: function (el) {
                        el.find(".owl-item").eq(0).addClass("synced");
                    }
                });
                function syncPosition(el) {
                    var current = this.currentItem;
                    $("#sync2").find(".owl-item").removeClass("synced").eq(current).addClass("synced")
                    if ($("#sync2").data("owlCarousel") !== undefined) { center(current) }
                }
                $("#sync2").on("click", ".owl-item", function (e) {
                    e.preventDefault();
                    var number = $(this).data("owlItem");
                    sync1.trigger("owl.goTo", number);
                });
                function center(number) {
                    var sync2visible = sync2.data("owlCarousel").owl.visibleItems;
                    var num = number;
                    var found = false;
                    for (var i in sync2visible) {
                        if (num === sync2visible[i]) {
                            var found = true;
                        }
                    }
                    if (found === false) {
                        if (num > sync2visible[sync2visible.length - 1]) {
                            sync2.trigger("owl.goTo", num - sync2visible.length + 2)
                        }
                        else {
                            if (num - 1 === -1) {
                                num = 0;
                            }
                            sync2.trigger("owl.goTo", num);
                        }
                    } else if (num === sync2visible[sync2visible.length - 1]) {
                        sync2.trigger("owl.goTo", sync2visible[1])
                    }
                    else if 
                (num === sync2visible[0]) {
                        sync2.trigger("owl.goTo", num - 1)
                    }
                }
            });
        }
        function GetInfoDetail() {
            var id = getID();
            apiService.get('api/info/getbyid/' + id, null, function (result) {
                $scope.infoDetail = result.data;
                $scope.moreImages = JSON.parse($scope.infoDetail.MoreImages);
                $scope.Convenient = JSON.parse($scope.infoDetail.OtherInfo.Convenient);
                console.log($scope.infoDetail);
                console.log($scope.moreImages);
                InitCarousel();
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        GetInfoDetail();
    }

})(angular.module('myApp'));