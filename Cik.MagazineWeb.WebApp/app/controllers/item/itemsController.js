(function () {
    var itemsController = function ($scope, $location, config) {
        $scope.appTitle = "Item Management";
    };
    magazinesManager.magazinesApp.controller('ItemsController',
        ['$scope', '$location', 'config', itemsController]);
}());