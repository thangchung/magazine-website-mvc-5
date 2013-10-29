(function () {
    var navbarController = function ($scope, $location, config) {
        $scope.highlight = function(path) {
            return $location.path().substr(0, path.length) == path;
        };
    };
    magazinesManager.magazinesApp.controller('NavbarController',
        ['$scope', '$location', 'config', navbarController]);
}());
