angular.
  module('refineSearch').
  component('refineSearch', {
      //templateUrl: '/Scripts/front/refine-search.html',
      templateUrl: function () {
          return '/Scripts/front/refine-search.html?v=' + $.now();
      },
      controller: ['$scope', '$routeParams', 'query', 'reference', function RefineSearchController($scope, $routeParams, query, reference) {
          
          var self = this;
          $scope.text = query.text;
          $scope.brand = typeof query.brand !== 'undefined' ? query.brand : '-1';
          $scope.category = typeof query.category !== 'undefined' ? query.category : '-1';
          $scope.area = typeof query.area !== 'undefined' ? query.area : '-- select area --';
          $scope.year = typeof query.year !== 'undefined' ? query.year : '-1';

          $scope.validCategory = true;
          $scope.validBrand = true;
          $scope.validModel = true;
           
          
          reference.query({}, function (references) {
              $scope.categories = references.categories;
              $scope.brands = references.brands;
              if (typeof $scope.brand !== 'undefined' && $scope.brand != '-1') {
                  $scope.models = _.find($scope.brands, { "d": parseInt($scope.brand) }).m;
                  $scope.model = query.model;
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
                      model: typeof $scope.model !== 'undefined' ? $scope.model : '',
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