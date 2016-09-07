angular.
  module('results').
  component('results', {
      templateUrl: '/Scripts/front/results.html',
      controller: ['$routeParams', '$rootScope', 'query', function ResultsController($routeParams, $rootScope, query) {
          $rootScope.$on('query-success', function (event, obj) {
              alert(obj.result);
          });
      }
      ]
  });