(function (app) {
    'use strict';

    app.directive('owlCarouselDirective', owlCarouselDirective);
    function owlCarouselDirective() {
        return {
            restrict: 'E',
            transclude: false,
            link: function (scope) {
                scope.initCarousel = function (element) {
                    // provide any default options you want
                    var defaultOptions = {
                        singleItem: true,
                        slideSpeed: 1000,
                        navigation: false,
                        pagination: true,
                        afterAction: syncPosition,
                        responsiveRefreshRate: 200,
                        autoPlay: 10000,
                    };
                    var customOptions = scope.$eval($(element).attr('data-options'));
                    // combine the two options objects
                    for (var key in customOptions) {
                        defaultOptions[key] = customOptions[key];
                    }
                    // init carousel
                    $(element).owlCarousel(defaultOptions);
                };
            }
        };
    }
    function owlCarouselItem() {
        return {
            restrict: 'A',
            transclude: false,
            link: function (scope, element) {
                // wait for the last item in the ng-repeat then call init
                if (scope.$last) {
                    scope.initCarousel(element.parent());
                }
            }
        };
    }
})(angular.module('myApp'));