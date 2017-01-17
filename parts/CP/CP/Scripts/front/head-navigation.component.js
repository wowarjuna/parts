angular.module('headNavigation', ['ngRoute']);

angular.
  module('headNavigation').
  component('headNavigation', {
      templateUrl: '/Scripts/front/head-navigation.html',
      controller: ['$scope', '$routeParams', '$location', function HeadNavigationController($scope, $routeParams, $location) {
          $scope.menu = [{ path: '/home', text: 'Home' }, { path: '/search', text: 'Search' }, { path: '/stores', text: 'Stores' }];
          $scope.path = '/home';
          $scope.$on('$routeChangeStart', function (angularEvent, next, current) {
              if (next.$$route.originalPath == '/detail/:id/:modelNo/:name') {
                  $scope.path = '/search';
              } else {
                  $scope.path = next.$$route.originalPath;
              }
            
          });
      }
      ]
  });