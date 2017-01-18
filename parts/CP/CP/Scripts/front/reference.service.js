angular.module('reference', ['ngResource']);

angular.
  module('reference').
  factory('reference', ['$resource',    
      function ($resource) {
        return $resource('/Scripts/front/references.json?v=1', {}, { query: {method: "GET", isArray: false}});
    }
  ]);