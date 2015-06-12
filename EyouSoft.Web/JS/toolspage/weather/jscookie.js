/**
 * javascript cookie class
 * @author polar bear
 * @version 0.0.0.1
 * @update 2008-7-30
 *
 */
/**
 * @constructor
 * @example
 一、设置cookie
 var cookie = new JSCookie();
 //普通设置
 cookie .setCookie('key1','val1');
 //过期时间为一年
 var expire_time = new Date();
 expire_time.setFullYear(expire_time.getFullYear() + 1);
 cookie .setCookie('key2','val2',expire_time);
 //设置域及路径，带过期时间
 cookie .setCookie('key3','val3',expire_time,'.cnblogs.com','/');
 //设置带子键的cookie,子键分别是k1,k2,k3
 cookie .setCookie('key4','k1=1&k2=2&k3=3');
 二、读取cookie
 //简单获取
 cookie .getCookie('key1');
 cookie .getCookie('key2');
 cookie .getCookie('key3');
 cookie .getCookie('key4');
 //获取key4的子键k1值
 cookie .getChild('key4','k1');
 三、删除
 cookie .delCookie('key1');
 cookie .delCookie('key2');
 cookie .delCookie('key3');
 cookie .delCookie('key4');
 
 */
var JSCookie=function(){};JSCookie.prototype={trim:function(i){return i.replace(/^\s+|\s+$/g,'')},getCookie:function(O){var o=document.cookie,I=o.split(';'),l='',i='';for(var c=0;c<I.length;c++){i=this.trim(I[c]);if(i.substr(0,O.length)==O){l=i.substr(O.length+1);break}}
return l},getChild:function(l,I){var v=this,c=v.getCookie(l),o=c.split('&'),O='',i='';for(var C=0;C<o.length;C++){i=v.trim(o[C]);if(i.substr(0,I.length)==I){O=i.substr(I.length+1);break}}
return O},setCookie:function(v,c,l,O,C,o){var i='';if(!v||!c){throw new Error('no support cookie key or cookie value');return false}
i+=v+'='+c+';';if(!l||l.constructor!=Date){var I=new Date;I.setFullYear(I.getFullYear()+1);l=I}
i+='expires='+l.toGMTString()+';';if(O){i+='domain='+O+';'}
if(C){i+='path='+C+';'}
o=!!o;if(o){i+='secure=true;'}
document.cookie=i;return i},delCookie:function(l){var I='';var i=new Date;i.setFullYear(i.getFullYear()-1);this.setCookie(l,I,expire)}};var HistoryCookie=function(l,i,I){var o=this;JSCookie.call(o);o.domain=l;o.cookieName=i;o.iLabMax=I||12};HistoryCookie.prototype=new JSCookie;HistoryCookie.prototype.setCookie=function(C,o){var i='',l=this.domain,c='',I=false;var O=new JSCookie;JSCookie.prototype.setCookie(C,o,i,l,c,I)};HistoryCookie.prototype.save=function(C,V){var X=this;var c=new JSCookie;var l=c.getCookie(X.cookieName);l=unescape(l);var o='';o=l.split('||')[1];var I='',O=C+'-'+V,i=[];if(o){i=o.split('|');var v=false;for(var x=0;x<i.length;x++){if(i[x]&&i[x]==O){i.push(i.splice(x,1)[0]);v=true;break}}
if(!v){if(i.length>=X.iLabMax){for(var x=0;x<i.length;x++){if(i.length<X.iLabMax){break}
i.shift()}}
i.push(O)}
I=i.join("|")}else{I=O}
I=X.domain+'||'+I;I=escape(I);X.setCookie(X.cookieName,I)};HistoryCookie.prototype.get=function(){var c=new JSCookie;var o=c.getCookie(this.cookieName);o=unescape(o);var x=o.split('||'),C=x[0],V=x[1]||'',I=V.split('|'),i=[],O='',v='',l=[];for(var X=I.length-1;X>=0;X--){l=I[X].split('-');O=l[0]||'';v=l[1]||'';if(O&&v){i.push({title:O,url:'http:\/\/'+C+v})}}
return i};