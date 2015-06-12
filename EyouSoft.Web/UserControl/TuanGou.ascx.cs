using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.UserControl
{
    public partial class TuanGou : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitCuXiao();
            InitMiaoSha();
        }
        /// <summary>
        /// 促销初始化
        /// </summary>
        private void InitCuXiao()
        {
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            serchModel.SaleType = EyouSoft.Model.Enum.CuXiaoLeiXing.促销;
            serchModel.WeiZhi = new List<EyouSoft.Model.Enum.XianShiWeiZhi> { EyouSoft.Model.Enum.XianShiWeiZhi.频道推荐, EyouSoft.Model.Enum.XianShiWeiZhi.以上全部 }; ;
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(5, serchModel);
            CuXiao.DataSource = list;
            CuXiao.DataBind();
        }
        /// <summary>
        /// 秒杀初始化
        /// </summary>
        private void InitMiaoSha()
        {
            var serchModel = new EyouSoft.Model.OtherStructure.MTuanGouChanPinSer();
            serchModel.SaleType = EyouSoft.Model.Enum.CuXiaoLeiXing.秒杀;
            serchModel.WeiZhi = new List<EyouSoft.Model.Enum.XianShiWeiZhi> { EyouSoft.Model.Enum.XianShiWeiZhi.频道推荐, EyouSoft.Model.Enum.XianShiWeiZhi.以上全部 }; ;
            var list = new EyouSoft.BLL.OtherStructure.BTuanGou().GetList(5, serchModel);
            MiaoSha.DataSource = list;
            MiaoSha.DataBind();
        }
        /// <summary>
        /// 计算折扣
        /// </summary>
        /// <param name="cuxiaojia">促销价</param>
        /// <param name="yuanjia">原价</param>
        /// <returns></returns>
        protected string GetZheKou(object cuxiaojia, object yuanjia)
        {
            string zhekou = "0";
            zhekou = Convert.ToDouble(Convert.ToDouble(cuxiaojia) / Convert.ToDouble(yuanjia) * 10).ToString("f1");
            return zhekou;
        }
        /// <summary>
        /// 计算秒数
        /// </summary>
        /// <param name="datetime">时间</param>
        /// <returns></returns>
        protected string GetMiaoshu(object datetime)
        {
            string miaoshu = "0";
            miaoshu = Convert.ToInt32((Convert.ToDateTime(datetime).AddDays(1) - DateTime.Now).TotalSeconds).ToString();
            return miaoshu;
        }
    }
}