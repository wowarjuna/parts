angular.
  module('homeSearch').
  component('homeSearch', {
      templateUrl: '/Scripts/front/home-search.html',
      controller: ['$scope', '$routeParams', '$location', function HomeSearchController($scope, $routeParams, $location) {
          $scope.navigateToSearch = function() {
              $location.path('/search');
          }
      }
      ]
  });