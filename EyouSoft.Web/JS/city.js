
$.CNCN = {
	hover_show : function(control, hideBox){
		$(control).hover(function(){ 
			$(this).find(hideBox).show();
		},function(){ 
			$(this).find(hideBox).hide();
		}) 
	}
}

$.CNCN.hover_show("#change_city", "#citymore");

