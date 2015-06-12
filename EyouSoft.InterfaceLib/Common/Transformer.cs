using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.travelsky.hotelbesdk.utils;
using System.Collections;

namespace EyouSoft.InterfaceLib.Common
{
    public class Transformer
    {
        public static Dictionary<T, T2> TransformToDic<T, T2>(HashtableSerailizable hashtable)
            where T : class
            where T2 : class
        {
            Dictionary<T, T2> dic = new Dictionary<T, T2>();
            if (hashtable != null)
            {
                foreach (DictionaryEntry dv in hashtable)
                {
                    dic.Add(dv.Key as T, dv.Value as T2);
                }
            }
            return dic;
        }
    }
}
