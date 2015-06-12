using System;
using System.Collections.Generic;
using System.Web;
using Weixin.Mp.Sdk;
using Weixin.Mp.Sdk.Domain;
using Weixin.Mp.Sdk.Response;
using Weixin.Mp.Sdk.Request;
using Weixin.Mp.Sdk.Util;
using System.Collections;

namespace Eyousoft_yhq.Web.BsendMsg
{
    /// <summary>
    /// 微信方法类
    /// </summary>
    public class WeiXin
    {
        private static string Token = System.Configuration.ConfigurationManager.AppSettings["slejToken"].Trim();
        private static string appId = System.Configuration.ConfigurationManager.AppSettings["slejAppId"].Trim();
        private static string appSecret = System.Configuration.ConfigurationManager.AppSettings["slejAppSecret"].Trim();
        #region 菜单
        /// <summary>
        /// 创建菜单
        /// </summary>
        public static WeiXinResult CreateMenu()
        {
            WeiXinResult rv = new WeiXinResult { IsResult = false, ResultMsg = "系统错误！" };
            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                rv.ResultMsg = "获取令牌环失败";
                return rv;
            }
            else
            {
                Menu menu = new Menu();
                List<Button> button = new List<Weixin.Mp.Sdk.Domain.Button>();
                #region 菜单一 旅游产品
                Button subBtn1 = new Button()
                {
                    key = "tejiamenpiao",
                    name = "特价门票",
                    sub_button = null,
                    type = "view",
                    url = "http://m.slej.cn/JingQu.aspx"
                };
                Button subBtn2 = new Button()
                {
                    key = "zhoubianlvyou",
                    name = "周边旅游",
                    sub_button = null,
                    type = "view",
                    url = "http://m.slej.cn/Line_List.aspx?type=3"

                };
                Button subBtn3 = new Button()
                {
                    key = "guoneilvyou",
                    name = "国内旅游",
                    sub_button = null,
                    type = "view",
                    url = "http://m.slej.cn/Line_List.aspx?type=1"
                };
                Button subBtn4 = new Button()
                {
                    key = "guojilvyou",
                    name = "国际旅游",
                    sub_button = null,
                    type = "view",
                    url = "http://m.slej.cn/Line_List.aspx?type=2"
                };
                Button subBtn5 = new Button()
                 {
                     key = "danduzutuan",
                     name = "单独组团",
                     sub_button = null,
                     type = "view",
                     url = "http://m.slej.cn/ZuTuanIndex.aspx"
                 };
                List<Button> subBtnAll = new List<Button>();
                subBtnAll.Add(subBtn1);
                subBtnAll.Add(subBtn2);
                subBtnAll.Add(subBtn3);
                subBtnAll.Add(subBtn4);
                subBtnAll.Add(subBtn5);

                Button btn = new Button()
                {
                    key = "lvyouchanpin",
                    name = "旅游度假",
                    url = "httpbig",
                    type = "click",
                    sub_button = subBtnAll
                };
                button.Add(btn);

                #endregion
                #region 菜单二 会员中心
                Button Menu2SubBtn1 = new Button()
                {
                    key = "Ejiashangcheng",
                    name = "E家商城",
                    sub_button = null,
                    type = "view",
                    url = "http://m.slej.cn/Mall/Default.aspx"
                };
                Button Menu2SubBtn2 = new Button()
                {
                    key = "jipiaoyuding",
                    name = "机票预订",
                    sub_button = null,
                    type = "view",
                    url = "http://m.slej.cn/Flight/Default.aspx"
                };
                Button Menu2SubBtn3 = new Button()
                {
                    key = "jiudianyuding",
                    name = "酒店预订",
                    sub_button = null,
                    type = "view",
                    url = "http://m.slej.cn/Hotel.aspx"
                };

                Button Menu2SubBtn4 = new Button()
               {
                   key = "qichebaozhu",
                   name = "汽车包租",
                   sub_button = null,
                   type = "view",
                   url = "http://m.slej.cn/CarList.aspx"
               };
                List<Button> subBtnAll2 = new List<Button>();
                subBtnAll2.Add(Menu2SubBtn1);
                subBtnAll2.Add(Menu2SubBtn2);
                subBtnAll2.Add(Menu2SubBtn3);
                subBtnAll2.Add(Menu2SubBtn4);

                btn = new Button()
                {
                    key = "lvyoufuwu",
                    name = "商务差旅",
                    url = "httpbig",
                    type = "click",
                    sub_button = subBtnAll2
                };
                button.Add(btn);

                #endregion
                #region 菜单三 惠旅游
                Button Menu3SubBtn1 = new Button()
                {
                    key = "wodeweidian",
                    name = "我的微店",
                    sub_button = null,
                    type = "click"
                };

                Button Menu3SubBtn2 = new Button()
                {
                    key = "weidianzhongxin",
                    name = "绑定微店",
                    sub_button = null,
                    type = "view",
                    url = "http://m.slej.cn/WinXinBind.aspx"
                };
                Button Menu3SubBtn3 = new Button()
                  {
                      key = "Eebao",
                      name = "E额宝",
                      sub_button = null,
                      type = "view",
                      url = "http://m.slej.cn/EBao.aspx"
                  };
                Button Menu3SubBtn4 = new Button()
                   {
                       key = "huiyuanzhongxin",
                       name = "后台管理",
                       sub_button = null,
                       type = "view",
                       url = "http://m.slej.cn/Member/UserCenter.aspx"
                   };

                List<Button> subBtnAll3 = new List<Button>();
                subBtnAll3.Add(Menu3SubBtn1);
                subBtnAll3.Add(Menu3SubBtn2);
                subBtnAll3.Add(Menu3SubBtn3);
                subBtnAll3.Add(Menu3SubBtn4);
                btn = new Button()
                            {
                                key = "huiyuanfuwu",
                                name = "会员服务",
                                url = "httpbig",
                                type = "click",
                                sub_button = subBtnAll3
                            };
                button.Add(btn);
                #endregion
                menu.button = button;
                MenuGroup mg = new MenuGroup()
                {
                    menu = menu
                };
                string postData = mg.ToJsonString();
                CreateMenuRequest createRequest = new CreateMenuRequest()
                {
                    AccessToken = response.AccessToken.AccessToken,
                    SendData = postData
                };
                CreateMenuResponse createResponse = mpClient.Execute(createRequest);
                if (createResponse.IsError)
                {
                    rv.ResultMsg = "创建菜单失败，错误信息为：" + createResponse.ErrInfo.ErrCode + "-" + createResponse.ErrInfo.ErrMsg;
                    return rv;
                }
                else
                {
                    rv.IsResult = true;
                    rv.ResultMsg = "创建成功";
                    return rv;
                }
            }
        }
        /// <summary>
        /// 取得菜单
        /// </summary>
        /// <returns></returns>
        public static List<Button> GetMenu()
        {
            //取得菜单信息
            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return null;
            }
            else
            {
                GetMenuRequest getRequest = new GetMenuRequest()
                {
                    AccessToken = response.AccessToken.AccessToken
                };
                var getResponse = mpClient.Execute(getRequest);
                if (getResponse.IsError)
                {
                    return null;
                }
                else
                {
                    var m = getResponse.Menu.menu.button;
                    return m;
                }
            }
        }
        #endregion
        #region 事件响应
        public static void MsgHandler()
        {

            var recMsg = MessageHandler.ConvertMsgToObject(Token);  //将消息转换成对象


            if (recMsg == null)
            {
                return;
            }
            else
            {
                IMessageProcessor msgProcessor = new MessageProcessor();  //处理消息
                if (msgProcessor.ProcessMessage(recMsg)) //处理消息
                {
                    return;
                }
            }

        }
        #endregion
        #region 验证
        /// <summary>
        /// 启用开发模式时验证URL方法
        /// </summary>
        /// <returns></returns>
        public static string Auth()
        {
            if (MessageHandler.CheckSignature(Token))
            {
                string rv = HttpContext.Current.Request.QueryString["echostr"];
                return rv;
            }
            else { return ""; }
        }
        #endregion
        #region 获取用户信息
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="OpenId">用户OpenId</param>
        /// <returns></returns>
        public static User GetUserInfo(string OpenId)
        {
            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                return null;
            }

            GetUserInfoRequest request2 = new GetUserInfoRequest()
            {
                AccessToken = response.AccessToken.AccessToken,
                OpenId = OpenId,
            };

            var response2 = mpClient.Execute(request2);
            if (response2.IsError)
            {
                return null;
            }
            else
            {
                return response2.UserInfo;
            }
        }
        /// <summary>
        /// 获取关注者列表
        /// </summary>
        /// <param name="AttentionsList">返回关注的列表</param>
        /// <param name="NextOpenId">超过一万时最后一个关注OPENID</param>
        /// <returns></returns>
        public static WeiXinResult GetAttentions(ref List<string> AttentionsList, string NextOpenId)
        {
            WeiXinResult AttentionsResult = new WeiXinResult();
            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                AttentionsResult.IsResult = false;
                AttentionsResult.ResultMsg = "获取令牌环失败";
                return AttentionsResult;

            }
            string AccessToken = response.AccessToken.AccessToken;
            GetAttentionsRequest request2 = new GetAttentionsRequest()
            {
                AccessToken = AccessToken,
                NextOpenId = NextOpenId
            };

            var response2 = mpClient.Execute(request2);
            if (response2.IsError)
            {
                AttentionsResult.IsResult = false;
                AttentionsResult.ResultMsg = "获取关注者列表失败，错误信息为：" + response2.ErrInfo.ErrCode + "-" + response2.ErrInfo.ErrMsg;
                return AttentionsResult;
            }
            else
            {
                var list = response2.Attentions;
                if (list.total > 0)
                {
                    if (list.data.openid.Count > 0)
                    {
                        AttentionsList.AddRange(list.data.openid);
                        if (list.total > 10000 && !String.IsNullOrEmpty(list.next_openid))//超过一万
                        {
                            return GetAttentions(ref AttentionsList, list.next_openid);
                        }
                        else
                        {
                            // Adpost.Finawin.Utility.ConfigClass.SetConfigKeyValue("next_openid", list.next_openid);
                            AttentionsResult.IsResult = true;
                            AttentionsResult.ResultMsg = "获取关注者列表成功";
                            return AttentionsResult;
                        }
                    }
                    else
                    {
                        AttentionsResult.IsResult = false;
                        AttentionsResult.ResultMsg = "无关注者数据";
                        return AttentionsResult;
                    }
                }
                else
                {
                    AttentionsResult.IsResult = false;
                    AttentionsResult.ResultMsg = "无关注者数据";
                    return AttentionsResult;
                }
            }
        }
        #endregion
    }

    #region 事件处理
    /// <summary>
    /// 消息处理类
    /// </summary>
    public class MessageProcessor : IMessageProcessor
    {
        private static string Token = System.Configuration.ConfigurationManager.AppSettings["slejToken"].Trim();
        private static string appId = System.Configuration.ConfigurationManager.AppSettings["slejAppId"].Trim();
        private static string appSecret = System.Configuration.ConfigurationManager.AppSettings["slejAppSecret"].Trim();

        #region 惠旅游菜单业务处理
        /// <summary>
        /// 菜单点击业务
        /// </summary>
        /// <param name="ToUserName"></param>
        /// <param name="FromUserName"></param>
        /// <param name="EventKey"></param>
        public bool MenuClick(string ToUserName, string FromUserName, string EventKey)
        {
            string msg = "";
            switch (EventKey)
            {
                case "dingdanguanli":
                    return OrderListBind(ToUserName, FromUserName);
                case "wodeweidian"://用户注册绑定
                    return RegisterBind(ToUserName, FromUserName);
                case "chanpinmachaxun"://产品查询
                    msg = "请输入产品微信码";
                    break;
                case "pt2"://贵金属
                    return ProductList(ToUserName, FromUserName, "");
                case "pt1":
                    return ProductList(ToUserName, FromUserName, "");
                case "pt3":
                    return ProductList(ToUserName, FromUserName, "");
                case "pt4":
                    return ProductList(ToUserName, FromUserName, "");
                //case "recommend":
                //    msg = "欢迎给“惠旅游”留言，请回复#ly#+内容，我们会第一时间答复您。";
                //    break;
                default:
                    msg = "未定义菜单!";
                    break;
            }
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(ToUserName, FromUserName, msg);
            return true;
        }
        #region 注册绑定
        /// <summary>
        /// 注册绑定
        /// </summary>
        /// <param name="ToUserName">请求人</param>
        /// <param name="FromUserName">服务号OpenId</param>
        /// <returns></returns>
        private bool RegisterBind(string ToUserName, string FromUserName)
        {


            List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();
            NewsReplyMessageItem NewsPicHeader = new NewsReplyMessageItem();
            NewsPicHeader.Description = "绑定我的微店";
            NewsPicHeader.Url = "http://m.slej.cn/WinXinBind.aspx?OpenId=" + FromUserName;
            //  PicUrl = "http://oa.finawin.cn/APP/Images/Img01.jpg",
            NewsPicHeader.Title = "绑定微店";

            var bangding = new EyouSoft.BLL.WeiXin.BWeiXin().GetModel(FromUserName);
            if (bangding != null)
            {
                NewsPicHeader.Description = "进入我的微店";
                NewsPicHeader.Url = bangding.ShopUrl;
                //  PicUrl = "http://oa.finawin.cn/APP/Images/Img01.jpg",
                NewsPicHeader.Title = "我的微店";
            }

            items.Add(NewsPicHeader);
            NewsReplyMessage replyMsg = new NewsReplyMessage()
           {
               CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
               FromUserName = ToUserName,
               ToUserName = FromUserName,
               Articles = items
           };
            MessageHandler.SendReplyMessage(replyMsg);
            return true;
        }
        #endregion
        #region 账户查询
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <param name="ToUserName">请求人</param>
        /// <param name="FromUserName">服务号OpenId</param>
        /// <returns></returns>
        private bool OrderListBind(string ToUserName, string FromUserName)
        {
            //List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();
            //NewsReplyMessageItem NewsPicHeader = new NewsReplyMessageItem()
            //{
            //    //Description = "注册绑定",
            //    Url = "http://www.4008005216.com/AppPage/weixin/OrdersList.aspx?OpenId=" + FromUserName,
            //    //PicUrl = "http://oa.finawin.cn/APP/Images/Img02.jpg",
            //    Title = "订单管理"
            //};
            //items.Add(NewsPicHeader);
            //NewsReplyMessage replyMsg = new NewsReplyMessage()
            //{
            //    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
            //    FromUserName = ToUserName,
            //    ToUserName = FromUserName,
            //    Articles = items
            //};
            //MessageHandler.SendReplyMessage(replyMsg);
            //MessageHandler.SendTextReplyMessage(ToUserName, FromUserName, "亲！您的问题我不明白，要不您换个问法再试试，我这里只要输入5位产品码就行了。或者您可以进入\"旅游超市\"按分类查询。！(" + ToUserName + "+" + FromUserName + ")");
            return true;
        }
        #endregion
        /// <summary>
        /// 产品码查询
        /// </summary>
        /// <param name="ToUserName">请求人</param>
        /// <param name="FromUserName">服务号OpenId</param>
        /// <returns></returns>
        private bool NewsList(TextReceiveMessage msg, params object[] args)
        {
            string msgWord = msg.Content.ToLower();
            //if (msgWord.StartsWith("h"))
            //{
            //MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "亲！您的问题我不明白，要不您换个问法再试试，我这里只要输入5位产品码就行了。或者您可以进入\"旅游超市\"按分类查询。！");
            //}
            return true;
        }
        /// <summary>
        /// 产品列表
        /// </summary>
        /// <param name="ToUserName">请求人</param>
        /// <param name="FromUserName">服务号OpenId</param>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        private bool ProductList(string ToUserName, string FromUserName, string TypeId)
        {
            List<NewsReplyMessageItem> items = new List<NewsReplyMessageItem>();
            int rowsCount = 0;
            //var list = new Eyousoft_yhq.BLL.Product().GetList(5, 1, ref rowsCount, new Eyousoft_yhq.Model.SerProduct() { PurductType = TypeId });
            //foreach (var model in list)
            //{
            //    string picUrl = "";
            //    //if (!String.IsNullOrEmpty(model.ProductPhoto))
            //    //{
            //    //    string Photo = model.ProductPhoto + "S_" + System.IO.Path.GetFileName(model.ProductPhoto);
            //    //    string file = System.IO.Path.GetFileName(Photo);
            //    //    picUrl = Photo.Substring(0, Photo.Length - file.Length) + "S_" + file;
            //    //}
            //    NewsReplyMessageItem itm = new NewsReplyMessageItem()
            //    {
            //        Description = model.ProductName,
            //        Url = "http://oa.finawin.cn/APP/WeiXin/ProductDetail.aspx?OpenId=" + FromUserName + "&id=" + model.ProductID.ToString(),
            //        PicUrl = picUrl,
            //        Title = model.ProductName
            //    };
            //    items.Add(itm);
            //}
            NewsReplyMessage replyMsg = new NewsReplyMessage()
            {
                CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
                FromUserName = ToUserName,
                ToUserName = FromUserName,
                Articles = null //items
            };
            MessageHandler.SendReplyMessage(replyMsg);
            return true;
        }
        #endregion
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="msg">消息对象</param>
        /// <param name="args">参数（用于具体业务传递参数用）</param>
        /// <returns>是否处理成功</returns>
        public bool ProcessMessage(ReceiveMessageBase msg, params object[] args)
        {


            //TextReplyMessage replyMsg = new TextReplyMessage()
            //{
            //    Content = "您好,您发送的消息类型为：" + msg.GetType().ToString(),
            //    CreateTime = Tools.ConvertDateTimeInt(DateTime.Now),
            //    FromUserName = msg.ToUserName,
            //    ToUserName = msg.FromUserName
            //};



            switch (msg.MsgType)
            {
                case MsgType.UnKnown:
                //return ProcessNotHandlerMsg(msg, args);
                case MsgType.Text:
                ////var baseMsg = msg as TextReceiveMessage;
                ////if (baseMsg.Content.StartsWith("#ly#"))
                ////{
                ////    return ProcessTextMessage(baseMsg, args);
                ////}
                ////else
                ////{
                ////    return NewsList(baseMsg, args);
                ////}
                case MsgType.Image:
                //return ProcessImageMessage(msg as ImageReceiveMessage, args);
                case MsgType.Link:
                //return ProcessLinkMessage(msg as LinkReceiveMessage, args);
                case MsgType.Location:
                //return ProcessLocationMessage(msg as LocationReceiveMessage, args);               
                case MsgType.Video:
                //return ProcessVideoMessage(msg as VideoReceiveMessage, args);
                case MsgType.Voice:
                //return ProcessVoiceMessage(msg as VoiceReceiveMessage, args);
                case MsgType.VoiceResult:
                //return ProcessVoiceMessage(msg as VoiceReceiveMessage, args);
                default:
                    return ProcessNotHandlerMsg(msg, args);
                case MsgType.Event:
                    EventMessage evtMsg = msg as EventMessage;
                    switch (evtMsg.EventType)
                    {
                        case EventType.Click:
                            return ProcessMenuEvent(msg as MenuEventMessage, args);
                        case EventType.Location:
                        //return ProcessUploadLocationEvent(msg as UploadLocationEventMessage, args);
                        case EventType.Scan:
                        //return ProcessScanEvent(msg as ScanEventMessage, args);
                        case EventType.Subscribe:
                            return ProcessSubscribeEvent(msg as SubscribeEventMessage, args);
                        case EventType.UnKnown:
                        //return ProcessNotHandlerMsg(msg, args);
                        case EventType.UnSubscribe:
                            return ProcessUnSubscribeEvent(msg as UnSubscribeEventMessage, args);
                        default:
                            return ProcessNotHandlerMsg(msg, args);
                    }
            }
        }


        /// <summary>
        /// 处理文本消息
        /// </summary>
        /// <param name="msg">消息对象</param>
        /// <param name="args">参数（用于具体业务传递参数用）</param>
        /// <returns>是否处理成功</returns>
        public bool ProcessTextMessage(TextReceiveMessage msg, params object[] args)
        {
            //if (msg.Content.StartsWith("#ly#"))
            //{
            //    var usermodel = WeiXin.GetUserInfo(msg.FromUserName);
            //    if (usermodel != null)
            //    {
            //        new Eyousoft_yhq.BLL.BCustomMsg().Add(new Eyousoft_yhq.Model.CustomMsg()
            //        {
            //            OpenId = msg.FromUserName,
            //            NickName = usermodel.NickName,
            //            Sex = usermodel.Sex,
            //            CommendInfo = msg.Content,
            //            IssueTime = DateTime.Now
            //        });
            //        MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "留言成功！");
            //    }
            //    else
            //    {
            //        MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "获取用户信息失败！" + msg.FromUserName);
            //    }
            //}

            return true;
        }

        /// <summary>
        /// 处理图片消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessImageMessage(ImageReceiveMessage msg, params object[] args)
        {
            try
            {
                // string token = args[0].ToString();
                string token = "";
                IMpClient mpClient = new MpClient();
                AccessTokenGetRequest request = new AccessTokenGetRequest()
                {
                    AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
                };
                AccessTokenGetResponse response = mpClient.Execute(request);
                if (response.IsError)
                {
                    //这里回应1条文本消息，当然您也可以回应其他消息
                    MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您发送了语音消息");
                    return true;
                }
                else
                {
                    token = response.AccessToken.AccessToken;
                    //这里回复一个图片，当然您也可以回复其他类型的消息
                    return MessageHandler.SendImageReplyMessage(token, msg.ToUserName, msg.FromUserName, AppDomain.CurrentDomain.BaseDirectory + "11.jpg");
                }
            }
            catch (Exception ex)
            {
                //这里回应1条文本消息，当然您也可以回应其他消息
                MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "出错了：" + ex.ToString());
                return true;

            }
        }

        /// <summary>
        /// 处理语音消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessVoiceMessage(VoiceReceiveMessage msg, params object[] args)
        {
            string token = "";
            IMpClient mpClient = new MpClient();
            AccessTokenGetRequest request = new AccessTokenGetRequest()
            {
                AppIdInfo = new AppIdInfo() { AppID = appId, AppSecret = appSecret }
            };
            AccessTokenGetResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                //这里回应1条文本消息，当然您也可以回应其他消息
                MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您发送了语音消息");
                return true;
            }
            else
            {
                token = response.AccessToken.AccessToken;
                //这里回复1条语音消息，当然您也可以回复其他类型的信息
                return MessageHandler.SendVoiceReplyMessage(token, msg.ToUserName, msg.FromUserName, AppDomain.CurrentDomain.BaseDirectory + "11.mp3");
            }

        }

        /// <summary>
        /// 处理视频消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessVideoMessage(VideoReceiveMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您发送的视频" + msg.MediaId.ToString() + "-" + msg.ThumbMediaId.ToString());
            return true;
        }

        /// <summary>
        /// 处理地理位置消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessLocationMessage(LocationReceiveMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您的地里位置为：" + msg.Label + "(" + msg.Location_X + "," + msg.Location_Y + ")");
            return true;
        }

        /// <summary>
        /// 处理链接消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessLinkMessage(LinkReceiveMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您发送的是连接信息");
            return true;
        }

        /// <summary>
        /// 处理关注事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessSubscribeEvent(SubscribeEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "改成欢迎使用商旅E家");
            return true;
        }

        /// <summary>
        /// 处理取消关注事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessUnSubscribeEvent(UnSubscribeEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            //MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您触发了取消关注事件，欢迎您下次再光临哦");
            EyouSoft.Security.Membership.UserProvider.Logout();
            return true;
        }

        /// <summary>
        /// 处理扫描二维码关注事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessScanSubscribeEvent(ScanSubscribeEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您扫描了我们的二维码关注我们");
            return true;
        }

        /// <summary>
        /// 处理扫描二维码事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessScanEvent(ScanEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您扫描了我们的二维码");
            return true;
        }

        /// <summary>
        /// 处理上报地理位置事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessUploadLocationEvent(UploadLocationEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您的地里位置为：" + msg.Latitude + "-" + msg.Longitude);
            return true;
        }

        /// <summary>
        /// 处理自定义菜单事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessMenuEvent(MenuEventMessage msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            //MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, "您触发了自定义事件" + msg.EventKey.ToString());
            MenuClick(msg.ToUserName, msg.FromUserName, msg.EventKey.ToString());
            return true;
        }

        /// <summary>
        /// 处理未定义处理方法消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ProcessNotHandlerMsg(ReceiveMessageBase msg, params object[] args)
        {
            //这里回应1条文本消息，当然您也可以回应其他消息
            //MessageHandler.SendTextReplyMessage(msg.ToUserName, msg.FromUserName, msg.MsgType.ToString() + " 类型的消息");
            return true;
        }
    }
    #endregion
    #region 结果
    /// <summary>
    /// 微信结果
    /// </summary>
    public class WeiXinResult
    {
        public WeiXinResult() { }
        /// <summary>
        /// 结果 true:成功, false:失败
        /// </summary>
        public bool IsResult { get; set; }
        /// <summary>
        /// 结果消息
        /// </summary>
        public string ResultMsg { get; set; }
    }
    #endregion



}
