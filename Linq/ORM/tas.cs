using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Linq.ORM.Attribute;
using Linq.TypeHelpers;
using System.Text.RegularExpressions;

namespace Linq.ORM
{
    internal class tas
    {
        internal static Type gtty(Type yp)
        {
            pkv kv = tas.spk(yp);
            if (kv != null)
            {
                return kv.ttp;
            }
            else
            {
                return yp;
            }
        }
        static Dictionary<Type, pkv> tpca = new Dictionary<Type, pkv>();
        static Dictionary<Type, PropertyInfo[]> tprc = new Dictionary<Type, PropertyInfo[]>();
        static Func<PropertyInfo, bool> pr = x => x.GetIndexParameters().Length == 0;
        static Type spnt(Type yp)
        {
            if (yp != typeof(object))
            {
                var members = aorgptys(yp);
                IEnumerable<PropertyInfo> pks = members.Where(x => Column.hattr<PrimaryKeyAttribute>(x));
                if (pks.Count() > 0)
                {
                    return yp;
                }
                else
                {
                    return spnt(yp.BaseType);
                }
            }
            else
            {
                return null;
            }
        }

        static PropertyInfo[] aorgptys(Type ps)
        {
            if (!tprc.ContainsKey(ps))
            {
                lock (tprc)
                {
                    if (!tprc.ContainsKey(ps))
                    {
                        tprc.Add(ps, ps.GetProperties().Where(pr).ToArray());
                    }
                }
            }
            return tprc[ps];
        }

        internal static pkv spk(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException();
            }
            if (!tpca.ContainsKey(type))
            {
                lock (tpca)
                {
                    if (!tpca.ContainsKey(type))
                    {
                        if (type.IsClass)
                        { 
                            if (type == typeof(object))
                            {
                                throw new InvalidOperationException("实体类型不能为object");
                            }
                            if (!type.IsPublic)
                            {
                                throw new InvalidOperationException("实体类必须是public修饰");
                            }
                            if (type.IsAbstract)
                            {
                                throw new InvalidOperationException("实体类不能是抽象类");
                            }
                            if (type.IsSealed)
                            {
                                throw new InvalidOperationException("实体类不能是密封类");
                            }
                            if (type.GetConstructor(Type.EmptyTypes) == null)
                            {
                                throw new InvalidOperationException("实体类必须具有无参构造函数");
                            }
                            if (type.IsGenericType)
                            {
                                throw new InvalidOperationException("实体类不能是泛型");
                            }
                            pkv mpk = null;
                           
                            PropertyInfo[] ms = aorgptys(type);
                            IEnumerable<PropertyInfo> pks = ms.Where(x => Column.hattr<PrimaryKeyAttribute>(x));
                            if (pks.Count() > 0)
                            {
                                PropertyInfo pk = pks.First();
                                mpk = new pkv { na = pk.Name, mifp = pk, ttp = pk.DeclaringType };
                            }
                            if (mpk == null)
                            {
                                Type pt = spnt(type.BaseType);
                                if (pt == null)
                                {
                                    var pks2 = ms.Where(x => string.Equals(x.Name, "ID", StringComparison.OrdinalIgnoreCase));
                                    if (pks2.Count() == 1)
                                    {
                                        mpk = new pkv { na = pks2.First().Name, mifp = pks2.First(), ttp = type };
                                    }
                                    else
                                    {
                                        mpk = null;
                                    }
                                }
                                else
                                {
                                    mpk = spk(pt);
                                }
                            }
                            tpca.Add(type, mpk);
                        }
                        else
                        {
                            throw new InvalidOperationException("实体类目前只支持class，不支持其他结构");
                        }
                    }
                }
            }
            return tpca[type];

        }
        /// <summary>
        /// 获取obj的主键值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static pkv gpmv(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            pkv kv = spk(obj.GetType());
            if (kv == null)
            {
                return null;
            }
            else
            {
                if (kv.mifp is PropertyInfo)
                {
                    kv.aue = (kv.mifp as PropertyInfo).GetValue(obj, null);
                    return kv;
                }
                else
                {
                    throw new NotSupportedException("目前只支持属性");
                }
            }
        }
        static Dictionary<Type, List<Column>> ecc = new Dictionary<Type, List<Column>>();
        static Dictionary<MemberInfo, object[]> attrc = new Dictionary<MemberInfo, object[]>();

        public static object[] ga(Type table)
        {
            if (!attrc.ContainsKey(table))
            {
                lock (attrc)
                {
                    if (!attrc.ContainsKey(table))
                    {
                        attrc.Add(table, table.GetCustomAttributes(false));
                    }
                }
            }
            return attrc[table];
        }


        internal static string grna(Type type)
        {
            Type tat = tas.gtty(type);
            var ns = ga(tat).OfType<TableAttribute>();
            string n;
            if (ns.Count() > 0)
            {
                n = ns.First().Name;
            }
            else
            {
                n = tat.Name;
            }
            if (!Regex.IsMatch(n, "^[_a-zA-Z]\\w*$"))
            {
                throw new Exception(n + "是无效的表名");
            }
            return n;
        }
        internal static IList<Column> cssr(Type mt, bool hierarchy, Func<PropertyInfo, bool> fp)
        {
            IList<Column> l1 = null;
            List<Column> l2 = new List<Column>();
            if (!ecc.ContainsKey(mt))
            {
                lock (ecc)
                {
                    if (!ecc.ContainsKey(mt))
                    {
                        BindingFlags bindingFlag = BindingFlags.Public | BindingFlags.Instance;
                        if (!hierarchy)
                        {
                            bindingFlag |= BindingFlags.DeclaredOnly;
                        }
                        List<Column> _c_t = new List<Column>();
                        IList<PropertyInfo> ps = mt.GetProperties(bindingFlag);
                        if (ps != null)
                        {
                            for (int i = 0, len = ps.Count; i < len; i++)
                            {
                                PropertyInfo p = ps[i];
                                if (!Column.hattr<ColumnIgnoreAttribute>(p))
                                {
                                    if (TypeHelper.IsComplex(p.PropertyType))
                                    {
                                        _c_t.Add(new Column(p));
                                    }
                                    else
                                    {
                                        if (!TypeHelper.IsComplexType(p.PropertyType))
                                        {
                                            _c_t.Add(new Column(p));
                                        }
                                    }
                                }
                            }
                        }
                        ecc.Add(mt, _c_t);
                    }
                }
            }
            l1 = ecc[mt];

            for (int i = 0, lenf = l1.Count; i < lenf; i++)
            {
                if (fp == null)
                {
                    l2.Add(l1[i]);
                }
                else
                {
                    PropertyInfo p = l1[i].mif as PropertyInfo;
                    if (fp(p))
                    {
                        l2.Add(l1[i]);
                    }
                }
            }
            return l2;
        }
        static Func<PropertyInfo, bool> ipf = p => !Column.hattr<IdentityAttribute>(p) || Column.gattr(p).OfType<IdentityAttribute>().First().IdentityType != IdentityType.Increment;

        internal static IList<Column> ics(Type modelType)
        {
            Type entityType = gtty(modelType);
            return cssr(entityType, false, ipf);
        }

        internal static IList<Column> UpdateColumnSelector(Type modelType)
        {
            Type entityType = gtty(modelType);
            return cssr(entityType, false, ipf);
        }

        internal static IList<Column> SelectColumnSelector(Type modelType)
        {
            return cssr(modelType, true, null);
        }
    }
}
