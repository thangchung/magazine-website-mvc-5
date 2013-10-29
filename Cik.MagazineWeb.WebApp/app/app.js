// did some namespaces for the main app
var magazinesManager = {};
magazinesManager.magazinesApp = {};

(function () {
    'use strict';
    magazinesManager.magazinesApp = angular.module('magazinesApp',
        ['ngRoute', 'routeResolverServices']);
    magazinesManager.magazinesApp.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/dashboard', {
                controller: 'DashboardController',
                templateUrl: '/app/views/dashboard.html'
            })
            .when('/categories', {
                controller: 'CategoriesController',
                templateUrl: '/app/views/category/categories.html'
            })
            .when('/items', {
                controller: 'ItemsController',
                templateUrl: '/app/views/item/items.html'
            })
            .otherwise({ redirectTo: '/dashboard' });
    }]);
}());