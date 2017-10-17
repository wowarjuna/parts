angular.
  module('refineSearch').
  component('refineSearch', {
      templateUrl: function () {
          return '/Scripts/front/refine-search.html?v=' + $.now();
      },
      controller: ['$scope', '$routeParams', 'query', 'reference', function RefineSearchController($scope, $routeParams, query, reference) {
          
          var self = this;

          $scope.text = query.filters != null ? query.filters.text : '';
          $scope.brand = query.filters != null && typeof query.filters.brand !== 'undefined' ? query.filters.brand : '-1';
          $scope.category = query.filters != null && typeof query.filters.category !== 'undefined' ? query.filters.category : '-1';
          $scope.model = query.filters != null && typeof query.filters.model !== 'undefined' ? query.filters.model : '-1';
          $scope.area = query.filters != null && typeof query.filters.area !== 'undefined' ? query.filters.area : '-- select area --';
          $scope.year = query.filters != null && typeof query.filters.year !== 'undefined' ? query.filters.year : '-1';

          $scope.validCategory = true;
          $scope.validBrand = true; 
          $scope.validModel = true;
           
          
          reference.query({}, function (references) {
              $scope.categories = references.categories;
              $scope.brands = references.brands;
              if (typeof $scope.brand !== 'undefined' && $scope.brand != '-1') {
                  $scope.models = _.find($scope.brands, { "d": parseInt($scope.brand) }).m;
                  $scope.model = query.filters.model;
              }
              $scope.areas = references.areas;

              if ($scope.category != '-1' || (typeof $scope.text !== 'undefined' && $scope.text != '')) {
                  $scope.search();                 
              }
          });

          $scope.search = function () {
              if ($scope.category == '-1') {
                  $scope.validCategory = false;
              } else if ($scope.brand == '-1') {
                  $scope.validBrand = false;
                  $scope.validCategory = true;
              } else if ($scope.model == '') {
                  $scope.validModel = false;
                  $scope.validCategory = true;
                  $scope.validBrand = true;
              } else {
                  $scope.validCategory = true;
                  $scope.validBrand = true;
                  $scope.validModel = true;
                  query.query({
                      page: 1,
                      category: $scope.category, brand: $scope.brand,
                      model: typeof $scope.model !== 'undefined' && $scope.model != -1 ? $scope.model : '',
                      year: typeof $scope.year !== 'undefined' ? $scope.year : -1,
                      area: typeof $scope.area !== 'undefined' && $scope.area != '-- select area --' ? $scope.area : '',
                      text: typeof $scope.text !== 'undefined' ? $scope.text : ''
                  });
              }
          }

          $scope.onBrandChanged = function () {
              $scope.models = _.find($scope.brands, { "d": parseInt($scope.brand) }).m;
          }

         
      }
      ]
  });