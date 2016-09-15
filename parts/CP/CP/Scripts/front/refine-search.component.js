angular.
  module('refineSearch').
  component('refineSearch', {
      templateUrl: '/Scripts/front/refine-search.html',
      controller: ['$scope', '$routeParams', 'query', 'reference', function RefineSearchController($scope, $routeParams, query, reference) {
          
          var self = this;
          $scope.text = query.text;
          $scope.brand = typeof query.brand !== 'undefined' ? query.brand : '-1';
          $scope.category = typeof query.category !== 'undefined' ? query.category : '-1';
          $scope.area = typeof query.area !== 'undefined' ? query.area : '-- select area --';
          $scope.year = typeof query.year !== 'undefined' ? query.year : '-1';
           
          
          reference.query({}, function (references) {
              $scope.categories = references.categories;
              $scope.brands = references.brands;
              if (typeof $scope.brand !== 'undefined' && $scope.brand != '-1') {
                  $scope.models = _.find($scope.brands, { "d": parseInt($scope.brand) }).m;
                  $scope.model = query.model;
              }
              $scope.areas = references.areas;

              if ($scope.category != '-1' || $scope.text != '') {
                  $scope.search();                 
              }
          });

          $scope.search = function () {
              query.query({
                  category: $scope.category, brand: $scope.brand,
                  model: typeof $scope.model !== 'undefined' ? $scope.model : '',
                  year: typeof $scope.year !== 'undefined' ? $scope.year : -1,
                  area: typeof $scope.area !== 'undefined' && $scope.area != '-- select area --' ? $scope.area : '',
                  text: typeof $scope.text !== 'undefined' ? $scope.text : ''
              });
          }

          $scope.onBrandChanged = function () {
              $scope.models = _.find($scope.brands, { "d": parseInt($scope.brand) }).m;
          }

         
      }
      ]
  });