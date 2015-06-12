namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class RespPageInfo
    {
        private string currentPage;
        private string endPos;
        private string startPos;
        private string totalNum;
        private string totalPageNum;
        private string totalPkgNum;

        public string CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            set
            {
                this.currentPage = value;
            }
        }

        public string EndPos
        {
            get
            {
                return this.endPos;
            }
            set
            {
                this.endPos = value;
            }
        }

        public string StartPos
        {
            get
            {
                return this.startPos;
            }
            set
            {
                this.startPos = value;
            }
        }

        public string TotalNum
        {
            get
            {
                return this.totalNum;
            }
            set
            {
                this.totalNum = value;
            }
        }

        public string TotalPageNum
        {
            get
            {
                return this.totalPageNum;
            }
            set
            {
                this.totalPageNum = value;
            }
        }

        public string TotalPkgNum
        {
            get
            {
                return this.totalPkgNum;
            }
            set
            {
                this.totalPkgNum = value;
            }
        }
    }
}

