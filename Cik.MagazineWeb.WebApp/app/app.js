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
            .otherwise({ redirectTo: '/dashboard' });
    }]);
}());