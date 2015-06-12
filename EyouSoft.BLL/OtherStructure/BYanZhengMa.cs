using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 验证码相关
    /// </summary>
    public class BYanZhengMa
    {
        private readonly EyouSoft.IDAL.OtherStructure.IYanZhengMa dal = new EyouSoft.DAL.OtherStructure.DYanZhengMa();

        #region private members
        /// <summary>
        /// 设置验证码状态，返回1成功，其它失败
        /// </summary>
        /// <param name="identityId">验证码编号[自增编号]</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SetStatus(int identityId, EyouSoft.Model.Enum.YanZhengMaStatus status)
        {
            if (identityId < 1) return 0;

            int dalRetCode = dal.SetStatus(identityId, status);

            return dalRetCode;
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入验证码信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.OtherStructure.MYanZhengMaInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.ShouJi) || string.IsNullOrEmpty(info.YanZhengMa)) return 0;
            info.IssueTime = DateTime.Now;

            int dalRetCode = dal.Insert(info);
            return dalRetCode;
        }

        /// <summary>
        /// 获取验证码信息
        /// </summary>
        /// <param name="shouJi">手机号码</param>
        /// <param name="yanZhengMa">验证码</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MYanZhengMaInfo GetInfo(string shouJi, string yanZhengMa, EyouSoft.Model.Enum.YanZhengMaLeiXing leiXing)
        {
            if (string.IsNullOrEmpty(shouJi) || string.IsNullOrEmpty(yanZhengMa)) return null;

            return dal.GetInfo(shouJi, yanZhengMa, leiXing);
        }

        /// <summary>
        /// 设置验证码为已使用，返回1成功，其它失败
        /// </summary>
        /// <param name="identityId"></param>
        /// <returns></returns>
        public int SetYiShiYong(int identityId)
        {
            return SetStatus(identityId, EyouSoft.Model.Enum.YanZhengMaStatus.已使用);
        }

        /// <summary>
        /// 随机生成验证码
        /// </summary>
        /// <param name="length">验证码长度（字符个数）</param>
        /// <returns></returns>
        public string CreateYanZhengMa(int length)
        {
            char[] items = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            string s = string.Empty;
            for (int i = 0; i < length; i++)
            {
                int _index = rnd.Next(0, 10);
                s += items[_index];
            }

            return s;
        }
        #endregion
    }
}
