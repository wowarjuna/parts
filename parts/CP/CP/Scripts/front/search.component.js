angular.
  module('search').
  component('search', {
      //templateUrl: '/Scripts/front/search.html',
      templateUrl: function () {
          return '/Scripts/front/search.html?v' + $.now();
      },
      controller: ['$routeParams', function SearchController($routeParams) {

      }
      ]
  });