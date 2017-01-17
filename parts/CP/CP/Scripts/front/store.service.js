angular.module('storeService', []);

angular.
  module('storeService').
    factory('storeService', function ($rootScope, $http) {
        var storeService = {};

        storeService.results = null;

        storeService.list = function () {
            $http.get('/home/stores/' + $.now()).then(function (response) {
                storeService.results = response;
                $rootScope.$broadcast('list-success', { result: response });
            });

        }       

        return storeService;
    }
    );