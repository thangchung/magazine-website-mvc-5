(function () {
    var dashboardController = function ($scope, $location, config) {
        $scope.appTitle = 'Magazine Management :: Dashboard';
    };
    magazinesManager.magazinesApp.controller('DashboardController',
        ['$scope', '$location', 'config', dashboardController]);
}());
