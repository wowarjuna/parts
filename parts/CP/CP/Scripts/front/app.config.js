angular.
  module('partbayApp').
  config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix('!');

        $routeProvider.
          when('/home', {
              template: '<home></home>'
          })
          .when('/search', {
              template: '<search></search>'
          })
          .when('/detail/:id/:modelNo/:name', {
              template: '<detail></detail>'
             
          }).
          otherwise('/home');
    }
  ]);