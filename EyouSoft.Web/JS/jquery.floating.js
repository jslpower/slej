/****************************************************************
*
* 功    能：jQuery扩展-跟随页面滚动的浮动层
* 开    发：汪奇志
* 开发时间：2009-12-03
*
****************************************************************/

(function($) {
    $.fn.floating = function(obj) {
        obj = $.extend({
            //浮动层距顶部距离
            top: 0,
            //浮动层距左侧距离
            left: 0,
            //浮动层距右侧距离
            right: 0,
            //浮动层的宽度
            width: 100,
            //浮动层的高度
            height: 200,
            //浮动层出现位置:left||right
            position: "left"
        }, obj || {});

        var containers = $(this);
        containers.css("display", "block");

        //浮动层样式
        switch (obj.position) {
            case "left":
                //containers.css({ position: "absolute", left: obj.left + "px", top: obj.top + "px", width: obj.width + "px", height: obj.height + "px", overflow: "hidden" });
                containers.css({ position: "absolute", left: obj.left + "px", top: obj.top + "px", width: obj.width + "px", overflow: "hidden" });
                break;
            case "right":
                //containers.css({ position: "absolute", left: "auto", right: obj.right + "px", top: obj.top + "px", width: obj.width + "px", height: obj.height + "px", overflow: "hidden" });
                containers.css({ position: "absolute", left: "auto", right: obj.right + "px", top: obj.top + "px", width: obj.width + "px", overflow: "hidden" });
                break;
        }
        
        //页面滚动时触发事件
        var Timer=null;
        function scrollContainers() {
            //滚动条顶部到网页顶部的距离
            var bodyTop = 0;
            if (typeof window.pageYOffset != 'undefined') {
                bodyTop = window.pageYOffset;
            } else if (typeof document.compatMode != 'undefined' && document.compatMode != 'BackCompat') {
                bodyTop = document.documentElement.scrollTop;
            }
            else if (typeof document.body != 'undefined') {
                bodyTop = document.body.scrollTop;
            }
            //重设浮动层的样式
            if (containers.css("display") != "none") {
                if(bodyTop>0){  
                    var newTop=0; //元素的最新的Top值   
                    var currTop=parseInt(containers.css("top"),10);
                    var IsUp=currTop>parseInt(obj.top)+bodyTop?true:false;
                    var IsEnd=false;
                    if(IsUp){ //滚动条向上
                        IsEnd=currTop-2<parseInt(obj.top,10)+bodyTop?true:false; //是否已经到达预定位置
                        newTop=currTop-2<parseInt(obj.top,10)?obj.top:currTop-2;
                    }
                    else{
                       IsEnd=currTop+2>parseInt(obj.top,10)+bodyTop?true:false; //是否已经到达预定位置
                       newTop=currTop+2<parseInt(obj.top,10)?obj.top:currTop+2; 
                    }
                    containers.css("top",newTop+"px");
                    if(IsEnd){
                        clearTimeout(Timer);
                    }
                    else{
                        Timer=setTimeout(scrollContainers,0);
                    }
                }
                else{
                    containers.css("top", obj.top + bodyTop + "px");
                }
            }
        }

        $(window).scroll(function(){
            clearTimeout(Timer);
            scrollContainers();
        });
        $(document).ready(scrollContainers);
    };
})(jQuery);


/**
* EasyDrag 1.5 - Drag & Drop jQuery Plug-in
*
* Thanks for the community that is helping the improvement
* of this little piece of code.
*
* For usage instructions please visit http://fromvega.com/scripts
*/

(function($){

	// to track if the mouse button is pressed
	var isMouseDown    = false;

	// to track the current element being dragged
	var currentElement = null;

	// callback holders
	var dropCallbacks = {};
	var dragCallbacks = {};
	
	// bubbling status
	var bubblings = {};

	// global position records
	var lastMouseX;
	var lastMouseY;
	var lastElemTop;
	var lastElemLeft;
	
	// track element dragStatus
	var dragStatus = {};	

	// if user is holding any handle or not
	var holdingHandler = false;

	// returns the mouse (cursor) current position
	$.getMousePosition = function(e){
		var posx = 0;
		var posy = 0;

		if (!e) var e = window.event;

		if (e.pageX || e.pageY) {
			posx = e.pageX;
			posy = e.pageY;
		}
		else if (e.clientX || e.clientY) {
			posx = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
			posy = e.clientY + document.body.scrollTop  + document.documentElement.scrollTop;
		}

		return { 'x': posx, 'y': posy };
	};

	// updates the position of the current element being dragged
	$.updatePosition = function(e) {
		var pos = $.getMousePosition(e);

		var spanX = (pos.x - lastMouseX);
		var spanY = (pos.y - lastMouseY);

		$(currentElement).css("top",  (lastElemTop + spanY));
		$(currentElement).css("left", (lastElemLeft + spanX));
	};

	// when the mouse is moved while the mouse button is pressed
	$(document).mousemove(function(e){
		if(isMouseDown && dragStatus[currentElement.id] != 'false'){
			// update the position and call the registered function
			$.updatePosition(e);
			if(dragCallbacks[currentElement.id] != undefined){
				dragCallbacks[currentElement.id](e, currentElement);
			}

			return false;
		}
	});

	// when the mouse button is released
	$(document).mouseup(function(e){
		if(isMouseDown && dragStatus[currentElement.id] != 'false'){
			isMouseDown = false;
			if(dropCallbacks[currentElement.id] != undefined){
				dropCallbacks[currentElement.id](e, currentElement);
			}

			return false;
		}
	});

	// register the function to be called while an element is being dragged
	$.fn.ondrag = function(callback){
		return this.each(function(){
			dragCallbacks[this.id] = callback;
		});
	};

	// register the function to be called when an element is dropped
	$.fn.ondrop = function(callback){
		return this.each(function(){
			dropCallbacks[this.id] = callback;
		});
	};
	
	// disable the dragging feature for the element
	$.fn.dragOff = function(){
		return this.each(function(){
			dragStatus[this.id] = 'off';
		});
	};
	
	// enable the dragging feature for the element
	$.fn.dragOn = function(){
		return this.each(function(){
			dragStatus[this.id] = 'on';
		});
	};
	
	// set a child element as a handler
	$.fn.setHandler = function(handlerId){
		return this.each(function(){
			var draggable = this;
			
			// enable event bubbling so the user can reach the handle
			bubblings[this.id] = true;
			
			// reset cursor style
			$(draggable).css("cursor", "");
			
			// set current drag status
			dragStatus[draggable.id] = "handler";

			// change handle cursor type
			$("#"+handlerId).css("cursor", "pointer");	
			
			// bind event handler
			$("#"+handlerId).mousedown(function(e){
				holdingHandler = true;
				$(draggable).trigger('mousedown', e);
			});
			
			// bind event handler
			$("#"+handlerId).mouseup(function(e){
				holdingHandler = false;
			});
		});
	}

	// set an element as draggable - allowBubbling enables/disables event bubbling
	$.fn.easydrag = function(allowBubbling){

		return this.each(function(){

			// if no id is defined assign a unique one
			if(undefined == this.id || !this.id.length) this.id = "easydrag"+(new Date().getTime());
			
			// save event bubbling status
			bubblings[this.id] = allowBubbling ? true : false;

			// set dragStatus 
			dragStatus[this.id] = "on";
			
			// change the mouse pointer
			$(this).css("cursor", "move");

			// when an element receives a mouse press
			$(this).mousedown(function(e){
				
				// just when "on" or "handler"
				if((dragStatus[this.id] == "off") || (dragStatus[this.id] == "handler" && !holdingHandler))
					return bubblings[this.id];

				// set it as absolute positioned
				$(this).css("position", "absolute");

				// set z-index
				$(this).css("z-index", parseInt( new Date().getTime()/1000 ));

				// update track variables
				isMouseDown    = true;
				currentElement = this;

				// retrieve positioning properties
				var pos    = $.getMousePosition(e);
				lastMouseX = pos.x;
				lastMouseY = pos.y;

				lastElemTop  = this.offsetTop;
				lastElemLeft = this.offsetLeft;

				$.updatePosition(e);

				return bubblings[this.id];
			});
		});
	};

})(jQuery);

(function($){
    $.fn.kxbdMarquee = function(options){
        var opts = $.extend({},$.fn.kxbdMarquee.defaults, options);
        return this.each(function(){
            var $marquee = $(this);//滚动元素容器
            var _scrollObj = $marquee.get(0);//滚动元素容器DOM
            var scrollW = $marquee.width();//滚动元素容器的宽度
            var scrollH = $marquee.height();//滚动元素容器的高度
            var $element = $marquee.children(); //滚动元素
            var $kids = $element.children();//滚动子元素
            var scrollSize=0;//滚动元素尺寸
            var _type = (opts.direction == 'left' || opts.direction == 'right') ? 1:0;//滚动类型，1左右，0上下
            
            //防止滚动子元素比滚动元素宽而取不到实际滚动子元素宽度
            $element.css(_type?'width':'height',10000);
            //获取滚动元素的尺寸
            if (opts.isEqual) {
                scrollSize = $kids[_type?'outerWidth':'outerHeight']() * $kids.length;
            }else{
                $kids.each(function(){
                    scrollSize += $(this)[_type?'outerWidth':'outerHeight']();
                });
            }
            //滚动元素总尺寸小于容器尺寸，不滚动
            if (scrollSize<(_type?scrollW:scrollH)) return; 
            //克隆滚动子元素将其插入到滚动元素后，并设定滚动元素宽度
            $element.append($kids.clone()).css(_type?'width':'height',scrollSize*2);
            
            var numMoved = 0;
            function scrollFunc(){
                var _dir = (opts.direction == 'left' || opts.direction == 'right') ? 'scrollLeft':'scrollTop';
                if (opts.loop > 0) {
                    numMoved+=opts.scrollAmount;
                    if(numMoved>scrollSize*opts.loop){
                        _scrollObj[_dir] = 0;
                        return clearInterval(moveId);
                    } 
                }
                if(opts.direction == 'left' || opts.direction == 'up'){
                    _scrollObj[_dir] +=opts.scrollAmount;
                    if(_scrollObj[_dir]>=scrollSize){
                        _scrollObj[_dir] = 0;
                    }
                }else{
                    _scrollObj[_dir] -=opts.scrollAmount;
                    if(_scrollObj[_dir]<=0){
                        _scrollObj[_dir] = scrollSize;
                    }
                }
            }
            //滚动开始
            var moveId = setInterval(scrollFunc, opts.scrollDelay);
            //鼠标划过停止滚动
            $marquee.hover(
                function(){
                    clearInterval(moveId);
                },
                function(){
                    clearInterval(moveId);
                    moveId = setInterval(scrollFunc, opts.scrollDelay);
                }
            );
            
        });
    };
    $.fn.kxbdMarquee.defaults = {
        isEqual:true,//所有滚动的元素长宽是否相等,true,false
        loop: 0,//循环滚动次数，0时无限
        direction: 'left',//滚动方向，'left','right','up','down'
        scrollAmount:1,//步长
        scrollDelay:20//时长

    };
    $.fn.kxbdMarquee.setDefaults = function(settings) {
        $.extend( $.fn.kxbdMarquee.defaults, settings );
    };
})(jQuery);
var RegExps = function() { };
RegExps.RegInteger = /^[0-9]+$/;
RegExps.isDate = /^\d{4}-\d{1,2}-\d{1,2}$/;
RegExps.isMoney = /^\d+(\.\d+)?$/;