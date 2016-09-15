angular.
  module('query').
  factory('query', function ($rootScope, $http) {
      var query = {};
            
      query.query = function (filters) {
          $http.get('/Search/Query/' + filters.category + '/' + filters.brand + '/' + (filters.model != '' ? filters.model: 'model')  + '/' + filters.year + '/' + (filters.area != '' ? filters.area: 'all')  + '/' + (filters.text != '' ? filters.text : 'criteria') + '/' + $.now()).then(function (response) {
              $rootScope.$broadcast('query-success', { result: response });
          });
          
      }

      return query;
    } 
  );