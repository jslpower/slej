namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class ReqPageInfo
    {
        private string isPageView;
        private string reqNumOfEachPage;
        private string reqPageNo;

        public string IsPageView
        {
            get
            {
                return this.isPageView;
            }
            set
            {
                this.isPageView = value;
            }
        }

        public string ReqNumOfEachPage
        {
            get
            {
                return this.reqNumOfEachPage;
            }
            set
            {
                this.reqNumOfEachPage = value;
            }
        }

        public string ReqPageNo
        {
            get
            {
                return this.reqPageNo;
            }
            set
            {
                this.reqPageNo = value;
            }
        }
    }
}

