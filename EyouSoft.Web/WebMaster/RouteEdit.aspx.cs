using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Common;
using System.Collections.Generic;
using EyouSoft.Model.XianLuStructure;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 创建人：刘飞
    /// 时间：２０１３年３月１6号
    /// 描述：线路产品新增、修改
    /// </summary>
    public partial class RouteEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected int LeaveProvinceId = 0;
        protected int LeaveCityId = 0;
        protected int EndProvinceId = 0;
        protected int EndCityId = 0;
        protected string themeStr = string.Empty;
        protected string routeStatus = string.Empty;
        protected string RouteArea = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string doType = Utils.GetQueryStringValue("doType");
            string type = Utils.GetQueryStringValue("type");
            //获得操作ID
            string id = Utils.GetQueryStringValue("id");
            //权限验证
            // PowerControl(doType);
            #region 处理AJAX请求
            //获取ajax请求
            //存在ajax请求

            switch (type)
            {
                case "save":
                    Response.Clear();
                    Response.Write(PageSave(id, doType));
                    Response.End();
                    break;
            }

            #endregion

            if (!IsPostBack)
            {
                //根据ID初始化页面
                PageInit(id, doType);
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dotype"></param>
        private void PageInit(string id, string dotype)
        {
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            if (!t)
            {
                EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
                MXianLuInfo model = bll.GetInfo(id);
                if (model != null)
                {
                    if (model.ZhuTis != null)
                    {
                        themeStr = BindRouteTheme(model.ZhuTis);
                        routeStatus = BindRouteStatus(model.ZhuangTais);
                    }
                    if (model.FuWu != null)
                    {
                        this.txtchildplan.Text = model.FuWu.ErTongAnPai;
                        this.txtNoproject.Text = model.FuWu.BuHanXiangMu;
                        this.txtnotice.Text = model.FuWu.ZhuYiShiXiang;
                        this.txttip.Text = model.FuWu.WenXinTiXing;
                        this.txtshopping.Text = model.FuWu.GouWuAnPai;
                        this.txtserver.Text = model.FuWu.FuWuBiaoZhun;
                        this.txtselfproject.Text = model.FuWu.ZiFeiXiangMu;
                        this.txtxuzhi.Text = model.FuWu.BaoMingXuZhi;
                        this.txtzengsong.Text = model.FuWu.ZengSongXiangMu;
                        this.txtqita.Text = model.FuWu.QiTaShiXiang;
                    }
                    this.txtcollecttype.Text = model.JiHeFangShi;
                    this.txtContactMobile.Text = model.LxrMobile;
                    this.txtContactName.Text = model.LxrName;
                    this.txtContactQQ.Text = model.LxrQQ;
                    this.txtContactTel.Text = model.LxrTelephone;
                    this.txtdays.Text = model.TianShu.ToString();
                    this.txtendtraffic.Text = model.FanChengJiaoTong;
                    //this.txtguanzhudu.Text = model.GuanZhuShu.ToString();
                    this.txtJieadultprice.Text = model.JSJCR.ToString("f2");
                    this.txtJiechlidprice.Text = model.JSJET.ToString("f2");
                    this.txtleavetraffic.Text = model.ChuFaJiaoTong;
                    this.txtPlanCount.Text = model.JiHuaRenShu.ToString();
                    this.txtRouteDesc.Text = model.TeSe;
                    this.txtRouteName.Text = model.RouteName;
                    this.txtShiadultprice.Text = model.SCJCR.ToString("f2");
                    this.txtShichildprice.Text = model.SCJET.ToString("f2");
                    this.txtTiqiandays.Text = model.TingTianShu.ToString();
                    LeaveCityId = model.DepCityId;
                    hidleavecityid.Value = model.DepCityId.ToString();
                    LeaveProvinceId = model.DepProvinceId;
                    hidleaveproid.Value = model.DepProvinceId.ToString();
                    EndCityId = model.ArrCityId;
                    hidendcityid.Value = model.ArrCityId.ToString();
                    EndProvinceId = model.ArrProvinceId;
                    hidendproid.Value = model.ArrProvinceId.ToString();

                    this.hidroutearea.Value = model.AreaId.ToString();
                    if (model.XingChengs != null && model.XingChengs.Count > 0)
                    {
                        Journey1.SetPlanList = model.XingChengs;
                    }
                    if (model.TeSeFiles != null && model.TeSeFiles.Count > 0)
                    {
                        StringBuilder uploadstr = new StringBuilder();
                        uploadstr.AppendFormat("<img height='75' width='100' alt='' class='addpic img' style='vertical-align:bottom' src='{0}' /><span style='vertical-align: bottom;'><img alt='' class='pand4' style='vertical-align: bottom;' onclick=\"RouteEdit.DelImg(this)\" src='/images/webmaster/cha.gif' /><input type='hidden' name='hideimg' value='|{0}' /></span>", model.TeSeFiles[0].FilePath);
                        this.lbUploadInfo.Text = uploadstr.ToString();
                    }
                    if (model.Tours != null && model.Tours.Count > 0)
                    {
                        StringBuilder strtours = new StringBuilder();
                        StringBuilder strdate = new StringBuilder();
                        for (int i = 0; i < model.Tours.Count; i++)
                        {
                            if (i > 0 && i % 7 == 0)
                            {
                                strtours.Append("<br />");
                            }
                            if (i == model.Tours.Count - 1)
                            {
                                strtours.Append(model.Tours[i].LDate.ToString("yyyy-MM-dd"));
                                strdate.Append(model.Tours[i].LDate.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                strtours.Append(model.Tours[i].LDate.ToString("yyyy-MM-dd") + ",");
                                strdate.Append(model.Tours[i].LDate.ToString("yyyy-MM-dd") + ",");
                            }
                        }
                        this.hideLeaveDate.Value = strdate.ToString();
                        this.lblLeaveDate.Text = strtours.ToString();
                    }
                    if (model.QianZhengFilePath != "")
                    {
                        StringBuilder strqianzheng = new StringBuilder();
                        strqianzheng.AppendFormat("<span class='upload_filename'><a href='/CommonPage/FileDownLoad.aspx?doType=downLoad&filePath={0}&name={1}' target='_blank'>{1}</a><a href=\"javascript:void(0)\" onclick=\"RouteEdit.DelFile(this)\" title='删除附件'><img style='vertical-align:middle' src='/images/webmaster/cha.gif'></a><input type=\"hidden\" name=\"hideFileInfo\" value='{1}|{0}'/></span>", model.QianZhengFilePath, model.QianZheng);
                        this.lbqianzheng.Text = strqianzheng.ToString();
                    }
                    GetRouteArea(model.AreaId);
                }
            }
            else
            {
                themeStr = BindRouteTheme(null);
                routeStatus = BindRouteStatus(null);
                GetRouteArea(0);
                GetDefaultUserInfo();
            }
        }
        /// <summary>
        /// 发布线路时默认调用当前帐号信息
        /// </summary>
        private void GetDefaultUserInfo()
        {
            var model = new BLL.OtherStructure.BWebmaster().GetModel(UserInfo.UserId);

            if (model == null) return;

            this.txtContactMobile.Text = model.Mobile;
            this.txtContactName.Text = model.Realname;
            this.txtContactTel.Text = model.Telephone;
            this.txtContactQQ.Text = model.Fax;//传真保存的是QQ的信息。
        }

        /// <summary>
        /// 获取线路区域
        /// </summary>
        /// <param name="areaname">区域名称</param>
        private void GetRouteArea(int areaid)
        {
            StringBuilder str = new StringBuilder();
            EyouSoft.BLL.OtherStructure.BSysAreaInfo bll = new EyouSoft.BLL.OtherStructure.BSysAreaInfo();
            IList<EyouSoft.Model.MSysArea> AreaList = bll.GetSysAreaList(0, new EyouSoft.Model.MSysArea { ID = 0 });
            str.Append("<option value='-1'>请选择</option>");
            if (AreaList != null && AreaList.Count > 0)
            {
                for (int i = 0; i < AreaList.Count; i++)
                {
                    if (areaid == AreaList[i].ID)
                    {
                        str.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", AreaList[i].ID, AreaList[i].AreaName);
                    }
                    else
                    {
                        str.AppendFormat("<option value='{0}'>{1}</option>", AreaList[i].ID, AreaList[i].AreaName);
                    }
                }
            }
            RouteArea = str.ToString();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="totype"></param>
        /// <returns></returns>
        private string PageSave(string id, string dotype)
        {
            //t为true 新增，false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            string msg = string.Empty;

            #region 获取表单
            //儿童安排
            string childplan = Utils.GetFormValue(txtchildplan.UniqueID);
            string contactmobile = Utils.GetFormValue(txtContactMobile.UniqueID);
            string contactname = Utils.GetFormValue(txtContactName.UniqueID);
            string contactqq = Utils.GetFormValue(txtContactQQ.UniqueID);
            string contacttel = Utils.GetFormValue(txtContactTel.UniqueID);
            int days = Utils.GetInt(Utils.GetFormValue(txtdays.UniqueID));
            string endtraffic = Utils.GetFormValue(txtendtraffic.UniqueID);
            //string guanzhudu = Utils.GetFormValue(txtguanzhudu.UniqueID);
            decimal jieadultprice = Utils.GetDecimal(Utils.GetFormValue(txtJieadultprice.UniqueID));
            decimal jiechildprice = Utils.GetDecimal(Utils.GetFormValue(txtJiechlidprice.UniqueID));

            int leaveprovinceid = Utils.GetInt(Utils.GetFormValue(hidleaveproid.UniqueID));
            int leavecityid = Utils.GetInt(Utils.GetFormValue(hidleavecityid.UniqueID));
            int endprovinceid = Utils.GetInt(Utils.GetFormValue(hidendproid.UniqueID));
            int endcityid = Utils.GetInt(Utils.GetFormValue(hidendcityid.UniqueID));

            string leavetraffic = Utils.GetFormValue(txtleavetraffic.UniqueID);
            string noproject = Utils.GetFormValue(txtNoproject.UniqueID);
            string notice = Utils.GetFormValue(txtnotice.UniqueID);
            int PlanCount = Utils.GetInt(Utils.GetFormValue(txtPlanCount.UniqueID));
            string routedesc = Request.Form[this.txtRouteDesc.UniqueID];
            string routename = Utils.GetFormValue(txtRouteName.UniqueID);
            string selfproject = Utils.GetFormValue(txtselfproject.UniqueID);
            string server = Utils.GetFormValue(txtserver.UniqueID);
            decimal shiadultprice = Utils.GetDecimal(Utils.GetFormValue(txtShiadultprice.UniqueID));
            decimal shichildprice = Utils.GetDecimal(Utils.GetFormValue(txtShichildprice.UniqueID));
            string shopping = Utils.GetFormValue(txtshopping.UniqueID);
            string tip = Utils.GetFormValue(txttip.UniqueID);
            int tiqiandays = Utils.GetInt(Utils.GetFormValue(txtTiqiandays.UniqueID));
            string xuzhi = Utils.GetFormValue(txtxuzhi.UniqueID);
            string zengsong = Utils.GetFormValue(txtzengsong.UniqueID);
            string qita = Utils.GetFormValue(txtqita.UniqueID);
            string collecttype = Utils.GetFormValue(txtcollecttype.UniqueID);
            string[] leaveDateBegin = Utils.GetFormValue(this.hideLeaveDate.UniqueID).Split(',');
            string routearea = Utils.GetFormValue(this.hidroutearea.UniqueID);
            string tujing = Utils.GetFormValue(this.txtTujing.UniqueID);

            #endregion

            #region 实体赋值

            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            EyouSoft.Model.XianLuStructure.MXianLuInfo modelroute = new EyouSoft.Model.XianLuStructure.MXianLuInfo();
            if (routearea == "-1")
            {
                return Utils.AjaxReturnJson("0", "请选择线路区域");
            }
            modelroute.AreaId = Utils.GetInt(routearea.Trim());
            modelroute.ArrCityId = endcityid;
            modelroute.ArrProvinceId = endprovinceid;
            modelroute.ChuFaJiaoTong = leavetraffic;
            modelroute.DepCityId = leavecityid;
            modelroute.DepProvinceId = leaveprovinceid;
            modelroute.FanChengJiaoTong = endtraffic;
            modelroute.FuWu = new EyouSoft.Model.XianLuStructure.MXianLuFuWuInfo
            {
                BaoMingXuZhi = xuzhi,
                BuHanXiangMu = noproject,
                ErTongAnPai = childplan,
                FuWuBiaoZhun = server,
                GouWuAnPai = shopping,
                WenXinTiXing = tip,
                ZhuYiShiXiang = notice,
                ZiFeiXiangMu = selfproject,
                ZengSongXiangMu = zengsong,
                QiTaShiXiang = qita
            };
            //modelroute.GuanZhuShu = Utils.GetInt(guanzhudu);
            modelroute.JiHeFangShi = collecttype;
            modelroute.JiHuaRenShu = PlanCount;
            modelroute.JSJCR = jieadultprice;
            modelroute.JSJET = jiechildprice;
            modelroute.LxrMobile = contactmobile;
            modelroute.LxrName = contactname;
            modelroute.LxrQQ = contactqq;
            modelroute.LxrTelephone = contacttel;
            modelroute.OperatorId = this.UserInfo.UserId;
            modelroute.RouteName = routename;
            modelroute.SCJCR = shiadultprice;
            modelroute.SCJET = shichildprice;
            modelroute.TeSe = routedesc;
            modelroute.TianShu = days;
            modelroute.TingTianShu = tiqiandays;
            modelroute.TuJing = tujing;

            //行程集合
            modelroute.XingChengs = GetPlanList();
            //线路状态
            modelroute.ZhuangTais = GetRouteStatus();
            //线路主题
            modelroute.ZhuTis = GetRouteTheme();

            #region 特色图片上传
            string[] imgUpload = Utils.GetFormValues(this.UploadControl1.ClientHideID);
            string[] oldimgUpload = Utils.GetFormValues("hideimg");
            List<MFileInfo> imglist = null;
            if (oldimgUpload.Length > 0)
            {
                if (imglist == null)
                {
                    imglist = new List<MFileInfo>();
                }
                for (int i = 0; i < oldimgUpload.Length; i++)
                {
                    if (oldimgUpload[i].Trim() != "")
                    {
                        MFileInfo model = new MFileInfo();
                        model.FilePath = oldimgUpload[i].Split('|')[1];
                        imglist.Add(model);
                    }
                }
            }
            if (imgUpload.Length > 0)
            {
                imglist = new List<MFileInfo>();
                for (int i = 0; i < imgUpload.Length; i++)
                {
                    if (imgUpload[i].ToString() != "")
                    {
                        if (imgUpload[i].Split('|').Length > 1)
                        {
                            MFileInfo model = new MFileInfo();
                            model.FilePath = imgUpload[i].Split('|')[1];
                            imglist.Add(model);
                        }
                    }
                }
            }
            #endregion

            #region 签证资料上传
            string[] qianzhengpath = Utils.GetFormValues(this.Uploadqianzheng.ClientHideID);
            string[] oldqianzheng = Utils.GetFormValues("hideFileInfo");
            if (oldqianzheng.Length > 0)
            {
                if (oldqianzheng[0].Split('|').Length > 1)
                {
                    modelroute.QianZheng = oldqianzheng[0].ToString().Split('|')[0].ToString();
                    modelroute.QianZhengFilePath = oldqianzheng[0].ToString().Split('|')[1].ToString();
                }
            }
            if (qianzhengpath.Length > 0)
            {
                if (qianzhengpath[0].Split('|').Length > 1)
                {
                    modelroute.QianZheng = qianzhengpath[0].ToString().Split('|')[0].ToString();
                    modelroute.QianZhengFilePath = qianzhengpath[0].ToString().Split('|')[1].ToString();
                }
            }
            #endregion

            //特色图片集合
            modelroute.TeSeFiles = imglist;
            modelroute.IssueTime = DateTime.Now;

            //发班时间集合
            modelroute.Tours = new List<MXianLuTourInfo>();
            #endregion

            #region 保存操作

            int result = 0;
            if (t)
            {
                for (int i = 0; i < leaveDateBegin.Length; i++)
                {
                    MXianLuTourInfo Model = new MXianLuTourInfo();
                    Model.LDate = Utils.GetDateTime(leaveDateBegin[i]);
                    Model.RDate = Utils.GetDateTime(Utils.GetDateTime(leaveDateBegin[i].ToString()).AddDays(days).ToString());
                    modelroute.Tours.Add(Model);
                }
                result = bll.Insert(modelroute);
            }
            else
            {
                EyouSoft.BLL.XianLuStructure.BXianLu newbll = new EyouSoft.BLL.XianLuStructure.BXianLu();
                //重新获取实体（用来得到原来选择的团的日期，和新选择的日期比对，如果匹配到日期，把团号赋值过去[不做新增]）
                MXianLuInfo newmodel = newbll.GetInfo(id);
                modelroute.XianLuId = id;
                modelroute.LatestTime = DateTime.Now;
                modelroute.LatestId = UserInfo.UserId;
                IList<MXianLuTourInfo> newlist = new List<MXianLuTourInfo>();
                for (int k = 0; k < leaveDateBegin.Length; k++)
                {
                    MXianLuTourInfo newdate = new MXianLuTourInfo();
                    if (leaveDateBegin[k].ToString() != "")
                    {
                        newdate.LDate = Utils.GetDateTime(leaveDateBegin[k].ToString());
                        newlist.Add(newdate);
                    }
                }
                for (int i = 0; i < newlist.Count; i++)
                {
                    MXianLuTourInfo Model = new MXianLuTourInfo();
                    for (int j = 0; j < newmodel.Tours.Count; j++)
                    {
                        Model.LDate = newlist[i].LDate;
                        Model.RDate = newlist[i].LDate.AddDays(days);
                        if ((newmodel.Tours[j].LDate).ToString("yyyy-MM-dd") == (newlist[i].LDate).ToString("yyyy-MM-dd"))
                        {
                            Model.TourId = newmodel.Tours[j].TourId;
                        }
                    }
                    modelroute.Tours.Add(Model);
                }
                result = bll.Update(modelroute);
            }
            switch (result)
            {
                case 1:
                    msg = Utils.AjaxReturnJson("1", (t ? "新增" : "修改") + "成功!");
                    break;
                default:
                    msg = Utils.AjaxReturnJson("0", (t ? "新增" : "修改") + "失败!");
                    break;
            }
            return msg;
            #endregion
        }

        #region 线路主题
        /// <summary>
        ///初始化主题
        /// </summary>
        /// <returns></returns>
        private string BindRouteTheme(IList<MXianLuZhuTiInfo> thembid)
        {
            IList<EyouSoft.Model.MRouteTheme> list = new List<EyouSoft.Model.MRouteTheme>();
            EyouSoft.BLL.OtherStructure.BRouteTheme blltheme = new EyouSoft.BLL.OtherStructure.BRouteTheme();
            list = blltheme.GetList();

            StringBuilder strchb = new StringBuilder();
            IList<string> listthemb = new List<string>();
            if (thembid != null)
            {
                foreach (var model in thembid)
                {
                    if (model.Id > 0)
                        listthemb.Add(model.Id.ToString());
                }
            }
            int i = 0;
            foreach (var item in list)
            {
                if (listthemb != null)
                {
                    if (listthemb.Contains(item.ID.ToString()))
                        strchb.AppendFormat("<label><input type='checkbox' checked name='themeId' class='theme' value='{0}'/>{1}</label>", item.ID, item.Name);
                    else
                        strchb.AppendFormat("<label><input type='checkbox' class='theme' value='{0}' />{1}</label>", item.ID, item.Name);
                }
                else
                {
                    strchb.AppendFormat("<label><input type='checkbox' class='theme' value='{0}' />{1}</label>", item.ID, item.Name);
                }
                if (i % 8 == 0 && i > 0)
                {
                    strchb.Append("<br />");
                }
                i++;
            }
            return strchb.ToString();
        }
        /// <summary>
        /// 获取选择的主题
        /// </summary>
        /// <returns></returns>
        private List<MXianLuZhuTiInfo> GetRouteTheme()
        {
            List<MXianLuZhuTiInfo> list = new List<MXianLuZhuTiInfo>();
            string[] themeid = Utils.GetFormValues("themeId");
            if (themeid.Length > 0)
            {
                for (int i = 0; i < themeid.Length; i++)
                {
                    MXianLuZhuTiInfo model = new MXianLuZhuTiInfo();
                    model.Id = Utils.GetInt(themeid[i]);
                    list.Add(model);
                }
            }
            return list;

        }
        #endregion

        #region 初始化线路状态
        /// <summary>
        /// 初始化线路状态
        /// </summary>
        /// <param name="zhuangtailist"></param>
        /// <returns></returns>
        private string BindRouteStatus(IList<XianLuZhuangTai> zhuangtailist)
        {
            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            var items = EnumObj.GetList(typeof(XianLuZhuangTai)).Where(m => m.Value != "0").ToList();
            StringBuilder strchb = new StringBuilder();
            IList<string> listzhuangtai = new List<string>();
            if (zhuangtailist != null)
            {
                for (int j = 0; j < zhuangtailist.Count; j++)
                {
                    listzhuangtai.Add(zhuangtailist[j].ToString());
                }
            }
            int i = 0;
            foreach (var item in items)
            {
                if (listzhuangtai != null)
                {
                    if (listzhuangtai.Contains(item.Text.ToString()))
                        strchb.AppendFormat("<label><input type='checkbox' checked class='routestatus' name='routestatus' value='{0}' />{1}</label>", item.Value, item.Text);
                    else
                        strchb.AppendFormat("<label><input type='checkbox' class='routestatus' value='{0}'/>{1}</label>", item.Value, item.Text);
                }
                else
                {
                    strchb.AppendFormat("<label><input type='checkbox' class='routestatus' value='{0}' />{1}</label>", item.Value, item.Text);
                }
                if (i % 8 == 0 && i > 0)
                {
                    strchb.Append("<br />");
                }
                i++;
            }

            return strchb.ToString();
        }
        /// <summary>
        /// 获取线路状态
        /// </summary>
        /// <returns></returns>
        private List<XianLuZhuangTai> GetRouteStatus()
        {
            List<XianLuZhuangTai> list = new List<XianLuZhuangTai>();
            string[] enumvalue = Utils.GetFormValues("routestatus");
            if (enumvalue.Length > 0)
            {
                for (int i = 0; i < enumvalue.Length; i++)
                {
                    list.Add((XianLuZhuangTai)Utils.GetInt(enumvalue[i]));
                }
            }
            return list;
        }
        #endregion

        #region 获得计划行程集合 create by liuf

        /// <summary>
        /// 获得计划行程集合
        /// </summary>
        /// <returns></returns>
        public List<EyouSoft.Model.XianLuStructure.MXianLuXingChengInfo> GetPlanList()
        {

            List<EyouSoft.Model.XianLuStructure.MXianLuXingChengInfo> list = new List<EyouSoft.Model.XianLuStructure.MXianLuXingChengInfo>();
            //区间
            string[] section = Utils.GetFormValues("txt_qujin");
            //酒店
            string[] hotelName = Utils.GetFormValues("txtHotelName");
            //用餐
            string[] breakfast = Utils.GetFormValues("eatFrist");
            //交通
            string[] traffic = Utils.GetFormValues("txtTraffic");
            //行程内容
            string[] txtContent = Request.Form.GetValues("txtContent");
            //附件
            string[] files = Utils.GetFormValues("hide_Journey_file");

            if (section.Length > 0)
            {
                for (int i = 0; i < section.Length; i++)
                {
                    MXianLuXingChengInfo model = new MXianLuXingChengInfo();
                    model.QuJian = section[i].Trim();
                    model.ZhuSu = hotelName[i].Trim();

                    model.YongCan = breakfast[i];

                    model.XingCheng = Utils.EditInputText(txtContent[i]);
                    model.JiaoTong = traffic[i];
                    if (files[i].Split('|').Length > 1)
                    {
                        model.FilePath = files[i].Split('|')[1];
                    }
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
    }
}
