namespace com.travelsky.hotelbesdk.models.easyhotel.order
{
    using System;

    public class HotelCreditCardInfo
    {
        private ENUM_CARDCODE cardCode;
        private string cardNum;
        private ENUM_CARDTYPE cardType;
        private string cVV2;
        private string expireDate;
        private string iDNum;
        private ENUM_IDTYPE iDType;
        private string ownerName;
        private string tel;

        public ENUM_CARDCODE getCardCode()
        {
            return this.CardCode;
        }

        public string getCardNum()
        {
            return this.cardNum;
        }

        public ENUM_CARDTYPE getCardType()
        {
            return this.cardType;
        }

        public string getCVV2()
        {
            return this.cVV2;
        }

        public string getExpireDate()
        {
            return this.expireDate;
        }

        public string getIDNum()
        {
            return this.iDNum;
        }

        public ENUM_IDTYPE getIDType()
        {
            return this.iDType;
        }

        public string getOwnerName()
        {
            return this.ownerName;
        }

        public string getTel()
        {
            return this.tel;
        }

        public void setCardCode(ENUM_CARDCODE cardCode)
        {
            this.CardCode = cardCode;
        }

        public void setCardNum(string cardNum)
        {
            this.cardNum = cardNum;
        }

        public void setCardType(ENUM_CARDTYPE cardType)
        {
            this.cardType = cardType;
        }

        public void setCVV2(string cVV2)
        {
            this.cVV2 = cVV2;
        }

        public void setExpireDate(string expireDate)
        {
            this.expireDate = expireDate;
        }

        public void setIDNum(string iDNum)
        {
            this.iDNum = iDNum;
        }

        public void setIDType(ENUM_IDTYPE iDType)
        {
            this.iDType = iDType;
        }

        public void setOwnerName(string ownerName)
        {
            this.ownerName = ownerName;
        }

        public void setTel(string tel)
        {
            this.tel = tel;
        }

        public ENUM_CARDCODE CardCode
        {
            get
            {
                return this.cardCode;
            }
            set
            {
                this.cardCode = value;
            }
        }

        public string CardNum
        {
            get
            {
                return this.cardNum;
            }
            set
            {
                this.cardNum = value;
            }
        }

        public ENUM_CARDTYPE CardType
        {
            get
            {
                return this.cardType;
            }
            set
            {
                this.cardType = value;
            }
        }

        public string CVV2
        {
            get
            {
                return this.cVV2;
            }
            set
            {
                this.cVV2 = value;
            }
        }

        public string ExpireDate
        {
            get
            {
                return this.expireDate;
            }
            set
            {
                this.expireDate = value;
            }
        }

        public string IDNum
        {
            get
            {
                return this.iDNum;
            }
            set
            {
                this.iDNum = value;
            }
        }

        public ENUM_IDTYPE IDType
        {
            get
            {
                return this.iDType;
            }
            set
            {
                this.iDType = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return this.ownerName;
            }
            set
            {
                this.ownerName = value;
            }
        }

        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                this.tel = value;
            }
        }

        public enum ENUM_CARDCODE
        {
            CORD_SHENFAZHAN,
            CODE_ZHONGGUO,
            CODE_GONGSHANG,
            CODE_JIANSHE,
            CODE_NONGYE,
            CODE_PUDONGFAZHAN,
            CODE_GUANGDONGFAZHAN,
            CODE_ZHAOSHANG,
            CODE_JIAOTONG,
            CODE_GUANGDA,
            CODE_HUAXIA,
            CODE_XINGYE,
            CODE_ZHONGXIN,
            CODE_MINSHENG,
            CODE_SHANGHAI,
            CODE_PINGAN,
            CODE_JCB,
            CODE_AE,
            CODE_MASTER,
            CODE_DC,
            CODE_VISA
        }

        public enum ENUM_CARDTYPE
        {
            TYPE_AX,
            TYPE_DN,
            TYPE_JC,
            TYPE_MC,
            TYPE_VI,
            TYPE_UP
        }

        public enum ENUM_IDTYPE
        {
            IDTYPE_ID,
            IDTYPE_PASSPORT,
            IDTYPE_SOLDIER
        }
    }
}

