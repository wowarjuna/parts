angular.
  module('detail').
  component('detail', {
      templateUrl: '/Scripts/front/detail.html',
      controller: ['$scope', '$rootScope', '$routeParams', 'query', function DetailController($scope, $rootScope, $routeParams, query) {

          var self = this;
          self._galleryCount = 0;

          query.get(10);

          $rootScope.$on('detail-success', function (event, obj) {
              $scope.id = obj.result.data.id;
              $scope.name = obj.result.data.name;
              $scope.description = obj.result.data.description;
              $scope.images = obj.result.data.images;
              $scope.phone = obj.result.data.store.phone != null ? obj.result.data.store.phone : 'No phone number';
              $scope.address = obj.result.data.store.address != null ? obj.result.data.store.address : 'No address';

             
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