angular.
  module('navigation').
  component('navigation', {
      templateUrl: '/Scripts/front/navigation.html',
      controller: ['$scope', '$routeParams', '$location', function NavigationController($scope, $routeParams, $location) {
          $scope.show = false;
          $scope.$on('$routeChangeStart', function (angularEvent, next, current) {
              if (next.$$route.originalPath == '/search') {
                  $scope.show = true;
              } else {
                  $scope.show = false;
              }
          });
      }
      ]
  });