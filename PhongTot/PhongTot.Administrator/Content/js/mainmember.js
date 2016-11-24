$(document).ready(function() {
	 loadGallery(true, 'a.thumbnail');

    

    function loadGallery(setIDs, setClickAttr){
        var current_image,
            selector,
            counter = 0;
        function updateGallery(selector) {
            var $sel = selector;
            current_image = $sel.data('image-id');
            $('#image-gallery-caption').text($sel.data('caption'));
            $('#image-gallery-title').text($sel.data('title'));
            $('#image-gallery-image').attr('src', $sel.data('image'));
            disableButtons(counter, $sel.data('image-id'));
        }

        if(setIDs == true){
            $('[data-image-id]').each(function(){
                counter++;
                $(this).attr('data-image-id',counter);
            });
        }
        $(setClickAttr).on('click',function(){
            updateGallery($(this));
        });
    }
	var flag = false;
	$('.btn-form-search').click(function() {
			 if( flag == false){
			 $('.form-search').css("opacity","1");
					$(this).html('<i class="fa fa-times"></i>');
					$('.form-search').css('top','75px');
			   flag = true;
			} else{
			   $('.form-search').css("opacity","0");
					$(this).html('<i class="fa fa-search"></i>');
					$('.form-search').css('top','50px');
			   flag = false;
			}
				
		});  
		
		$('.btn-form-bar').click(function() {
			 $('.menu-mobile').toggleClass("open-mobile-menu");
		});  
		$('.closebtn').click(function() {
			   $('.menu-mobile').removeClass("open-mobile-menu");
		});  
		
		var owl_sale = $("#owl-sale-product");
			owl_sale.owlCarousel({
				pagination: false,
				loop:true,
				autoplay:true,
				autoplayTimeout:3000,
				autoplayHoverPause:true,
				navigation: false,
				navigationText: false,
				responsive:{
					0:{
						items:1
					},
					600:{
						items:2
					},
					1000:{
						items:3
					}
				}
			});
	   
});

 $(window).scroll(function() {    
    var scroll = $(window).scrollTop();

    if (scroll >= 100) {
        $(".menu-main-top").addClass("sticky");
    } else {
        $(".menu-main-top").removeClass("sticky");
    }
});
//jQuery to collapse the navbar on scroll
$(window).scroll(function() {
    if ($(".navbar").offset().top > 50) {
        $(".navbar-fixed-top").addClass("top-nav-collapse");
    } else {
        $(".navbar-fixed-top").removeClass("top-nav-collapse");
    }
});

//jQuery for page scrolling feature - requires jQuery Easing plugin
$(function() {
    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});
$(document).ready(function() {
    $('.pgwSlideshow').pgwSlideshow();
});
(function(){
  
var counter = 0,
    $items = document.querySelectorAll('.diy-slideshow figure'), 
    numItems = $items.length; 
var showCurrent = function(){
  var itemToShow = Math.abs(counter%numItems);
  [].forEach.call( $items, function(el){
    el.classList.remove('show');
  });
 
  $items[itemToShow].classList.add('show');    
};

document.querySelector('.next').addEventListener('click', function() {
     counter++;
     showCurrent();
  }, false);

document.querySelector('.prev').addEventListener('click', function() {
     counter--;
     showCurrent();
  }, false);
  
})();  
$(document).ready(function(){

   
});