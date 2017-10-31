angular.
  module('results').
  component('results', {
      //templateUrl: '/Scripts/front/results.html',  
      templateUrl: function () {
          return '/Scripts/front/results.html?v=' + $.now();
      },
      controller: ['$routeParams', '$rootScope', '$scope', '$location', 'query', function ResultsController($routeParams, $rootScope, $scope, $location, query) {
          $scope.noRecords = false;          
          if (query.results != null) {
              $scope.results = query.results.data.pager.items;
          }

          $rootScope.$on('query-success', function (event, obj) {
              $scope.results = obj.result.data.pager.items;
              if (obj.result.data.pager.count != 0) {
                  $scope.count = obj.result.data.pager.count;
                  $scope.pagination.current = obj.result.data.pager.page;
                  $scope.noRecords = false;
              } else {
                  $scope.count = 0;
                  $scope.pagination.current = 1;
                  $scope.noRecords = true;
              }

          });

          $scope.navigateToDetail = function (id, modelNo, name) {
              $location.path('/detail/' + id + '/' + modelNo + '/' + encodeURIComponent(name));
          }

          $scope.pagination = {
              current: 1
          };

          $scope.pageChanged = function (newPage) {
              query.query({
                  page: newPage,
                  category: query.filters.category, brand: query.filters.brand,
                  model: query.filters.model,
                  year: query.filters.year,
                  area: query.filters.area,
                  text: query.filters.text
              });
          }

          $scope.count = 0;
      }
      ]
  });