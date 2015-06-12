using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ConsoleApp
{
    class HuanTu
    {
        const string HappytooKey = "8D2962020F40ED90";

        /// <summary>
        /// 获取线路行程信息
        /// </summary>
        /// <param name="happytooId"></param>
        /// <returns></returns>
        string GetXingCheng(string happytooId)
        {
            string s = string.Empty;

            var ds = new HappytooService.Line().GetDataSetLineRote(happytooId);

            if (ds == null || ds.Tables == null || ds.Tables.Count == 0 || ds.Tables[0].Rows == null || ds.Tables[0].Rows.Count == 0) return string.Empty;

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                string s1 = item["R_Can"].ToString();
                var arr = s1.Split(',');
                string s2 = string.Empty;
                foreach (var item1 in arr)
                {
                    if (item1 == "0") s2 += "早,";
                    if (item1 == "1") s2 += "中,";
                    if (item1 == "2") s2 += "晚,";
                }
                if (!string.IsNullOrEmpty(s2)) s2 = s2.Trim(',');

                //D1行程{{;}}住宿{{;}}早,中,晚{{;}}区间{{;}}交通工具{{;}}班次{{~}}
                s += item["R_Content"].ToString() + "{{;}}" + item["R_Zhu"].ToString() + "{{;}}" + s2 + "{{;}}" + string.Empty + "{{;}}" + item["R_Car"].ToString() + "{{;}}" + string.Empty + "{{~}}";

            }

            if (s.EndsWith("{{~}}"))
            {
                s = s.Substring(0, s.Length - "{{~}}".Length);
            }

            return s;
        }

        /// <summary>
        /// 获取线路区域
        /// </summary>
        public void GetXianLuZone()
        {

            //Adpost.Common.DataDAL.Union_TourArea bll = new Adpost.Common.DataDAL.Union_TourArea();

            var ds = new HappytooService.Line().GetDataLineColumn(HappytooKey, "1");//国内
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0 || ds.Tables[0].Rows == null || ds.Tables[0].Rows.Count == 0)
            {
                Console.WriteLine("happytoo 未读取到信息。");
                return;
            }
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                //Union.Model.Union_TourArea TourModel = new Union.Model.Union_TourArea();

                //TourModel.AreaName = item["z_name"].ToString();
                //TourModel.AreaType = 0;

                //bll.Add(TourModel);

            }

            ds = new HappytooService.Line().GetDataLineColumn(HappytooKey, "0");//周边
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0 || ds.Tables[0].Rows == null || ds.Tables[0].Rows.Count == 0)
            {
                Console.WriteLine("happytoo 未读取到信息。");
                return;
            }
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                //Union.Model.Union_TourArea TourModel = new Union.Model.Union_TourArea();

                //TourModel.AreaName = item["z_name"].ToString();
                //TourModel.AreaType = 1;

                //bll.Add(TourModel);

            }

        }

        /// <summary>
        /// 获取线路
        /// </summary>
        public void GetXianLu()
        {

            int i = 0;
            int[] Z = new int[] { 140, 141, 142, 144, 145, 146, 148, 149, 150, 152, 155, 157, 158, 160 };
            foreach (int num in Z)
            {
                var ds = new HappytooService.Line().GetDataSetLine(HappytooKey, num.ToString(), "杭州", -1, 1, 10000);
                if (ds == null || ds.Tables == null || ds.Tables.Count == 0 || ds.Tables[0].Rows == null || ds.Tables[0].Rows.Count == 0)
                {
                    Console.WriteLine("happytoo 未读取到信息。");
                    return;
                }


                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    try
                    {
                        //Union.Model.Union_TourGroup TourModel = new Union.Model.Union_TourGroup();

                        //TourModel.Line_Source = Union.Model.Union_TourGroup.LineSource.欢途;

                        //TourModel.SystemID = 1;
                        //TourModel.CompanyID = 0;
                        //TourModel.OperatorID = 0;
                        //TourModel.TourClassId = 1;


                        //TourModel.RouteName = item["L_Title"].ToString();
                        //TourModel.RouteClassName = item["Z_Name"].ToString();
                        //TourModel.Standard = string.Empty;
                        ////TourModel.TourDays = int.Parse(a.TourDays);
                        //TourModel.TourManNumber = 0;
                        //TourModel.TourManMargin = 0;
                        //TourModel.TourManRemnant = Utils.GetInt(item["RenCount"].ToString());

                        //TourModel.AgencyPersonalPrice = Utils.GetDecimal(item["L_JCrPrice"].ToString());
                        //TourModel.AgencyChildPrice = Utils.GetDecimal(item["L_JXhPrice"].ToString());
                        //TourModel.MarketPersonalPrice = Utils.GetDecimal(item["L_CrPrice"].ToString());
                        //TourModel.MarketChildPrice = Utils.GetDecimal(item["L_XhPrice"].ToString());
                        //TourModel.IssueCompany = item["C_Name"].ToString();
                        //TourModel.IssueDate = Utils.GetDateTime(item["L_GoGroupTime"].ToString());
                        //DateTime endtime = Utils.GetDateTime(item["L_EndTime"].ToString());

                        //TimeSpan ts = endtime - TourModel.IssueDate;
                        //TourModel.TourDays = Utils.GetInt(item["L_Day"].ToString());

                        ////TourModel.RouteRemark =a1.RouteRemark;
                        //TourModel.RouteRemark = string.Empty;


                        ////TourModel.JourneyDayPlan = JourneyDayPlan;
                        //TourModel.JourneyDayPlan = string.Empty;
                        //TourModel.ServiceStandard = item["L_YesItem"].ToString();
                        //TourModel.ExpenseItem = item["L_ExpenseItem"].ToString();
                        //TourModel.NoticeProceeding = item["L_Attention"].ToString();
                        //TourModel.Remark = item["L_Mode"].ToString();
                        ////TourModel.ContactName = a1.ContactName;
                        ////TourModel.ContactPhone = a1.ContactPhone;
                        ////TourModel.ContactMobilePhone = string.Empty;
                        ////TourModel.ContactFax = string.Empty;
                        ////TourModel.QQNO = string.Empty;
                        ////TourModel.MSNNo = string.Empty;
                        ////TourModel.Email = string.Empty;
                        //TourModel.Happytoo_Info = new Union.Model.Union_TourGroup.HappytooInfo();
                        //TourModel.Happytoo_Info.HappytooId = Utils.GetInt(item["L_Id"].ToString());
                        //TourModel.JourneyDayPlan = GetXingCheng(TourModel.Happytoo_Info.HappytooId.ToString());
                        //Adpost.Common.DataDAL.Union_TourGroup bll = new Adpost.Common.DataDAL.Union_TourGroup();
                        //TourModel.ID = bll.Exists(TourModel.Happytoo_Info.HappytooId, TourModel.IssueDate);
                        //if (TourModel.ID == 0)
                        //{
                        //    bll.HaapytooAdd(TourModel);
                        //    i++;

                        //    Console.WriteLine(DateTime.Now + " " + TourModel.RouteName + " " + TourModel.IssueDate);
                        //}
                        //else
                        //{
                        //    bll.UpdateBokTour(TourModel);

                        //    i++;

                        //    Console.WriteLine(DateTime.Now + " " + TourModel.RouteName + " " + TourModel.IssueDate);
                        //}
                    }
                    catch (Exception e)
                    {

                        System.IO.StreamWriter swe = new System.IO.StreamWriter(System.Environment.CurrentDirectory + @"\log\" + DateTime.Now.ToFileTime().ToString() + ".log");
                        swe.WriteLine(e.Message);
                        swe.WriteLine(e.Source);
                        swe.WriteLine(e.StackTrace);
                        swe.Close();
                    }
                }
            }

            Console.WriteLine("happytoo 合计：" + i + "。");
        }
    }
}
