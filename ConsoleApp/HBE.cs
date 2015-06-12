using System;
using System.Linq;
using System.Text;
using System.Configuration;
using EyouSoft.Common;
using System.IO;
using TravelSky.Base.Interface;
using System.Xml;

namespace ConsoleApp
{
    class HBE
    {
        public bool AutoDiBiao()
        {
            bool Success = false;
            try
            {
                var list = new EyouSoft.BLL.OtherStructure.BDiBiao().GetCityCode();
                if (list != null && list.Count > 0)
                {
                    for (int t = 0; t < list.Count; t++)
                    {
                        string abc = EyouSoft.InterfaceLib.HotelBE.CreateRequest(EyouSoft.InterfaceLib.HotelBE.CreateRequestXML("TH_AreaSearchRQ", EyouSoft.InterfaceLib.HotelBE.CreateAreaSearchRQXML(list[t].CityCode)));
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(abc);

                        XmlNodeList xnlist = doc.SelectSingleNode("OTResponse").SelectSingleNode("AreaSearchRS").SelectSingleNode("AreaInfos").SelectNodes("AreaInfo");
                        for (int i = 0; i < xnlist.Count; i++)
                        {
                            EyouSoft.Model.OtherStructure.MLandMark model = new EyouSoft.Model.OtherStructure.MLandMark();
                            if (xnlist[i].SelectNodes("CityCode").Count > 0)
                            {
                                model.CityCode = xnlist[i].SelectSingleNode("CityCode").InnerText;
                            }
                            if (xnlist[i].SelectNodes("CityName").Count > 0)
                            {
                                model.CityName = xnlist[i].SelectSingleNode("CityName").InnerText;
                            }
                            if (xnlist[i].SelectNodes("AreaCode").Count > 0)
                            {
                                model.AreaCode = xnlist[i].SelectSingleNode("AreaCode").InnerText;
                            }
                            if (xnlist[i].SelectNodes("AreaName").Count > 0)
                            {
                                model.AreaName = xnlist[i].SelectSingleNode("AreaName").InnerText;
                            }
                            if (xnlist[i].SelectNodes("AreaPinyin").Count > 0)
                            {
                                model.AreaPinyin = xnlist[i].SelectSingleNode("AreaPinyin").InnerText;
                            }
                            if (xnlist[i].SelectNodes("Province").Count > 0)
                            {
                                model.ProviceName = xnlist[i].SelectSingleNode("Province").InnerText;
                            }
                            XmlNodeList twonodes = xnlist[i].SelectSingleNode("NewLandMarkInfos").SelectNodes("NewLandMarkInfo");
                            for (int j = 0; j < twonodes.Count; j++)
                            {
                                if (twonodes[j].SelectNodes("LandMarkName").Count > 0)
                                {
                                    model.LandMarkName = twonodes[j].SelectSingleNode("LandMarkName").InnerText;
                                }
                                XmlNodeList nodes = twonodes[j].SelectSingleNode("LandMarkChildInfos").SelectNodes("LandMarkChildInfo");
                                if (nodes.Count > 0)
                                {
                                    for (int m = 0; m < nodes.Count; m++)
                                    {
                                        if (nodes[m].SelectNodes("LandMarkChildName").Count > 0)
                                        {
                                            model.LandMarkChildName = nodes[m].SelectSingleNode("LandMarkChildName").InnerText;
                                        }
                                        if (nodes[m].SelectNodes("Latitude").Count > 0)
                                        {
                                            model.Latitude = nodes[m].SelectSingleNode("Latitude").InnerText;
                                        }
                                        if (nodes[m].SelectNodes("Longitude").Count > 0)
                                        {
                                            model.Longitude = nodes[m].SelectSingleNode("Longitude").InnerText;
                                        }
                                        if (nodes[m].SelectNodes("LandMarkChildPinYin").Count > 0)
                                        {
                                            model.LandMarkChildPinYin = nodes[m].SelectSingleNode("LandMarkChildPinYin").InnerText;
                                        }
                                        if (nodes[m].SelectNodes("LandMarkChildCode").Count > 0)
                                        {
                                            model.LandMarkChildCode = nodes[m].SelectSingleNode("LandMarkChildCode").InnerText;
                                        }
                                        if (nodes[m].SelectNodes("MercatorX").Count > 0)
                                        {
                                            model.MercatorX = nodes[m].SelectSingleNode("MercatorX").InnerText;
                                        }
                                        if (nodes[m].SelectNodes("MercatorY").Count > 0)
                                        {
                                            model.MercatorY = nodes[m].SelectSingleNode("MercatorY").InnerText;
                                        }
                                        new EyouSoft.BLL.OtherStructure.BDiBiao().AddLandMark(model);
                                    }
                                }
                                else
                                {
                                    new EyouSoft.BLL.OtherStructure.BDiBiao().AddLandMark(model);
                                }
                            }

                        }
                    }
                }
                Success = true;
            }
            catch (Exception ex)
            {
                Success = false;
            }
            return Success;
        }

    }
}
