using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    [XmlRoot("linelist")]
    /// <summary>
    /// 线路信息（linelist）
    /// </summary>
    public class XianLu
    {
        /// <summary>
        ///  线路 ID 
        /// </summary>
        public int id{ get; set; }
        /// <summary>
        /// 线路标题
        /// </summary>
        public string title{ get; set; }
        /// <summary>
        /// 行程天数
        /// </summary>
        public int days{ get; set; }
        /// <summary>
        ///  出发城市 ID 
        /// </summary>
        public int city_id{ get; set; }
        /// <summary>
        /// 出发城市
        /// </summary>
        public string city_title{ get; set; }
        /// <summary>
        /// 线路属性
        /// </summary>
        public LuXianShuXing type_id{ get; set; }
        /// <summary>
        /// 参团性质
        /// </summary>
        public CanTuanXingZhi type1_id{ get; set; }
        /// <summary>
        /// 该线路卖点。数据不准确。不做分类参考
        /// </summary>
        public LuXianMaiDian type2_id{ get; set; }
        /// <summary>
        /// 目的地一级分类ID
        /// </summary>
        public int area_parent_id{ get; set; }
        /// <summary>
        /// 目的地一级分类
        /// </summary>
        public string area_parent_title{ get; set; }
        /// <summary>
        /// 目的地二级分类
        /// </summary>
        public int area_id{ get; set; }
        /// <summary>
        /// 目的地二级分类
        /// </summary>
        public string area_title{ get; set; }
        /// <summary>
        /// 证件种类
        /// </summary>
        public ZhengJianZhongLei cert_id{ get; set; }
        /// <summary>
        ///  签证ｉｄ
        /// </summary>
        public string visa_id{ get; set; }
        /// <summary>
        /// 行程文档文件  这个没用起来。没什么用
        /// </summary>
        public string file_text{ get; set; }
        /// <summary>
        /// 儿童年龄test
        /// </summary>
        public string children_age{ get; set; }
        /// <summary>
        /// 线路特色
        /// </summary>
        public string test_special{ get; set; }
        /// <summary>
        /// 销售说明 test
        /// </summary>
        public string test_sale{ get; set; }
        /// <summary>
        ///  费用包含 test
        /// </summary>
        public string test_contains{ get; set; }
        /// <summary>
        /// 费用不含 test
        /// </summary>
        public string test_exclude{ get; set; }
        /// <summary>
        ///  注意事项 test
        /// </summary>
        public string test_attention{ get; set; }
        /// <summary>
        /// 儿童安排 test
        /// </summary>
        public string test_children{ get; set; }
        /// <summary>
        /// 购物安排 test
        /// </summary>
        public string test_shop{ get; set; }
        /// <summary>
        /// 赠送项目 test
        /// </summary>
        public string test_free{ get; set; }
        /// <summary>
        ///  温馨提示 test
        /// </summary>
        public string test_tips{ get; set; }
        /// <summary>
        /// (1 降价) 
        /// </summary>
        public Is drop{ get; set; }
        /// <summary>
        /// (1 热门) 
        /// </summary>
        public Is hot{ get; set; }
        /// <summary>
        ///  (1 推荐)
        /// </summary>
        public Is recommend{ get; set; }
        /// <summary>
        /// 导服务
        /// </summary>
        public int tips_price{ get; set; }
        /// <summary>
        /// 是否包含导服费 
        /// </summary>
        public Is has_tips_price{ get; set; }
        /// <summary>
        /// 税金
        /// </summary>
        public int taxes_price{ get; set; }
        /// <summary>
        /// 是否包含税金
        /// </summary>
        public Is has_taxes_price{ get; set; }
        /// <summary>
        /// 其它费用标题
        /// </summary>
        public string other_title{ get; set; }
        /// <summary>
        /// 其它费用 
        /// </summary>
        public int other_price{ get; set; }
        /// <summary>
        /// 是否包含其它费用 
        /// </summary>
        public Is has_other_price{ get; set; }
        /// <summary>
        /// 定金 
        /// </summary>
        public int deposit_price{ get; set; }
        /// <summary>
        /// 专管员昵称 
        /// </summary>
        public string nickname{ get; set; }
        /// <summary>
        /// 手机 
        /// </summary>
        public string tel{ get; set; }
        /// <summary>
        /// 电话 
        /// </summary>
        public string phone{ get; set; }
        /// <summary>
        ///  QQ 
        /// </summary>
        public string qq{ get; set; }
        /// <summary>
        /// 发班列表
        /// </summary>
        public List<FaBan> tour{ get; set; }
        /// <summary>
        /// 行程列表
        /// </summary>
        public List<XingCheng> itinerary { get; set; }

        /// <summary>
        /// 行程列表
        /// </summary>
        public List<Image> photo { get; set; }
    }

    public class Image
    {
        public string full_path;
        public string file_type;
    }
}
