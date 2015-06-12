using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    //反馈信息类
   public class MFeedback
    {
       public int ID { get; set; }
       public string MessageType { get; set; }
        public string MsgContent { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public DateTime? submittime { get; set; }
    }

    public class MSearchFeedback
    {

        public string MessageType { get; set; }
        public string MsgContent { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public DateTime? starttime { get; set; }
        public DateTime? endtime { get; set; }
    }
}
