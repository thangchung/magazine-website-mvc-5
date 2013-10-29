(function () {
    var categoriesController = function ($scope, $location, config) {
        $scope.appTitle = "Category Management";
    };
    magazinesManager.magazinesApp.controller('CategoriesController',
        ['$scope', '$location', 'config', categoriesController]);
}());