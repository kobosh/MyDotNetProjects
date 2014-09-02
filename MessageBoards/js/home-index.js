
/// <reference path="home-index.js" />
//home-index.js
var module = angular.module("homeIndex", ['ngRoute']);
module.config(function ($routeProvider) {
  // $locationProvider.html5Mode(true);
    
 $routeProvider.when ("/", {
        controller: 'topicsController',
       templateUrl: '/templates/topicsView.html'
    });
 $routeProvider.otherwise({ redirect:"/"})   
});
function topicsController($scope, $http)
{

    
    $scope.dataCount = 0;
    $scope.data = [];

    $http.get("/api/v1/topics?includeReplies=true")
    .then(function (result) {
        angular.copy(result.data, $scope.data);
    }, function () { alert(); })
    ;
    


}