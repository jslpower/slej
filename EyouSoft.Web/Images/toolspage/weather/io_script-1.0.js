/**
 * Bind Method
 */
Function.prototype.Bind = function() { 
	var __m = this, object = arguments[0], args = new Array(); 
	for(var i = 1; i < arguments.length; i++){
		args.push(arguments[i]);
	}
	
	return function() {
		return __m.apply(object, args);
	}
};

var isIE = false;
var userAgent = navigator.userAgent.toLowerCase();
if ((userAgent.indexOf('msie') != -1) && (userAgent.indexOf('opera') == -1)) {
	isIE = true;
}

if(typeof IO == 'undefined' )IO = {};
IO.Script = function(){
	this.Init.apply(this, arguments);
};

/**
*
var requestUrl="http://mark.sina.com.cn/v2/DoData.php?p_mark=cj_news&i_mark=sh600035&type=get";
var jsloader = new  IO.Script();
jsloader.load(requestUrl,function(){alert(success)})

*/
IO.Script.prototype = {
	_scriptCharset: 'gb2312',
	_oScript: null,	
	/**
	 * Constructor
	 * 
	 * @param {Object} opts
	 */
	Init : function(opts){
		this._setOptions(opts);
	},	
	_setOptions: function(opts) {
		if (typeof opts != 'undefined') {
			if (opts['script_charset']) {
				this._scriptCharset = opts['script_charset'];
			}
		}
	},	
	_clearScriptObj: function() {
		if (this._oScript) {
			try {
				this._oScript.onload = null;
				if (this._oScript.onreadystatechange) {
					this._oScript.onreadystatechange = null;
				}
				
				this._oScript.parentNode.removeChild(this._oScript);
				//this._oScript = null;
			} catch (e) {
				// Do nothing here
			}
		}
	},	
	_callbackWrapper: function(callback) {
		if (this._oScript.onreadystatechange) {
			if (this._oScript.readyState != 'loaded' && this._oScript.readyState != 'complete') {
				return;
			}
		}
		
		if (typeof callback != 'undefined') {
			callback();
		}
		
		this._clearScriptObj();
	},	
	load: function(url, callback){
		this._oScript = document.createElement('SCRIPT');
		this._oScript.type = "text/javascript";
		
		if (isIE) {
			this._oScript.onreadystatechange = this._callbackWrapper.Bind(this, callback);
		} else {
			this._oScript.onload = this._callbackWrapper.Bind(this, callback);
		}
		
		this._oScript.charset = this._scriptCharset;
		this._oScript.src = url;
		//document.body.appendChild(this._oScript);
		document.getElementsByTagName('head')[0].appendChild(this._oScript);
	}
};