angular.
  module('homeSearch').
  component('homeSearch', {
      templateUrl: function () { return '/Scripts/front/home-search.html?v=' + $.now() },
      controller: ['$scope', '$routeParams', '$location', 'reference', 'query', function HomeSearchController($scope, $routeParams, $location, reference, query) {

          var self = this;
          $scope.text = '';
          $scope.year = '-1';
          
          reference.query({}, function (references) {
              $scope.brands = references.brands;
              $scope.brand = "-1";
              $scope.categories = references.categories;
              $scope.category = "-1";
              $scope.areas = references.areas;
              $scope.models = ["-- select model --"];
              $scope.model = "-- select model --";
              $scope.area = "-- select area --";
              
          });

          $scope.navigateToSearch = function () {
              query.filters = {
                  text: $scope.text,
                  category: $scope.category,
                  brand: $scope.brand,
                  model: $scope.model,
                  area: $scope.area,
                  year: $scope.year
              };
              
              $location.path('/search');
              
          }

          $scope.onBrandChanged = function () {
              $scope.models = _.find($scope.brands, { "d": parseInt($scope.brand) }).m;              
          }
      }
      ]
  });