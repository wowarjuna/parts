angular.
  module('detail').
  component('detail', {
      templateUrl: '/Scripts/front/detail.html',
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
              $scope.phone = data.phone != null ? data.phone : 'No phone number';
              $scope.address = data.address != null ? data.address : 'No address';
              $scope.brand = data.brandName; 
              $scope.partNo = data.partNoi;
              $scope.model = data.modelName;


             
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