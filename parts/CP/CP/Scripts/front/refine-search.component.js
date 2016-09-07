angular.
  module('refineSearch').
  component('refineSearch', {
      templateUrl: '/Scripts/front/refine-search.html',
      controller: ['$scope', '$routeParams', 'query', 'reference', function RefineSearchController($scope, $routeParams, query, reference) {
          
          var self = this;
          $scope.text = '';
          

          reference.query({}, function (references) {
              $scope.brands = references.brands;
              $scope.selectedBrand = -1;
              $scope.categories = references.categories;
              $scope.area = references.area;
          });

          $scope.search = function () {
              query.query({ category: $scope.category, brand: $scope.selectedBrand, model: $scope.model, year: typeof $scope.year !== 'undefined' ? $scope.year : -1, text: $scope.text });
          }

          $scope.onBrandChanged = function () {
              $scope.models = _.find($scope.brands, { "d": parseInt($scope.selectedBrand) }).m;
          }
      }
      ]
  });