using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using EyouSoft.InterfaceLib.Common.Serializer;
using System.Configuration;
using System.Web;
using EyouSoft.InterfaceLib.Common;
using EyouSoft.InterfaceLib.Response.MTS;
using EyouSoft.InterfaceLib.Request.MTS;
using EyouSoft.InterfaceLib.Attributes;

namespace EyouSoft.InterfaceLib
{
   /// <summary>
   /// 美景天下景点接口(不直接调用mts的接口，而是间接调用中旅接口,中旅去访问mts接口)
   /// </summary>
   public class MTSServiceSeeker : WebServiceXmlSeekerBase
   {
      public MTSServiceSeeker()
         : base(true)
      {

      }
      protected override string Address
      {
         get
         {
            return ConfigurationManager.AppSettings["ZLJRServiceSeekerAddress"];
         }
      }

      #region ISeeker 成员
      /// <summary>
      /// 接口一：地区分类接口
      /// </summary>
      [ContractName("SelectareaList")]
      public SelectareaListResponse SelectAreaList(SelectareaListRequest request)
      {
         return GetResponse<SelectareaListResponse>(new object[] { request.loginname, request.pwd });
      }
      /// <summary>
      /// 接口二：景区类型列表
      /// </summary>
      [ContractName("SelectResourceCategoryList")]
      public SelectResourceCategoryListResponse SelectResourceCategoryList(SelectResourceCategoryListRequest request)
      {
         return GetResponse<SelectResourceCategoryListResponse>(new object[] { request.loginname, request.pwd });
      }
      /// <summary>
      /// 接口三：景点信息总页数
      /// </summary>
      public SelectResourceListPagecountResponse SelectResourceListPagecount(SelectResourceListPagecountRequest request)
      {
         return GetResponse<SelectResourceListPagecountResponse>(new object[] { request.loginname, request.pwd });
      }
      /// <summary>
      /// 接口四：景点信息列表
      /// </summary>
      public SelectResourceListResponse SelectResourceList(SelectResourceListRequest request)
      {
         return GetResponse<SelectResourceListResponse>(new object[] { request.loginname, request.pwd, request.Page.ToString() });
      }
      /// <summary>
      /// 接口五：景点信息详细信息
      /// </summary>
      public ResourceDetailResponse ResourceDetail(ResourceDetailRequest request)
      {
         return GetResponse<ResourceDetailResponse>(new object[] { request.loginname, request.pwd, request.id });
      }
      /// <summary>
      /// 接口九：门票订单提交
      /// </summary>
      /// <param name="request"></param>
      /// <returns>订单主键id。id>0说明提交成功，如果为负数说明保存不成功</returns>
      [ContractName("submitorder")]
      public int SubmitOrder(SubmitOrderRequest request)
      {
         return GetResponse<int>(new object[] { request.loginname, request.pwd, request.arglist.ToString() });
      }
      /// <summary>
      /// 接口十：订单发码
      /// </summary>
      /// <returns>如果返回值>0表示提交成功，负数表示提交不成功</returns>
      [ContractName("sendpiaou")]
      public int SendPiaou(SendPiaouRequest request)
      {
         return GetResponse<int>(new object[] { request.loginname, request.pwd, request.arglist.ToString() });
      }
      /// <summary>
      /// 接口六：景点门票总页数
      /// </summary>
      public SelectProductListPagecountResponse SelectProductListPagecount(SelectProductListPagecountRequest request)
      {
         return GetResponse<SelectProductListPagecountResponse>(new object[] { request.loginname, request.pwd });
      }
      /// <summary>
      /// 接口七：景点门票信息列表
      /// </summary>
      public SelectProductListResponse SelectProductList(SelectProductListRequest request)
      {
         return GetResponse<SelectProductListResponse>(new object[] { request.loginname, request.pwd, request.Page.ToString() });
      }
      /// <summary>
      /// 接口八：景点门票信息详细信息
      /// </summary>
      public ProductDetailResponse ProductDetail(ProductDetailRequest request)
      {
         return GetResponse<ProductDetailResponse>(new object[] { request.loginname, request.pwd, request.id });
      }
      #endregion
   }
}
