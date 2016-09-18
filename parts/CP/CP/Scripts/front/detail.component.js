angular.
  module('detail').
  component('detail', {
      templateUrl: '/Scripts/front/detail.html',
      controller: ['$routeParams', function DetailController($routeParams) {
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
      ]
  });