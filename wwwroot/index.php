<?php
 ?>
<!DOCTYPE html>
<html lang="en-US" dir="ltr" class="ipsfocus_backgroundPicker ipsfocus_bg1">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>DIACOLLECTOR</title>

<link href="css/css.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="css/framework.css" media="all">
<link rel="stylesheet" href="css/responsive.css" media="all">
<link rel="stylesheet" href="css/core.css" media="all">
<link rel="stylesheet" href="css/core_responsive.css" media="all">
<link rel="stylesheet" href="css/forums.css" media="all">
<link rel="stylesheet" href="css/forums_responsive.css" media="all">
<link rel="stylesheet" href="css/widgets.css" media="all">
<link rel="stylesheet" href="css/custom.css" media="all">

<script type="text/javascript" src="./index_files/root_library.js.71bfeeb606852e3c7229892d6c931b49.js.download" data-ips=""></script>
<script type="text/javascript" src="./index_files/root_js_lang_1.js.a909bae36960d5713bb1140e50cd608b.js.download" data-ips=""></script>
<script type="text/javascript" src="./index_files/root_framework.js.73846a98d594e4fd7e3218a4bbbb6de7.js.download" data-ips=""></script>
<script type="text/javascript" src="./index_files/global_global_core.js.35a7ced249b42186f5871aa1e748373b.js.download" data-ips=""></script>
<script type="text/javascript" src="./index_files/root_front.js.be6ad0104f051adc06e0fd290964e9c2.js.download" data-ips=""></script>
<script type="text/javascript" src="./index_files/front_front_browse.js.289006ecc6cea133b421f740804a4fc9.js.download" data-ips=""></script>
<script type="text/javascript" src="./index_files/front_front_forum.js.16b6e6a76440030e0ee187f202d10232.js.download" data-ips=""></script>
<script type="text/javascript" src="./index_files/root_map.js.b1582a4a8a513740a5885724e32f671d.js.download" data-ips=""></script>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>

<script type="text/javascript">
$(document).ready(function(){
	//Recent 10
	$.get( "ajax/recent10.php", function( data ) {
  		$( "#recent10" ).html( data );
  		//alert( "Load was performed." );
	});
	
	
	
	var navwrap = $('.fixed-header-wrap');
	var navbar = $('.fixed-header');
  
	$(window).scroll( function() {
		if ($(window).scrollTop() > navwrap.offset().top){
			navbar.addClass('scroll');
		}else{
			navbar.removeClass('scroll');
		}
	} );
 

  

function debounce(func, wait, immediate) {
	var timeout;
	return function() {
		var context = this, args = arguments;
		var later = function() {
			timeout = null;
			if (!immediate) func.apply(context, args);
		};
		var callNow = immediate && !timeout;
		clearTimeout(timeout);
		timeout = setTimeout(later, wait);
		if (callNow) func.apply(context, args);
	};
};

// Bug fix: The resize event is triggered when tablets and mobiles are scrolled, breaking the search bar in Android and Chrome
var cachedDevice = detectDevice();

// Run width functions after 1000ms pause
$(window).resize(debounce(function(){
	var newDevice = detectDevice();
    if(newDevice !== cachedDevice){
        
        resizeWindow();
        relocateSearch();
        
        cachedDevice = newDevice;
    }
}, 1000));
	


// Hide empty divs in ipsPageHeader to prevent unnecessary margins
$('.ipsPageHeader .ipsSpacer_top').each(function(){
    if(!/[\S]/.test($(this).html())) { 
        $(this).hide();
    }
});
      
 

/* Navigation */            
function ipsfocusNavigation() {
	
	var navwidth = 0;
	var morewidth = $('.ipsNavBar_primary .focusNav_more').outerWidth(true);
	$('.ipsNavBar_primary > ul > li:not(.focusNav_more)').each(function() {
		navwidth += $(this).outerWidth( true ) + 2;
	});
	var availablespace = $('.ipsNavBar_primary').outerWidth(true) - morewidth;
	if (availablespace > 0 && navwidth > availablespace) {
		var lastItem = $('.ipsNavBar_primary > ul > li:not(.focusNav_more)').last();
		lastItem.attr('data-width', lastItem.outerWidth(true));
		lastItem.prependTo($('.ipsNavBar_primary .focusNav_more > ul'));
		ipsfocusNavigation();
	} else {
		var firstMoreElement = $('.ipsNavBar_primary li.focusNav_more li').first();
		if (navwidth + firstMoreElement.data('width') < availablespace) {
			firstMoreElement.insertBefore($('.ipsNavBar_primary .focusNav_more'));
		}
	}
	
	if ($('.focusNav_more li').length > 0) {
		$('.focusNav_more').removeClass('focusNav_hidden');
	} else {
		$('.focusNav_more').addClass('focusNav_hidden');
	}
	
}

$(window).on('load',function(){
	$(".ipsNavBar_primary").removeClass("hiddenLinks");
  	ipsfocusNavigation();
});
 
$(window).on('resize',function(){
	ipsfocusNavigation();
});


// Make hover navigation work with touch devices
// http://osvaldas.info/drop-down-navigation-responsive-and-touch-friendly
;(function(e,t,n,r){e.fn.doubleTapToGo=function(r){if(!("ontouchstart"in t)&&!navigator.msMaxTouchPoints&&!navigator.userAgent.toLowerCase().match(/windows phone os 7/i))return false;this.each(function(){var t=false;e(this).on("click",function(n){var r=e(this);if(r[0]!=t[0]){n.preventDefault();t=r}});e(n).on("click touchstart MSPointerDown",function(n){var r=true,i=e(n.target).parents();for(var s=0;s<i.length;s++)if(i[s]==t[0])r=false;if(r)t=false})});return this}})(jQuery,window,document);

$('.ipsNavBar_primary > ul > li:has(ul)').doubleTapToGo();
  

});
</script>
<style type="text/css">

.d3-icon-item {
    background: no-repeat 50% 100%;
    border-radius: 4px;
}

.d3-icon-item-orange {
	background:url(images/affix/orange.png);
    background-color: #332314;
	border-radius:4px;
}

.radius {
	border-radius:4px;
}

.d3-icon-item-green {
	background:url(images/affix/green.png);
    background-color: #332314;
	border-radius:4px;
}


.d3-icon-item {
    box-shadow: 0 0 15px #000;
}

.d3-icon-item .icon-item-gradient {
    border-radius: 4px;
    background-image: -webkit-linear-gradient(top, rgba(0, 0, 0, 0.45), rgba(0, 0, 0, 0));
}

.d3-icon-item-large .icon-item-default {
    width: 64px;
    height: 128px;
}

</style>
		

</head>
<body class="ipsApp Clearfix">
<div id="ipsLayout_header" class="Clearfix">
    <div class="ipsLayout_container Clearfix">
        <header id="header" class="Clearfix">
            <div class="flexColumns">
                <div class="smallColumn">
                    <a href="" id="elSiteTitle" class="logo textLogo">
                        <span>
                            DIACOLLECTOR
                            <span class="logoSlogan">A community driven item repository!</span>
                        </span>
                    </a>
                </div>
            </div>
        </header>
    </div>
    
    <div class="fixed-header-wrap">
        <div class="fixed-header">
            <div class="ipsLayout_container Clearfix">
                <div id="navBar">
                    <div class="Clearfix">
                        <div class="navAlign">
                            <nav class="ipsLayout_container resetWidth">
                                <div class="ipsNavBar_primary  Clearfix">
                                    <ul class="ipsResponsive_showDesktop ipsResponsive_block">
                                        <li class="ipsNavBar" id="elNavSecondary_7">
                                            <a href="">home</a>
                                        </li>
    
                                        <li>
                                            <a href="">Download</a>
                                        </li>
                                        <li>
                                            <a href="">Armor</a>
                                        </li>
                                        <li>
                                            <a href="">Weapons</a>
                                        </li>
                                        <li>
                                            <a href="javascript:void()">Builds 
                                            <i class="fa fa-caret-down"></i>
                                            </a>
    
                                            <ul class="ipsNavBar_secondary ipsHide" data-role="secondaryNavBar">
                                                <li>
                                                    <a href="">In Development!</a>
                                                </li>
                                        </li>
                                    </ul>
                                </div>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>			
</div>
		
<div class="contentWrapper ipsLayout_container">
	<main role="main" id="ipsLayout_body" class="ipsLayout_container">
    	<div class="contentPadding">
            <div class="precontentBlocks">
            
                <!-- Breadcrumbs -->
                <div class="ipsfocus_breadcrumbWrap Clearfix">
                    <nav class="ipsBreadcrumb ipsBreadcrumb_top ipsFaded_withHover">
                        <ul>
                            <a href="">
                                <span itemprop="name">LOGGED IN AS: Home</span>
                            </a>
                        </ul>
                    </nav>
                </div>
            </div>
            
            <div id="ipsLayout_contentArea">
                <div id="ipsLayout_contentWrapper">
                    <div id="ipsLayout_mainArea">
                        
						<section>
							<ol class="ipsList_reset cForumList">
                            
							  <!--// FORUM BEGINING -->
								<li data-categoryid="1" class="cForumRow ipsBox ipsSpacer_bottom ipsfocus_reset">
                                        <div class="ipsfocusBox">
                                        <h2 class="ipsType_sectionTitle ipsType_reset cForumTitle">
                                            <a href="" class="ipsPos_right ipsJS_show ipsType_noUnderline cForumToggle"></a>
                                            Recently Added Items (This will be ajax with a delay in order to prevent server overload)
                                        </h2>
                                        <ol class="ipsDataList ipsDataList_large ipsDataList_zebra ipsAreaBackground_reset" data-role="forums">
											
                             				<div id="recent10"></div>

                                
										</ol>
                                        
								  </div>
							  </li>                       
								<!--// FORUM END -->
                                
						  </ol>
						</section>
                                

						<div class="cWidgetContainer " data-role="widgetReceiver" data-orientation="horizontal" data-widgetarea="footer">
							<ul class="ipsList_reset">
								<li class="ipsWidget ipsWidget_horizontal ipsBox">
									<h3 class="ipsType_reset ipsWidget_title">People Vising Right Now!</h3>
										<div class="ipsWidget_inner">
											<div class="ipsGrid ipsGrid_collapsePhone ipsWidget_stats">
                                                <div class="ipsGrid_span4 ipsType_center">
                                                    <span class="ipsType_large ipsWidget_statsCount">15</span><br>
                                                    <span class="ipsType_light ipsType_medium">Total Members</span>
                                                </div>
                                            <div class="ipsGrid_span4 ipsType_center">
                                                <span class="ipsType_large ipsWidget_statsCount" data-ipstooltip="" title="09/09/2016 02:10  PM">194</span><br>
                                                <span class="ipsType_light ipsType_medium">Most Online</span>
                                            </div>
										</div>
									</div>
                                </li>
							</ul>
						</div>
                        
					</div>
                            

					<div id="ipsLayout_sidebar" class="ipsLayout_sidebarright ">
						<div class="cWidgetContainer ">
							<ul class="ipsList_reset">
				
					
					<li class="ipsWidget ipsWidget_vertical ipsBox" >

	<h3 class="ipsWidget_title ipsType_reset">Topics</h3>

	
		<div class="ipsPad_half ipsWidget_inner">
			<ul class="ipsDataList ipsDataList_reducedSpacing">
				
				
					<li class="ipsDataItem">
						<div class="ipsDataItem_icon ipsPos_top">
							


	<a href="http://ipsfocus.net/4x/index.php?/profile/53-luke/" data-ipshover="" data-ipshover-target="http://ipsfocus.net/4x/index.php?/profile/53-luke/&amp;do=hovercard" class="ipsUserPhoto ipsUserPhoto_tiny" title="Go to Luke&#39;s profile">
		<img src="./index_files/aval.thumb.jpg.2dcf986dc7a7d6c3fc48930c47c4f524.jpg" alt="Luke" itemprop="image">
	</a>

						</div>
						<div class="ipsDataItem_main cWidgetComments">
							<div class="ipsCommentCount ipsPos_right " data-ipstooltip="" title="4 replies">4</div>
							
							<div class="ipsType_break ipsContained">
															
								<a href="http://ipsfocus.net/4x/index.php?/topic/56-light-bulb-question/&amp;do=getNewComment" title="View the topic Light bulb question" class="ipsDataItem_title">Light bulb question</a>
							</div>
							<p class="ipsType_reset ipsType_medium ipsType_blendLinks ipsContained">
								<span>By 
<a href="http://ipsfocus.net/4x/index.php?/profile/53-luke/" data-ipshover="" data-ipshover-target="http://ipsfocus.net/4x/index.php?/profile/53-luke/&amp;do=hovercard&amp;referrer=http%253A%252F%252Fipsfocus.net%252F4x%252F" title="Go to Luke&#39;s profile" class="ipsType_break">Luke</a></span><br>
								<span class="ipsType_light">Started <time datetime="2016-06-18T02:06:16Z" title="06/18/2016 02:06  AM" data-short="Jun 18">June 18</time></span>
							</p>
						</div>
					</li>
				
			</ul>
		</div>
	
</li>
		</ul>
	</div>

	</div>

                        </div>
                    </div>
                  
	            </div> <!-- /contentPadding -->
              
				
                
              
			
			</main>
</div> <!-- /contentWrapper -->
      
<br>
<br>
</body></html>