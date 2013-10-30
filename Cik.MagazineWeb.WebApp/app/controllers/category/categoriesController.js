(function () {
    var categoriesController = function ($scope, $location, config) {
        $scope.appTitle = "Category Management";
        $scope.searchText = "";
        $scope.searchCategory = function() {
            alert('searching for ' + $scope.searchText);
        };
        $scope.categories = [
            { id: 1, name: "Sport", description: "This is all things about sporting" },
            { id: 2, name: "Movie", description: "This is all things about movie and film" }
        ];
    };
    magazinesManager.magazinesApp.controller('CategoriesController',
        ['$scope', '$location', 'config', categoriesController]);
}());