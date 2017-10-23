angular.module('headNavigation', ['ngRoute']);

angular.
  module('headNavigation').
  component('headNavigation', {
      templateUrl: '/Scripts/front/head-navigation.html',
      controller: ['$scope', '$routeParams', '$location', function HeadNavigationController($scope, $routeParams, $location) {
          $scope.menu = [{ path: '/home', text: 'Home' }, { path: '/search', text: 'Search' }, { path: '/stores', text: 'Stores' }];
          $scope.path = '/home';
          $scope.$on('$routeChangeStart', function (angularEvent, next, current) {
              if (next.$$route.originalPath == '/detail/:id/:modelNo/:name') {
                  $scope.path = '/search';
              } else {
                  $scope.path = next.$$route.originalPath;
              }
            
          });
      }
      ]
  });
angular.module('home', ['ngRoute']);
angular.
  module('home').
  component('home', {
      templateUrl: '/Scripts/front/home.html',
      controller: ['$routeParams', function HomeController($routeParams) {        
      }
      ]
  });
angular.module('homeSearch', ['ngRoute', 'reference', 'query']);
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
angular.module('search', ['ngRoute']);
angular.module('query', []);
angular.
  module('search').
  component('search', {
      //templateUrl: '/Scripts/front/search.html',
      templateUrl: function () {
          return '/Scripts/front/search.html?v' + $.now();
      },
      controller: ['$routeParams', function SearchController($routeParams) {

      }
      ]
  });
angular.
  module('query').
  factory('query', function ($rootScope, $http) {
      var query = {};

      query.results = null;
      query.filters = null;
            
      query.query = function (filters) {
          query.filters = filters;
          $http.get('/Search/Query/' + filters.page + '/' + filters.category + '/' + filters.brand + '/' + (filters.model != '' ? filters.model : 'model') + '/' + filters.year + '/' + (filters.area != '' ? filters.area : 'all') + '/' + (filters.text != '' ? filters.text : 'criteria') + '/' + $.now()).then(function (response) {
              query.results = response;
              $rootScope.$broadcast('query-success', { result: response });
          });
          
      }

      query.get = function (id) {
          $http.get('/Search/Get/' + id + '/' + $.now()).then(function (response) {
              $rootScope.$broadcast('detail-success', { result: response });
          });
      }

      return query;
    } 
  );
angular.module('reference', ['ngResource']);

angular.
  module('reference').
  factory('reference', ['$resource',    
      function ($resource) {
        return $resource('/Scripts/front/references.json?v=1', {}, { query: {method: "GET", isArray: false}});
    }
  ]);
angular.module('refineSearch', ['ngRoute', 'query', 'reference']);
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
angular.module('results', ['ngRoute', 'query', 'angularUtils.directives.dirPagination']);
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
              $location.path('/detail/' + id + '/' + modelNo + '/' + name);
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
angular.module('detail', ['ngRoute', 'query']);
angular.
  module('detail').
  component('detail', {
      templateUrl: function () {
          return '/Scripts/front/detail.html?v=' + $.now();
      },
      controller: ['$scope', '$rootScope', '$routeParams', 'query', function DetailController($scope, $rootScope, $routeParams, query) {

          var self = this;
          self._galleryCount = 0;

          query.get($routeParams.id);

          $rootScope.$on('detail-success', function (event, obj) {
              var data = obj.result.data;
              $scope.id = data.id;
              $scope.name = data.itemName;
              $scope.description = data.description;
              $scope.images = data.images.length != 0 ? data.images : [{ id: -1, name: 'no-image-available.png' }];
              $scope.phone = data.phone != null ? data.phone.split(",") : 'No phone number';
              $scope.address = data.address != null ? data.address : 'No address sss fsdf dsffsd fsd fsf dd fsdf ssd fdsf';
              $scope.brand = data.brandName; 
              $scope.partNo = data.partNo;
              $scope.model = data.modelName;
              $scope.supplier = data.supplierName;


             
          });

          $scope.galleryInit = function () {
              self._galleryCount++;
              if (self._galleryCount == ($scope.images.length * 2)) {
                  var galleryTop = new Swiper('.gallery-container', {
                      nextButton: '.swiper-button-next',
                      prevButton: '.swiper-button-prev',
                      spaceBetween: 10,
                  });
                  var galleryThumbs = new Swiper('.gallery-thumbs', {
                      spaceBetween: 10,
                      centeredSlides: true,
                      slidesPerView: 'auto',
                      touchRatio: 0.2,
                      slideToClickedSlide: true
                  });
                  galleryTop.params.control = galleryThumbs;
                  galleryThumbs.params.control = galleryTop;
              }
          }

          
      }
      ]
  });
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
angular.module('store', ['ngRoute','storeService']);
angular.
  module('store').
  component('store', {
      //templateUrl: '/Scripts/front/store.html',
      templateUrl: function () {
          return '/Scripts/front/store.html?v=' + $.now();
      },
      controller: ['$scope', '$rootScope', '$routeParams', 'storeService', function StoreController($scope, $rootScope, $routeParams, storeService) {
          var self = this;

          storeService.list();
          $rootScope.$on('list-success', function (event, obj) {
              $scope.results = obj.result.data;
          });
      }]
      });
angular.module('navigation', ['ngRoute']);
angular.
  module('navigation').
  component('navigation', {
      templateUrl: '/Scripts/front/navigation.html',
      controller: ['$scope', '$routeParams', '$location', function NavigationController($scope, $routeParams, $location) {
          $scope.show = false;
          $scope.text = '';
          $scope.$on('$routeChangeStart', function (angularEvent, next, current) {
              if (next.$$route.originalPath == '/search') {
                  $scope.text = 'Search';
                  $scope.show = true;
              }
              else if (next.$$route.originalPath == '/stores') {
                  $scope.text = "Stores";
                  $scope.show = true;
              }
              else {
                  $scope.show = false;
              }
          });
      }
      ]
  });