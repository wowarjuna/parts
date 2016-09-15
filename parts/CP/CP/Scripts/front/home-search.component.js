angular.
  module('homeSearch').
  component('homeSearch', {
      templateUrl: '/Scripts/front/home-search.html',
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
              query.text = $scope.text;
              query.category = $scope.category;
              query.brand = $scope.brand;
              query.model = $scope.model;
              query.area = $scope.area;
              query.year = $scope.year;
              $location.path('/search');
              
          }

          $scope.onBrandChanged = function () {
              $scope.models = _.find($scope.brands, { "d": parseInt($scope.brand) }).m;              
          }
      }
      ]
  });