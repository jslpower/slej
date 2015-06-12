using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
   public class GroupAccessory
   {
      /// <summary>
      /// 该行程单的主键
      /// </summary>
      public int SID;
      /// <summary>
      /// 该附件所属团队编码
      /// </summary>
      public int GroupID;
      /// <summary>
      /// 附件名称
      /// </summary>
      public string FileName;
      /// <summary>
      ///  附件大小（单位 KB）
      /// </summary>
      public int FileSize;
      /// <summary>
      /// 文档格式（扩展名）
      /// </summary>
      public string FileType;
      /// <summary>
      /// 附件地址
      /// </summary>
      public string FileURL;
      public int ParentID;
      public int ParentTypeID;
   }
}
