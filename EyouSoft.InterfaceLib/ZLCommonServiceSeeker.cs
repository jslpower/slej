using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using EyouSoft.InterfaceLib.Common;
using EyouSoft.InterfaceLib.Response.ZL;
using EyouSoft.InterfaceLib.Request.ZL;

namespace EyouSoft.InterfaceLib
{
    /// <summary>
    /// 中旅旅业通用
    /// </summary>
    public class ZLCommonServiceSeeker : WebServiceXmlSeekerBase
    {
        protected override string Address
        {
            get
            {
                return ConfigurationManager.AppSettings["ZLCommonServiceSeekerAddress"];
            }
        }

        public ZLCommonServiceSeeker()
            : base(false)
        {
        }

        #region IZLCommonServiceSeeker 成员

        /// <summary>
        /// 获取出境团队列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public get_obd_group_listResponse get_obd_group_list(get_obd_group_listRequest request)
        {
            return GetResponse<get_obd_group_listResponse>(new object[] { request.user_key, request.password, request.page_index, request.page_size, request.condition_exp, request.sort_exp });
        }

        /// <summary>
        /// 获取出境团队详情
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public get_obd_group_detailResponse get_obd_group_detail(get_obd_group_detailRequest request)
        {
            return GetResponse<get_obd_group_detailResponse>(new object[] { request.user_key, request.password, request.sid });
        }

        /// <summary>
        /// 出境下单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int insert_obd_order(EyouSoft.Model.XianLuStructure.MXianLuInfo tinfo, EyouSoft.Model.XianLuStructure.MOrderInfo OrderInfo)
        {
            insert_obd_orderRequest request = new insert_obd_orderRequest();
            request.user_key = ConfigurationManager.AppSettings["ZLCommonLoginName"];
            request.password = ConfigurationManager.AppSettings["ZLCommonPassword"];
            request.arglist.OrderHeader.AdultNum = OrderInfo.ChengRenShu;
            request.arglist.OrderHeader.ChildNum = OrderInfo.ErTongShu;
            request.arglist.OrderHeader.Comments = OrderInfo.XiaDanBeiZhu;
            request.arglist.OrderHeader.GroupId = Utils.GetInt(tinfo.LineID);
            request.arglist.OrderHeader.Linkman = OrderInfo.LxrName;
            request.arglist.OrderHeader.MobilePhone = OrderInfo.LxrTelephone;
            request.arglist.OrderHeader.Telphone = OrderInfo.LxrTelephone;
            foreach (EyouSoft.Model.XianLuStructure.MOrderYouKeInfo youke in OrderInfo.YouKes)
            {
                EyouSoft.InterfaceLib.Models.ZL.Customer model = new EyouSoft.InterfaceLib.Models.ZL.Customer();
                model.Name = youke.Name;
                model.Sex = youke.Gender.ToString();
                model.Telphone = string.IsNullOrEmpty(youke.Telephone) ? " " : youke.Telephone;
                model.BirthDay = "1970-01-01";
                model.EName = " ";
                model.IDCard = string.IsNullOrEmpty(youke.ZhengJianCode) ? " " : youke.ZhengJianCode;
                model.MobilePhone = string.IsNullOrEmpty(youke.Telephone) ? " " : youke.Telephone;
                model.tComments = string.IsNullOrEmpty(youke.BeiZhu) ? " " : youke.BeiZhu;
                model.Address = " ";
                model.Email = " ";
                request.arglist.Customer.list.Add(model);
            }
            insert_obd_orderResponse response = GetResponse<insert_obd_orderResponse>(new object[] { request.user_key, request.password, request.arglist.ToString().Replace("mt-", "") });
            if (response.result_id == 0 && response.OrderHeader.Count > 0)
                return response.OrderHeader[0].SID;
            else
                return 0;
        }
        #endregion
    }
}
