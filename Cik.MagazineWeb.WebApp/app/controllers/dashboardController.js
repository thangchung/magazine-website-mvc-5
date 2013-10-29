(function () {
    var dashboardController = function ($scope, $location, config) {
        $scope.appTitle = 'Magazine Management :: Dashboard';
        $scope.highlight = function(path) {
            return $location.path().substr(0, path.length) == path;
        };
    };
    magazinesManager.magazinesApp.controller('DashboardController',
        ['$scope', '$location', 'config', dashboardController]);
}());
