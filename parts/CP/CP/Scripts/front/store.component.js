angular.
  module('store').
  component('store', {
      templateUrl: '/Scripts/front/store.html',
      controller: ['$scope', '$rootScope', '$routeParams', 'storeService', function StoreController($scope, $rootScope, $routeParams, storeService) {
          var self = this;

          storeService.list();
          $rootScope.$on('list-success', function (event, obj) {
              $scope.results = obj.result.data;
          });
      }]
      });