angular.
  module('query').
  factory('query', function ($rootScope, $http) {
      var query = {};
      
      query.query = function (filters) {
          $http.get('/Search/Query/' + filters.category + '/' + filters.brand + '/' + filters.model + '/' + filters.year + '/' + filters.text).then(function (response) {
              $rootScope.$broadcast('query-success', { result: response });
          });
          
      }

      return query;
    } 
  );