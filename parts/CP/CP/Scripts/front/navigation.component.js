angular.
  module('navigation').
  component('navigation', {
      templateUrl: '/Scripts/front/navigation.html',
      controller: ['$scope', '$routeParams', '$location', function NavigationController($scope, $routeParams, $location) {
          $scope.show = false;
          $scope.text = '';
          $scope.$on('$routeChangeStart', function (angularEvent, next, current) {
              if (next.$$route.originalPath == '/search') {
                  $scope.text = 'Search';
                  $scope.show = true;
              }
              else if (next.$$route.originalPath == '/stores') {
                  $scope.text = "Stores";
                  $scope.show = true;
              }
              else {
                  $scope.show = false;
              }
          });
      }
      ]
  });