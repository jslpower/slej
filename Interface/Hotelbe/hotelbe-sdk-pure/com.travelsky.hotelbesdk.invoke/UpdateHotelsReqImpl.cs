namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Text.RegularExpressions;

    public class UpdateHotelsReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            UpdateHotelsReqCondition basereqcondition = base.Basereqcondition as UpdateHotelsReqCondition;
            string pattern = "[0-9]{12}";
            if (string.IsNullOrEmpty(basereqcondition.Starttime))
            {
                throw new HotelbeException("起始时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Endtime))
            {
                throw new HotelbeException("结束时间不能为空!");
            }
            if (!Regex.IsMatch(basereqcondition.Starttime, pattern))
            {
                throw new HotelbeException("起始时间格式错误yyyyMMddHHmm!");
            }
            if (!Regex.IsMatch(basereqcondition.Endtime, pattern))
            {
                throw new HotelbeException("结束时间格式错误yyyyMMddHHmm!");
            }
        }

        public override void setReq()
        {
            UpdateHotelsReqCondition basereqcondition = base.Basereqcondition as UpdateHotelsReqCondition;
            base.basereq = new TH_UpdateHotelsRQ();
            ((TH_UpdateHotelsRQ) base.basereq).OtRequest.UpdateHotelsRQ.StarTime = basereqcondition.getStarttime();
            ((TH_UpdateHotelsRQ) base.basereq).OtRequest.UpdateHotelsRQ.EndTime = basereqcondition.getEndtime();
            basereqcondition.getType();
            if (basereqcondition.getType().Equals(UpdateHotelsReqCondition.ENUM_TYPE.TYPE_ROOMRATE))
            {
                ((TH_UpdateHotelsRQ) base.basereq).OtRequest.UpdateHotelsRQ.Type = "R";
            }
            else if (basereqcondition.Type.Equals(UpdateHotelsReqCondition.ENUM_TYPE.TYPE_AVAILABLE))
            {
                ((TH_UpdateHotelsRQ) base.basereq).OtRequest.UpdateHotelsRQ.Type = "Q";
            }
            else if (basereqcondition.getType().Equals(UpdateHotelsReqCondition.ENUM_TYPE.TYPE_RATEPLAN))
            {
                ((TH_UpdateHotelsRQ) base.basereq).OtRequest.UpdateHotelsRQ.Type = "C";
            }
            else if (basereqcondition.getType().Equals(UpdateHotelsReqCondition.ENUM_TYPE.TYPE_POLICY))
            {
                ((TH_UpdateHotelsRQ) base.basereq).OtRequest.UpdateHotelsRQ.Type = "P";
            }
            ((TH_UpdateHotelsRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

