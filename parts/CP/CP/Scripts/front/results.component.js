angular.
  module('results').
  component('results', {
      templateUrl: '/Scripts/front/results.html',
      controller: ['$routeParams', '$rootScope', '$scope', '$location', 'query', function ResultsController($routeParams, $rootScope, $scope, $location, query) {
          
          $rootScope.$on('query-success', function (event, obj) {
              $scope.results = obj.result.data;
          });

          $scope.navigateToDetail = function (modelNo, name) {
              $location.path('/detail/' + modelNo + '/' + name);
          }
      }
      ]
  });