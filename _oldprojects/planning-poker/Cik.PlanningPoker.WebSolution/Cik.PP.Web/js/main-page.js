/*
 * main-page.js 
 * Controller: Home
 * Action: Index
 */
var module = angular.module("mainPage", []);
module.config(function($routeProvider) {
    $routeProvider.when("/", {
        controller: "gamesController",
        templateUrl: "/templates/gamesView.html"
    });
    
    $routeProvider.when("/gamedetails/:id", {
        controller: "gameDetailsController",
        templateUrl: "/templates/gameDetailsView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

/*
 * Defines the ui-if tag. This removes/adds an element from the dom depending on a condition
 * Originally created by @tigbro, for the @jquery-mobile-angular-adapter
 * https://github.com/tigbro/jquery-mobile-angular-adapter
 * http://plnkr.co/edit/t2Nq57?p=info
 */
module.directive('uiIf', [function () {
    return {
        transclude: 'element',
        priority: 1000,
        terminal: true,
        restrict: 'A',
        compile: function (element, attr, transclude) {
            return function (scope, element, attr) {

                var childElement;
                var childScope;

                scope.$watch(attr['uiIf'], function (newValue) {
                    if (childElement) {
                        childElement.remove();
                        childElement = undefined;
                    }
                    if (childScope) {
                        childScope.$destroy();
                        childScope = undefined;
                    }

                    if (newValue) {
                        childScope = scope.$new();
                        transclude(childScope, function (clone) {
                            childElement = clone;
                            element.after(clone);
                        });
                    }
                });
            };
        }
    };
}]);

// http://jsfiddle.net/zdam/7kLFU/
module.directive('myDataTable', function () {
    return function (scope, element, attrs) {
        // apply DataTable options, use defaults if none specified by user
        var options = {};
        if (attrs.myDataTable.length > 0) {
            options = scope.$eval(attrs.myDataTable);
        } else {
            options = {
                "bStateSave": true,
                "iCookieDuration": 2419200, /* 1 month */
                "bPaginate": false,
                "bLengthChange": false,
                "bFilter": true,
                "bInfo": false,
                "bDestroy": true
            };
        }

        // Tell the dataTables plugin what columns to use
        // We can either derive them from the dom, or use setup from the controller           
        var explicitColumns = [];
        element.find('th').each(function (index, elem) {
            explicitColumns.push($(elem).text());
        });
        if (explicitColumns.length > 0) {
            options["aoColumns"] = explicitColumns;
        } else if (attrs.aoColumns) {
            options["aoColumns"] = scope.$eval(attrs.aoColumns);
        }

        // aoColumnDefs is dataTables way of providing fine control over column config
        if (attrs.aoColumnDefs) {
            options["aoColumnDefs"] = scope.$eval(attrs.aoColumnDefs);
        }

        if (attrs.fnRowCallback) {
            options["fnRowCallback"] = scope.$eval(attrs.fnRowCallback);
        }

        // apply the plugin
        var dataTable = element.dataTable(options);
        
        // watch for any changes to our data, rebuild the DataTable
        scope.$watch(attrs.aaData, function (value) {
            var val = value || null;
            if (val) {
                dataTable.fnClearTable();
                dataTable.fnAddData(scope.$eval(attrs.aaData));
            }
        });
    };
});

function gamesController($scope, $http, $window, $filter) {
    $scope.isBusy = true;
    $scope.newGame = {};
    /* start area for DataTables */
    $scope.myCallback = function(nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        $('td:eq(2)', nRow).bind('click', function() {
            $scope.$apply(function() {
                $scope.someClickHandler(aData);
            });
        });
       
        $('td:eq(1)', nRow).html('<b>' + $scope.dateFilter(aData.created) + '</b>'); // format for created column
        $('td:eq(0)', nRow).html('<a href="/#/gamedetails/' + aData.id + '">' + $scope.dateFilter(aData.name) + '</a>'); // format for name column
        return nRow;
    };

    $scope.someClickHandler = function(info) {
        // $scope.message = 'clicked: ' + info.price;
    };

    $scope.columnDefs = [
        { "mDataProp": "name", "aTargets": [0] },
        { "mDataProp": "created", "aTargets": [1] },
        { "mDataProp": "description", "aTargets": [2] }
    ];

    $scope.overrideOptions = {
        "bStateSave": true,
        "iCookieDuration": 2419200, /* 1 month */
        "bPaginate": true,
        "bLengthChange": false,
        "bFilter": true,
        "bInfo": true,
        "bDestroy": true
    };
    /* end area for DataTables */
    $scope.dateFilter = function(created) {
        return $filter('date')(created, 'medium');
    };

    $scope.data = [];

    $http.get('/api/v1/games')
        .then(function(result) {
            // Successful
            angular.copy(result.data, $scope.data);
        }, function() {
            // Fail
            alert('could not load games');
        })
        .then(function() {
            $scope.isBusy = false;
        });

    $scope.saveNewGame = function() {
        $http.post("/api/v1/games", $scope.newGame)
            .then(function(result) {
                var newGame = result.data;
                $window.location = "/#";
            }, function() {
                alert('Could not save game');
            });
    };
}

function gameDetailsController($scope, $http, $window, $filter, $routeParams) {
    $scope.game = {};
    $scope.newStory = {};
    $scope.showStatusBox = false;
    
    $http.get('/api/v1/games/' + $routeParams.id)
        .then(function (result) {// Successful
  
            $scope.game = result.data;
        }, function () {
            // Fail
            alert('could not load games');
        })
        .then(function () {
            $scope.game.created = $filter('date')($scope.game.created, 'medium'); // format Date
            $scope.isBusy = false;
        });

    $scope.saveNewStory = function() {
        // alert($routeParams.id);
        $scope.newStory.GameId = $routeParams.id;
        $http.post("/api/v1/stories", $scope.newStory)
            .then(function (result) {
                var newStory = result.data;
                $window.location = "/#/gamedetails/" + $routeParams.id;
                // $window.location = "/#";
            }, function () {
                alert('Could not save story');
            });
    };
    
    $scope.removeGame = function () {
        $http.delete("/api/v1/games/delete/" + $routeParams.id)
            .then(function(result) {
                // var newStory = result.data;
                $window.location = "/#";
            }, function() {
                alert('Could not remove story');
            });
    };

    $scope.saveEditGame = function () {
        $http.put("/api/v1/games", $scope.game)
            .then(function (result) {
                $scope.game = result.data;
                $window.location = "/#/gamedetails/" + $routeParams.id;
                $scope.showStatusBox = true;
            }, function () {
                alert('Could not remove story');
            });
    };
}