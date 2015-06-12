<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="EyouSoft.Web.UserControl.Search" %>
<link href="/Css/icore.css" rel="stylesheet" type="text/css" />
<link href="../Css/jquery.autocomplete.jipiao.css" rel="stylesheet" type="text/css" />
<script src="/JS/jquery.tipsy.js" type="text/javascript"></script>

<script src="/JS/jipiao.sanzima.js" type="text/javascript"></script>

<script src="/JS/jipiao.core.js" type="text/javascript"></script>

<script src="/JS/qianzheng.core.js" type="text/javascript"></script>

<script src="/JS/jquery.autocomplete.jipiao.js" type="text/javascript"></script>

<script src="/JS/PageSubmitForm.js" type="text/javascript"></script>

<script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

<script type="text/javascript">
    var instance2 = new PageSubmitForm();
    $(function() {
        ticketLKE.initAutoComplete();

        $("#txtDepCityName").click(function() { ticketLKE.__showDiv({ txtCode: "txtDepCitySanZiMa", txtName: "txtDepCityName", top: 2 }); });

    })
</script>

<div id="n4Tab" class="searchbox margin_T10">
    <div class="TabTitle">
        <ul>
            <li class="active" onclick="nTabs('n4Tab',this);" id="n4Tab_Title0"><a href="javascript:void(0);">
                <s class="hotel"></s><span>酒店</span></a></li>
            <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title1"><a href="javascript:void(0);"><s
                class="jipiao"></s><span>机票</span></a></li>
            <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title2"><a href="javascript:void(0);"><s
                class="menpiao"></s><span>门票</span></a></li>
            <li onclick="nTabs('n4Tab',this);" id="n4Tab_Title3"><a href="javascript:void(0);"><s
                class="zuche"></s><span>租车</span></a></li>
            <li style="border-right: 0;" onclick="nTabs('n4Tab',this);" id="n4Tab_Title4"><a
                href="javascript:void(0);"><s class="qianzhen"></s><span>签证</span></a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="TabContent">
        <div id="n4Tab_Content0">
            <div id="n4Tab1" class="S_line_n4Tab">
                <div class="S-line-TabContent">
                    <div id="n4Tab1_Content0">
                        <div class="userbox">
                            <ul>
                                <li><span class="user-txt">目的地：</span>
                                    <input type="text" name="mudidi" id="mudidi" value="" class="inputbk formsize140" />
                                    <input type="hidden" id="sanzima" name="sanzima" value='' />
                                </li>
                                <li><span class="user-txt">入住日期：</span><span class="date_style formsize140"><input
                                    type="text" name="ruzhuriqi2" id="ruzhuriqi2" value="<%=string.IsNullOrEmpty(Request["ruzhuriqi2"])? DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"):Request["ruzhuriqi2"] %>"
                                    onclick="WdatePicker({readOnly:true,isShowClear:false,onpicked:function(){ var data0=$('#lidianriqi2').val().split('-');var s0=new Date(parseInt(data0[0]),parseInt(data0[1],10)-1,parseInt(data0[2],10)); var data=$('#ruzhuriqi2').val().split('-');var s=new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime();if(s0<=s){s=new Date(s+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1<10?'0'+(s.getMonth()+1):(s.getMonth()+1))+'-'+(s.getDate()<10?'0'+s.getDate():s.getDate());$('#lidianriqi2').val(s);}}});" />
                                    <a href="javascript:;" onclick="instance2.triggerEvent($('#ruzhuriqi2')[0]);">
                                        <img src="/images/rili.gif"></a></span> </li>
                                <li><span class="user-txt">退房日期：</span><span class="date_style formsize140"><input
                                    type="text" name="lidianriqi2" id="lidianriqi2" value="<%=string.IsNullOrEmpty(Request["lidianriqi2"])?DateTime.Now.AddDays(8).ToString("yyyy-MM-dd"):Request["lidianriqi2"] %>"
                                    onclick="var data=$('#ruzhuriqi2').val().split('-');if(data[0]==''){return;};var s = new Date(new Date(parseInt(data[0]),parseInt(data[1],10)-1,parseInt(data[2],10)).getTime()+1000*60*60*24);s=s.getFullYear()+'-'+(s.getMonth()+1)+'-'+s.getDate();WdatePicker({readOnly:true,isShowClear:false,minDate:s})" />
                                    <a href="javascript:;" onclick="instance2.triggerEvent($('#lidianriqi2')[0]);">
                                        <img src="/images/rili.gif"></a></span></li>
                                <li><span class="user-txt">关键词：</span><input type="text" id="mykeyword" name="mykeyword"
                                    class="inputbk formsize140" /></li>
                                <li class="padd">
                                    <input type="button" class="s-btn" value="搜索&gt;&gt;" onclick="location='/hotel.aspx?sanzima='+$('#sanzima').val()+'&ruzhuriqi2='+$('#ruzhuriqi2').val()+'&lidianriqi2='+$('#lidianriqi2').val()+'&mykeyword='+$('#mykeyword').val();" /></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="none" id="n4Tab_Content1">
            <form method="post" onsubmit="return doCheck()">
            <div class="userbox">
                <ul>
                    <li>
                        <label>
                            用户名：</label><input id="Uname" name="Uname" class="formsize140 inputbk" /></li>
                    <li>
                        <label>
                            密&nbsp;&nbsp;&nbsp;&nbsp;码：</label><input id="Passwd" name="Passwd" type="password"
                                class="formsize140 input-style" /></li>
                    <li>
                        <label>
                            验证码：</label><input id="CheckCode" name="CheckCode" class="formsize60 input-style" />
                        <img border="0" src="http://jipiao.slej.cn/ValidateCode.aspx" width="70" height="23" /></li>
                    <li class="font_yellow" style="text-align: center;">公众号：988988 密码：988988</li>
                    <li style="padding-left: 60px;">
                        <input name="image3" type="submit" class="loginbtn" width="73" height="22" value="登录" onclick="javascript:this.form.action='http://jipiao.slej.cn/Login.aspx';" /></li>
                </ul>
            </div>
            </form>
        </div>
        <div class="none" id="n4Tab_Content2">
            <div class="S-line-TabContent">
                <div id="Div1">
                    <div class="userbox">
                        <form id="menpiaoform">
                        <ul>
                            <li><span class="user-txt">省份：</span> <span class="">
                                <select name="ProvinceId2" id="ProvinceId2">
                                </select></span> </li>
                            <li><span class="user-txt">城市：</span><span class=""><select name="CityId2" id="CityId2"></select></span></li>
                            <li><span class="user-txt">名称：</span><span class=""><input type="text" name="JingQuName"
                                id="JingQuName" class="inputbk formsize140"></span></li>
                            <li class="padd">
                                <input type="button" class="s-btn" value="搜索&gt;&gt;" onclick="location='/youhuimenpiao.aspx?'+$('#menpiaoform').serialize();"></li>
                        </ul>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="none" id="n4Tab_Content3">
            <div class="S-line-TabContent">
                <div id="Div3">
                    <div class="userbox">
                        <ul>
                            <li><span class="user-txt">车辆名称：</span>
                            <%--<input type="text" class="inputbk formsize140" id="CarSeaName" name="CarSeaName" />--%>
                            <%=GetCarHtml()%>
                            </li>
                            <li class="padd">
                                <input type="button" value="搜索 >>" class="line-s-btn" id="carseabtn" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="none" id="n4Tab_Content4">
            <div class="S-line-TabContent">
                <div id="Div2">
                    <div class="userbox">
                        <ul>
                            <li><span class="user-txt">签证国家：</span><input type="text" class="inputbk formsize140"
                                id="txtSeaGuoJiaName" name="txtSeaGuoJiaName" />
                                <input type="hidden" id="txtSeaGuoJiaId" name="txtSeaGuoJiaId" value='' />
                            </li>
                            <li><span class="user-txt">签证类型：</span><select id="txtSeaQianZhengLeiXing" name="txtSeaQianZhengLeiXing"
                                class="inputselect">
                                <%=EyouSoft.Common.UtilsCommons.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing)),"","","请选择") %>
                            </select>
                            </li>
                            <li class="padd">
                                <input type="button" value="搜索 >>" class="line-s-btn" id="linSeabtn" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="i_div_qianzhengguojia">
</div>
<div id="i_div_jipiaochengshi">
</div>
<div id="i_div_jipiao_weipipei" class="jipiao_weipiwei">
    没有数据</div>

<script type="text/javascript">
    function nTabs(tabObj, obj) {
        var tabList = document.getElementById(tabObj).getElementsByTagName("li");
        for (i = 0; i < tabList.length; i++) {
            if (tabList[i].id == obj.id) {
                document.getElementById(tabObj + "_Title" + i).className = "active";
                document.getElementById(tabObj + "_Content" + i).style.display = "block";
            } else {
                try {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                } catch (e) { }
            }
        }
    }
    pcToobar.init({ pID: "#ProvinceId2", cID: '#CityId2' });
    var instance = new InitialPageInputTagValue();
    instance.Init();
</script>

<script type="text/javascript">
    var iPage = {
        reload: function() {
            window.location.href = window.location.href;
        }
    };
    $(document).ready(function() {
        qianZhengGuoJia.init({ txtName: 'txtSeaGuoJiaName', txtId: 'txtSeaGuoJiaId', left: 0, top: 4 });
    });

    $(function() {
        $("#linSeabtn").click(function() {
            var guojiaid = $("#txtSeaGuoJiaId").val();
            var visacate = $("#txtSeaQianZhengLeiXing").val();
            window.location.href = "/VisaList.aspx?Guojiaid=" + guojiaid + "&visacate=" + visacate;
            //                window.location.href = "/XianLu.aspx?" + $.param(data);
        })

        $("#carseabtn").click(function() {
            var carid = $("select[name=CarSeaName]").val();
            window.location.href = "/ZuCheXX.aspx?id=" + carid;
            //                window.location.href = "/XianLu.aspx?" + $.param(data);
        })
    });
        
</script>

<script type="text/javascript">
    $(function() {
        ticketLKE.initAutoComplete();

        $("#mudidi").click(function() { ticketLKE.__showDiv({ txtCode: "sanzima", txtName: "mudidi", top: 2 }); });

    })
</script>

