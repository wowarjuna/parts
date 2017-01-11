angular.
  module('results').
  component('results', {
      templateUrl: '/Scripts/front/results.html',
      controller: ['$routeParams', '$rootScope', '$scope', '$location', 'query', function ResultsController($routeParams, $rootScope, $scope, $location, query) {
                    
          if (query.results != null) {
              $scope.results = query.results.data;
          }

          $rootScope.$on('query-success', function (event, obj) {
              $scope.results = obj.result.data;
          });

          $scope.navigateToDetail = function (id, modelNo, name) {
              $location.path('/detail/' + id + '/' + modelNo + '/' + name);
          }
      }
      ]
  });