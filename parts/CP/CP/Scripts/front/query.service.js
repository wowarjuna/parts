angular.
  module('query').
  factory('query', function ($rootScope, $http) {
      var query = {};

      query.results = null;
      query.filters = null;
            
      query.query = function (filters) {
          query.filters = filters;
          $http.get('/Search/Query/' + filters.page + '/' + filters.category + '/' + filters.brand + '/' + (filters.model != '' ? filters.model : 'model') + '/' + filters.year + '/' + (filters.area != '' ? filters.area : 'all') + '/' + (filters.text != '' ? filters.text : 'criteria') + '/' + $.now()).then(function (response) {
              query.results = response;
              $rootScope.$broadcast('query-success', { result: response });
          });
          
      }

      query.get = function (id) {
          $http.get('/Search/Get/' + id + '/' + $.now()).then(function (response) {
              $rootScope.$broadcast('detail-success', { result: response });
          });
      }

      return query;
    } 
  );