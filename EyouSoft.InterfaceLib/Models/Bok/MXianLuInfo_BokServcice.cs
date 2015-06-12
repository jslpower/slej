using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;

namespace EyouSoft.InterfaceLib.Models.Bok
{
   public class MXianLuInfo_BokServcice : IConvertToMModel
   {
      /// <summary>
      /// default constructor
      /// </summary>
      public MXianLuInfo_BokServcice() { }

      /// <summary>
      /// 线路编号
      /// </summary>
      public string XianLuId { get; set; }

      /// <summary>
      /// 线路类型
      /// </summary>
      public int AreaType { get; set; }
      /// <summary>
      /// 线路区域
      /// </summary>
      public int AreaId { get; set; }
      /// <summary>
      /// 线路名称
      /// </summary>
      public string RouteName { get; set; }
      /// <summary>
      /// 行程天数
      /// </summary>
      public int TianShu { get; set; }
      /// <summary>
      /// 出发地省份编号
      /// </summary>
      public int DepProvinceId { get; set; }
      /// <summary>
      /// 出发地城市编号
      /// </summary>
      public int DepCityId { get; set; }
      /// <summary>
      /// 目的地省份编号
      /// </summary>
      public int ArrProvinceId { get; set; }
      /// <summary>
      /// 目的地城市编号
      /// </summary>
      public int ArrCityId { get; set; }
      /// <summary>
      /// 计划人数
      /// </summary>
      public int JiHuaRenShu { get; set; }
      /// <summary>
      /// 市场价-成人
      /// </summary>
      public decimal SCJCR { get; set; }
      /// <summary>
      /// 市场价-儿童
      /// </summary>
      public decimal SCJET { get; set; }
      /// <summary>
      /// 结算价-成人
      /// </summary>
      public decimal JSJCR { get; set; }
      /// <summary>
      /// 结算价-儿童
      /// </summary>
      public decimal JSJET { get; set; }
      /// <summary>
      /// 提前X天报名
      /// </summary>
      public int TingTianShu { get; set; }
      /// <summary>
      /// 出发交通
      /// </summary>
      public string ChuFaJiaoTong { get; set; }
      /// <summary>
      /// 返程交通
      /// </summary>
      public string FanChengJiaoTong { get; set; }
      /// <summary>
      /// 集合方式
      /// </summary>
      public string JiHeFangShi { get; set; }
      /// <summary>
      /// 特色描述文字
      /// </summary>
      public string TeSe { get; set; }
      /// <summary>
      /// 特色描述图片
      /// </summary>
      public string TeSeFilePath { get; set; }
      /// <summary>
      /// 途径
      /// </summary>
      public string TuJing { get; set; }
      /// <summary>
      /// 签证资料
      /// </summary>
      public string QianZheng { get; set; }
      /// <summary>
      /// 签证说明
      /// </summary>
      public string QianZhengFilePath { get; set; }
      /// <summary>
      /// 关注数
      /// </summary>
      public int GuanZhuShu { get; set; }
      /// <summary>
      /// 联系人姓名
      /// </summary>
      public string LxrName { get; set; }
      /// <summary>
      /// 联系人电话
      /// </summary>
      public string LxrTelephone { get; set; }
      /// <summary>
      /// 联系人QQ
      /// </summary>
      public string LxrQQ { get; set; }
      /// <summary>
      /// 联系人手机
      /// </summary>
      public string LxrMobile { get; set; }
      /// <summary>
      /// description
      /// </summary>
      public string Description { get; set; }
      /// <summary>
      /// keywords
      /// </summary>
      public string Keywords { get; set; }
      /// <summary>
      /// 发布人编号
      /// </summary>
      public int OperatorId { get; set; }
      /// <summary>
      /// 发布时间
      /// </summary>
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 修改人编号
      /// </summary>
      public int LatestId { get; set; }
      /// <summary>
      /// 修改时间
      /// </summary>
      public DateTime LatestTime { get; set; }
      /// <summary>
      /// 自增编号
      /// </summary>
      public int IdentityId { get; set; }
      /// <summary>
      /// 线路行程信息集合
      /// </summary>
      public IList<MXianLuXingChengInfo_BokServcice> XingChengs { get; set; }
      /// <summary>
      /// 服务标准信息业务实体
      /// </summary>
      public MXianLuFuWuInfo_BokServcice FuWu { get; set; }
      /// <summary>
      /// 发班信息集合
      /// </summary>
      public IList<MXianLuTourInfo_BokServcice> Tours { get; set; }

      /// <summary>
      /// 航班信息集合
      /// </summary>
      public IList<MXianLuTourTraffice_BokServcice> TrafficeList { get; set; }

      /// <summary>
      /// 满意度
      /// </summary>
      public decimal ManYiDu { get; set; }
      /// <summary>
      /// 点评数
      /// </summary>
      public decimal DianPingShu { get; set; }

      /// <summary>
      /// 线路区域名称
      /// </summary>
      public string AreaName { get; set; }
      /// <summary>
      /// 接口编号
      /// </summary>
      public string LineID { get; set; }
       /// <summary>
       /// 出发城市
       /// </summary>
      public string CFCS { get; set; }
   }
}
