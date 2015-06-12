using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using Linq.Expressions;
using Linq.ORM;
using Linq.TypeHelpers;
using Linq.Bussiness;
using Linq.Expressions.ExpressionModels;
using System.Text.RegularExpressions;
using Linq.Expressions.Interface;
using System.Collections.ObjectModel;
using Linq.Expressions.ExpressionModels.Join;
using Linq.Expressions.Enums;
using Linq.Common;

namespace Linq
{
   /// <summary>
   /// 此类专用于生成一般的sql语句, 不支持复杂的sql语句。目前不支持表自己连接自己,lambda表达式内尽量不要嵌套太多复杂的式子。
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class ExpressionBuilder<T> : IExpressionBuilder<T> where T : new()
   {
      /// <summary>
      /// 表别名
      /// </summary>
      public string TableAlias { get; set; }
      List<WhereExpressionModel> w;
      List<SelectExpressionModel> sel;
      List<OrderByExpressionModel> ol;
      List<JoinExpressionModel> jL;
      internal virtual List<WhereExpressionModel> W
      {
         get { if (w == null)w = new List<WhereExpressionModel>(); return w; }
         set { w = value; }
      }
      internal virtual List<SelectExpressionModel> S
      {
         get { if (sel == null)sel = new List<SelectExpressionModel>(); return sel; }
         set { sel = value; }
      }
      internal virtual List<OrderByExpressionModel> O
      {
         get { if (ol == null)ol = new List<OrderByExpressionModel>(); return ol; }
         set { ol = value; }
      }
      internal virtual List<JoinExpressionModel> J
      {
         get { if (jL == null)jL = new List<JoinExpressionModel>(); return jL; }
         set { jL = value; }
      }
      List<ISelectExpressionBuilder> rs;
      public List<ISelectExpressionBuilder> Relates
      {
         get { if (rs == null) { rs = new List<ISelectExpressionBuilder>(); } return rs; }
         set { rs = value; }
      }
      public virtual SearchModel SearchInfo { get; set; }
      public bool Paging { get { return IP(false); } }
      protected bool HJL { get { return J.Any(x => x.haso); } }

      private TableNameInfo te;
      internal virtual TableNameInfo TI
      {
         get
         {
            if (te == null)
            {
               te = GTIO(typeof(T));
            }
            return te;
         }
      }
      string[] MS = new string[] { "IndexOf", "StartsWidth", "EndsWith" };
      bool ISMD(Expression exp)
      {
         return (exp is MethodCallExpression) && MaxUtils.Exists(MS, ((exp as MethodCallExpression).Method.Name));
      }
      private bool IP(bool throwException)
      {
         if (throwException)
         {
            if (SearchInfo == null || SearchInfo.PageInfo == null)
            {
               throw new InvalidOperationException("分页信息未指定");
            }
         }
         if (SearchInfo != null && SearchInfo.PageInfo != null)
         {
            if (SearchInfo.PageInfo.PageSize <= 0)
            {
               throw new InvalidOperationException("分页信息中的pagesize不正确：pagesize=" + SearchInfo.PageInfo.PageSize);
            }
            return true;
         }
         return false;
      }
      private object EV(Expression tr)
      {
         return System.Linq.Expressions.Expression.Lambda(tr).Compile().DynamicInvoke();
      }

      internal void ADS(SelectExpressionModel del)
      {
         if (del != null)
         {
            S.Insert(0, del);
         }
      }
      internal void ADS2(List<SelectExpressionModel> mls)
      {
         if (mls != null)
         {
            S.AddRange(mls);
         }
      }
      internal void ADW(WhereExpressionModel model)
      {
         if (model != null)
         {
            W.Add(model);
         }
      }
      internal void ADOB(OrderByExpressionModel m)
      {
         if (m != null && m.pres != null)
         {
            O.Add(m);
         }
      }
      internal void ADJ(JoinExpressionModel m)
      {
         if (m != null && m.essin != null)
         {
            J.Add(m);
         }
      }
      static internal bool ISTE(MemberExpression esp)
      {
         if (esp == null)
            return false;
         if (esp.Expression is MemberExpression)
         {
            return ISTE(esp.Expression as MemberExpression);
         }
         else if (esp.Expression is ParameterExpression)
         {
            return true;
         }
         else
         {
            return false;
         }
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="NN"></param>
      /// <returns></returns>
      internal string GW(Expression NN)
      {
         if (NN is LambdaExpression)
         {
            NN = (NN as LambdaExpression).Body;
         }
         if (NN is BinaryExpression)
         {
            BinaryExpression be = ((BinaryExpression)NN);
            string sb = "(";
            sb += GW(be.Left);
            if (be.NodeType == ExpressionType.AndAlso || be.NodeType == ExpressionType.OrElse || !ISMD(be.Left))
            {
               string type = GWString(be.NodeType); //二元运算符
               sb += type;
               string tmpStr = GW(be.Right); //值
               if (tmpStr == "null")
               {
                  if (be.NodeType == ExpressionType.Equal)
                  {
                     sb = sb.Substring(0, sb.Length - 1) + " is null";
                  }
                  else if (be.NodeType == ExpressionType.NotEqual)
                  {
                     sb = sb.Substring(0, sb.Length - 2) + " is not null";
                  }
               }
               else
               {
                  sb += tmpStr;
               }
            }
            return sb += ")";
         }
         else if (NN is MemberExpression)
         {
            MemberExpression me = ((MemberExpression)NN);
            Type mT;

            if (me.Member.MemberType == MemberTypes.Field)
            {
               mT = (me.Member as FieldInfo).FieldType;
            }
            else if (me.Member.MemberType == MemberTypes.Property)
            {
               mT = (me.Member as PropertyInfo).PropertyType;
            }
            else
            {
               throw new NotSupportedException();
            }

            string MN;
            if (me.Expression is MemberExpression)
            {
               MemberExpression me2 = me.Expression as MemberExpression;
               Type mT2 = null;
               if (me2.Member.MemberType == MemberTypes.Field)
               {
                  mT2 = (me2.Member as FieldInfo).FieldType;
               }
               else if (me2.Member.MemberType == MemberTypes.Property)
               {
                  mT2 = (me2.Member as PropertyInfo).PropertyType;
               }
               if (me2.Expression != null)
               {
                  if (typeof(ISelectExpressionBuilder).IsAssignableFrom(me2.Expression.Type))//== builder.EntityModel.xxx
                  {
                     TableNameInfo t2 = GTIO(me.Expression.Type);
                     if (!string.IsNullOrEmpty(t2.tan2))
                     {
                        return t2.tan2 + "." + new Column(me.Member).n;//.ColumnsFormatAliasName;
                     }
                     return new Column(me.Member).n;
                  }
               }
               MN = new Column(me.Member).n;
            }
            else
            {
               MN = Column.gn(me.Member);
            }
            object value = null;
            if (!ISTE(me))
            {
               value = EV(NN);
               if (value != null && typeof(ISelectExpressionBuilder).IsAssignableFrom(value.GetType()))
               {
                  var builder = value as ISelectExpressionBuilder;
                  builder.Relates.Add(this);
                  return builder.bs();
               }
               return CSFT(value, mT);
            }
            else
            {
               TableQueryColumnInfoCollection t = GEXNAME_Info(me);
               if (HJL)
               {
                  return t[0].tan2 + "." + t[0].cn2;
               }
               else
               {
                  return t[0].cn2;
               }
            }
         }
         else if (NN is NewArrayExpression)
         {
            NewArrayExpression ae = ((NewArrayExpression)NN);
            StringBuilder tmpstr = new StringBuilder();
            foreach (Expression ex in ae.Expressions)
            {
               tmpstr.Append(GW(ex));
               tmpstr.Append(",");
            }
            return tmpstr.ToString(0, tmpstr.Length - 1);
         }
         else if (NN is MethodCallExpression)
         {
            MethodCallExpression mce = (MethodCallExpression)NN;
            if (ISMD(mce))
            {
               string vs = GW(mce.Arguments[0]);
               vs = vs.Substring(1, vs.Length - 2);
               if (mce.Method.Name == "IndexOf")
               {
                  return string.Format("{0} like {1}", GW(mce.Object), "'%" + vs + "%'");
               }
               else if (mce.Method.Name == "StartsWith")
               {
                  return string.Format("{0} like {1}", GW(mce.Object), "'" + vs + "%'");
               }
               else if (mce.Method.Name == "EndsWith")
               {
                  return string.Format("{0} like {1}", GW(mce.Object), "'%" + vs + "'");
               }
            }
            else
            {
               if (mce.Method.Name == "In")
               {
                  return string.Format("{0} in ({1})", GW(mce.Arguments[0]), GW(mce.Arguments[1]));
               }
               else if (mce.Method.Name == "NotIn")
               {
                  return string.Format("{0} not in ({1})", GW(mce.Arguments[0]), GW(mce.Arguments[1]));
               }
               else if (mce.Method.Name == "Equal")
               {
                  return string.Format("{0}=({1})", GW(mce.Arguments[0]), GW(mce.Arguments[1]));
               }
               else
               {
                  if (typeof(ISelectExpressionBuilder).IsAssignableFrom(mce.Type))
                  {
                     var builder = (ISelectExpressionBuilder)EV(mce);
                     builder.Relates.Add(this);
                     return builder.bs();
                  }
                  try
                  {
                     object value = EV(mce);
                     if (value != null)
                     {
                        return TypeHelper.sfm(value, value.GetType());
                     }
                     else
                     {
                        return "null";
                     }
                     //object exeObj = null;
                     //object[] arguments;
                     //if (mce.Object != null)
                     //{
                     //   exeObj = System.Linq.Expressions.Expression.Lambda(mce.Object).Compile().DynamicInvoke();
                     //}
                     //arguments = new object[mce.Arguments.Count];
                     //for (int i = 0; i < mce.Arguments.Count; i++)
                     //{
                     //   arguments[i] = Expression.Lambda(mce.Arguments[i]).Compile().DynamicInvoke();
                     //}
                     //object value = mce.Method.Invoke(exeObj, arguments);
                     throw new NotSupportedException("目前不支持方法" + mce.Method.Name + "方法,请联系余韬");
                  }
                  catch
                  {
                  }
               }
            }
         }
         else if (NN is ConstantExpression)
         {
            ConstantExpression ce = ((ConstantExpression)NN);
            return CSFT(ce.Value, ce.Type);
         }
         else if (NN is UnaryExpression)
         {
            UnaryExpression ue = ((UnaryExpression)NN);
            return GW(ue.Operand);
         }
         return null;
      }
      internal string GWString(ExpressionType rewe)
      {
         switch (rewe)
         {
            case ExpressionType.AndAlso:
               return " and ";
            case ExpressionType.Equal:
               return "=";
            case ExpressionType.GreaterThan:
               return ">";
            case ExpressionType.GreaterThanOrEqual:
               return ">=";
            case ExpressionType.LessThan:
               return "<";
            case ExpressionType.LessThanOrEqual:
               return "<=";
            case ExpressionType.NotEqual:
               return "<>";
            case ExpressionType.OrElse:
               return " or ";
            case ExpressionType.Add:
            case ExpressionType.AddChecked:
               return "+";
            case ExpressionType.Subtract:
            case ExpressionType.SubtractChecked:
               return "-";
            case ExpressionType.Divide:
               return "/";
            case ExpressionType.Multiply:
            case ExpressionType.MultiplyChecked:
               return "*";
            default:
               return null;
         }
      }
      /// <summary>
      /// 分析连接语句
      /// </summary>
      /// <param name="ession"></param>
      /// <returns></returns>
      private List<Expression> AJLI(Expression ession)
      {
         List<Expression> bs = new List<Expression>();
         if (ession is LambdaExpression)
         {
            ession = (ession as LambdaExpression).Body;
         }
         if (ession.NodeType == ExpressionType.Parameter)
         {
            bs.Add(ession);
         }
         else if (ession is BinaryExpression)
         {
            BinaryExpression bin = (BinaryExpression)ession;
            if (ession.NodeType == ExpressionType.Equal)
            {
               bs.Add(bin);
            }
            else if (ession.NodeType == ExpressionType.AndAlso)
            {
               if (bin.Right is BinaryExpression)
               {
                  bs.AddRange(AJLI(bin.Right));
               }
               if (bin.Right is BinaryExpression)
               {
                  bs.AddRange(AJLI(bin.Left as BinaryExpression));
               }
            }
            else
            {
               throw new InvalidOperationException("无效的连接表达式");
            }
         }
         return bs;
      }
      internal virtual int YI { get; set; }
      protected virtual string YTA()
      {
         return "t" + (++YI);
      }

      /// <summary>
      /// 解析select表达式的表名，表别名
      /// </summary>
      protected internal TableQueryColumnInfoCollection GEXNAME_Info(Expression esxp)
      {
         TableQueryColumnInfoCollection ni = new TableQueryColumnInfoCollection();

         Expression er = null;
         if (esxp is LambdaExpression)
         {
            er = (esxp as LambdaExpression).Body;
         }
         else
         {
            er = esxp;
         }
         if (er != null)
         {
            if (er is BinaryExpression)
            {
               List<Expression> ttry = AJLI(er);
               for (int i = 0; i < ttry.Count; i++)
               {
                  Expression exp3 = ttry[i];
                  if (exp3 is BinaryExpression)
                  {
                     BinaryExpression fg23_0bb = exp3 as BinaryExpression;
                     if (fg23_0bb.NodeType != ExpressionType.Equal)
                     {
                        throw new NotSupportedException("目前不支持非=的连接表达式");
                     }

                     if (fg23_0bb.Left.NodeType == ExpressionType.MemberAccess && fg23_0bb.Right.NodeType == ExpressionType.MemberAccess)
                     {
                        var m1 = (fg23_0bb.Left as MemberExpression);
                        var m2 = (fg23_0bb.Right as MemberExpression);
                        ParameterExpression p1, p2;
                        if (m1.Expression is MemberExpression)
                        {
                           m1 = m1.Expression as MemberExpression;
                           p1 = m1.Expression as ParameterExpression;
                           if (p1 == null)
                           { throw new Exception("连接表达式嵌套深度超过2层，嵌套太深！不支持"); }
                        }
                        else
                        {
                           p1 = (m1.Expression as ParameterExpression);
                        }
                        if (m2.Expression is MemberExpression)
                        {
                           m2 = m2.Expression as MemberExpression;
                           p2 = m2.Expression as ParameterExpression;
                           if (p2 == null)
                           { throw new Exception("连接表达式嵌套深度超过2层，嵌套太深！不支持！"); }
                        }
                        else
                        {
                           p2 = (m2.Expression as ParameterExpression);
                        }

                        TableNameInfo t1 = GTIO(p1.Type);
                        TableNameInfo t2 = GTIO(p2.Type);
                        Column column1 = new Column(m1.Member);
                        Column column2 = new Column(m2.Member);
                        ni.Add(new TableQueryColumnInfo
                        {
                           cn = column1.n,
                           can = column1.n,
                           tan = t1.tan,
                           tn = t1.tn,
                           ttt = t1.ttt,
                           mifin2 = column1.mif,
                        });
                        ni.Add(new TableQueryColumnInfo
                        {
                           cn = column2.n,
                           can = column2.n,
                           tan = t2.tan,
                           tn = t2.tn,
                           ttt = t2.ttt,
                           mifin2 = column2.mif,
                        });
                     }
                  }

               }
               return ni;
            }
            if (er is MemberExpression) //纯粹单个成员
            {
               var hg44 = (er as MemberExpression);
               var parameter = (hg44.Expression as ParameterExpression);
               string parameterName = "";
               if (hg44.Expression.NodeType == ExpressionType.Parameter)
               {
                  parameterName = parameter.Name;

               }
               else if (hg44.Expression.NodeType == ExpressionType.Constant)
               {
                  if (hg44.Expression.Type == typeof(T))
                  {
                     ConstantExpression constant = hg44.Expression as ConstantExpression;
                     parameterName = "";
                  }
               }
               else if (hg44.Expression.NodeType == ExpressionType.MemberAccess)
               {
                  hg44 = hg44.Expression as MemberExpression;
                  parameter = hg44.Expression as ParameterExpression;
               }
               else
               {
                  throw new InvalidOperationException("成员访问表达式" + er + "格式错误!");
               }
               TableNameInfo t = GTIO(parameter.Type);

               Column column = new Column(hg44.Member);
               ni.Add(new TableQueryColumnInfo
               {
                  cn = column.n,
                  can = column.n,
                  tan = t.tan,
                  tn = t.tn,
                  ttt = t.ttt,
                  mifin2 = column.mif,
               });
               return ni;
            }
            if (er is NewArrayExpression) //没有别名
            {
               //NewArrayExpression arrexp = exp2 as NewArrayExpression;
               //for (int i = 0; i < arrexp.Expressions.Count; i++)
               //{
               //   if (arrexp.Expressions[i] is MemberExpression)
               //   {
               //      TableQueryColumnInfo namesTemp = GetExpressionNameInfo(arrexp.Expressions[i])[0];
               //      NameInfoList.Add(namesTemp);
               //   }
               //   else
               //   {
               throw new Exception("不支持的表达式");
               //   }
               //}
               //return DistinctColumnName(NameInfoList);
            }
            if (er is ParameterExpression)
            {
               TableNameInfo reww = GTIO(er.Type);
               IList<Column> ps = tas.cssr(reww.ttt, false, null);
               for (int t = 0; t < ps.Count; t++)
               {
                  Column erwerc = ps[t];
                  ni.Add(new TableQueryColumnInfo
                  {
                     cn = erwerc.n,
                     can = erwerc.n,
                     tan = reww.tan,
                     tn = reww.tn,
                     ttt = reww.ttt,
                     mifin2 = erwerc.mif,
                  });
               }
               return ni;
            }
            if (er is NewExpression) //别名
            {
               NewExpression bg_l12 = er as NewExpression;
               for (int i = 0; i < bg_l12.Arguments.Count; i++)
               {
                  Expression argumentExpression = bg_l12.Arguments[i];
                  string aliasName = "";
                  if (bg_l12.Members[i].Name.IndexOf("_") > -1) //Members都是MemberInfo，newexp.Members[i].Name就是{ name=123 }中的name
                  {
                     aliasName = bg_l12.Members[i].Name.Substring(bg_l12.Members[i].Name.IndexOf("_") + 1); //get_name
                  }
                  else
                  {
                     aliasName = bg_l12.Members[i].Name;
                  }
                  if (argumentExpression is MemberExpression)
                  {
                     TableQueryColumnInfo temp = GEXNAME_Info(argumentExpression)[0];
                     ni.Add(new TableQueryColumnInfo
                     {
                        cn = temp.cn,
                        can = aliasName,
                        tan = temp.tan,
                        tn = temp.tn,
                        mifin2 = temp.mifin2,
                        ttt = temp.ttt,
                     });
                  }
                  else if (argumentExpression is ParameterExpression)
                  {
                     TableNameInfo t1 = GTIO(argumentExpression.Type);
                     IList<Column> ps = tas.cssr(t1.ttt, false, null);
                     for (int t = 0; t < ps.Count; t++)
                     {
                        Column erfds23 = ps[t];
                        ni.Add(new TableQueryColumnInfo
                        {
                           cn = erfds23.n,
                           can = erfds23.n,
                           tan = t1.tan,
                           tn = t1.tn,
                           ttt = t1.ttt,
                           mifin2 = erfds23.mif,
                        });
                     }
                  }
               }
               return DSC_Name(ni);
            }

            if (er is UnaryExpression)
            {
               UnaryExpression qwr = er as UnaryExpression;

               if (qwr.NodeType == ExpressionType.Convert) //比如添加一个表达式是Expression<Func<T,object>> ,而输入的是 x => x.OrderState（其中OrderState是枚举)，则lambda表达式的Body将会是UnaryExpression, 将枚举转为object属于一元运算 
               {
                  ni.AddRange(GEXNAME_Info(qwr.Operand));
               }
               return ni;
            }
            if (er is ConstantExpression)
            {
               ConstantExpression ceq = er as ConstantExpression;
               if (ceq.Value != null)
               {
                  ni.Add(new TableQueryColumnInfo
                  {
                     cn = CSFT(ceq.Value, ceq.Type),
                     can = ceq.Value.GetType().FullName,
                     tan = "",
                     tn = "",
                     mifin2 = null,
                     ttt = null,
                  });
               }
               return ni;
            }
            //if (exp2 is MethodCallExpression)
            //{
            //   MethodCallExpression methodExp = exp2 as MethodCallExpression;
            //   MemberExpression memberExp = methodExp.Arguments[0] as MemberExpression;
            //   ParameterExpression p = memberExp.Expression as ParameterExpression;
            //   NameInfoList.tableAliasNames = new string[] { p.Name };
            //   NameInfoList.columnNames = new string[] { memberExp.Member.Name };
            //   NameInfoList.columnsAliasNames = null;
            //   NameInfoList.tableTypeNames = null;
            //}
         }
         return null;
      }
      TableQueryColumnInfoCollection DSC_Name(TableQueryColumnInfoCollection ns)
      {
         TableQueryColumnInfoCollection list = new TableQueryColumnInfoCollection();

         for (int i = 0; i < ns.Count; i++)
         {
            TableQueryColumnInfo info = ns[i];
            //if (info.ColumnName != info.ColumnsAliasName)
            //{
            //   list.Add(info);
            //}
            //else
            //{
            //   //如果后面存在同名但有别名的信息，则到时候加这个别名的， 而不加info这个当前的.
            //   if (names.Exists(x => x.ColumnName == info.ColumnName && x.ColumnName != x.ColumnsAliasName && x.TableAliasName == info.TableAliasName))
            //   {
            //      continue;
            //   }
            //   else
            //   {
            list.Add(info);
            //   }
            //}
         }
         return list;
      }

      Dictionary<Type, TableNameInfo> tid;
      public Dictionary<Type, TableNameInfo> TableInfoDictioanry
      {
         get
         {
            if (tid == null)
            {
               tid = new Dictionary<Type, TableNameInfo>();
            }
            return tid;
         }
         set
         {
            tid = value;
         }
      }
      public void InitTableInfo()
      {
         int i = 0;
         if (J.Count > 0)
         {
            for (int k = 0; k < J.Count; k++)
            {
               JoinExpressionModel model = J[k];
               if (model.haso)
               {
                  var list = AJLI(model.essin);
                  for (int j = 0; j < list.Count; j++)
                  {
                     BinaryExpression b = list[j] as BinaryExpression;
                     ParameterExpression lp = (b.Left as MemberExpression).Expression as ParameterExpression;
                     ParameterExpression rp = (b.Right as MemberExpression).Expression as ParameterExpression;

                     Type li = tas.gtty(lp.Type);
                     Type lr = tas.gtty(rp.Type);
                     TableNameInfo info = new TableNameInfo { tan = YTA(), tn = tas.grna(li), ttt = li };
                     TableNameInfo info2 = new TableNameInfo { tan = YTA(), tn = tas.grna(lr), ttt = lr };
                     if (info.tan == info.tn)
                     {
                        info.tan = info.tan + "1";
                     }
                     if (info2.tan == info2.tn)
                     {
                        info2.tan = info2.tan + "1";
                     }
                     if (!TableInfoDictioanry.ContainsKey(li))
                     {
                        TableInfoDictioanry.Add(li, info);
                        i++;
                     }
                     if (!TableInfoDictioanry.ContainsKey(lr))
                     {
                        TableInfoDictioanry.Add(lr, info2);
                        i++;
                     }
                  }
               }
               else
               {
                  Type tt = tas.gtty(((model.essin as LambdaExpression).Body).Type);
                  if (!TableInfoDictioanry.ContainsKey(tt))
                  {
                     TableNameInfo info = new TableNameInfo { tan = YTA(), tn = tas.grna(tt), ttt = tt };
                     TableInfoDictioanry.Add(tt, info);
                  }
               }
            }
         }
         Type mtype = tas.gtty(typeof(T));
         if (!TableInfoDictioanry.ContainsKey(mtype))
         {
            if (string.IsNullOrEmpty(this.TableAlias))
            {
               TableInfoDictioanry.Add(mtype, new TableNameInfo { tn = tas.grna(mtype), tan = "", ttt = mtype });
            }
            else
            {
               TableInfoDictioanry.Add(mtype, new TableNameInfo { tn = tas.grna(mtype), tan = this.TableAlias, ttt = mtype });
            }
         }
      }

      protected internal TableNameInfo GTIO(Type ty)
      {
         ty = tas.gtty(ty);
         if (!TableInfoDictioanry.ContainsKey(ty))
         {
            InitTableInfo();
         }
         if (!TableInfoDictioanry.ContainsKey(ty))
         {
            TableInfoDictioanry.Add(ty, new TableNameInfo { tn = tas.grna(ty), tan = "", ttt = ty });
         }
         return TableInfoDictioanry[ty];
      }
      /// <summary>
      ///  清理内部表达式
      /// </summary>
      public void Clear()
      {
         W.Clear();
         S.Clear();
         O.Clear();
         TableInfoDictioanry = null;
         SearchInfo = null;
      }
      private string CSFT(object value, Type ty)
      {
         return TypeHelper.sfm(value, ty);
      }

      private Dictionary<SelectExpressionModel, TableQueryColumnInfoCollection> GCI(YieldMoel yyydrw)
      {
         List<SelectExpressionModel> distinctedSelectList = new List<SelectExpressionModel>();
         Dictionary<SelectExpressionModel, TableQueryColumnInfoCollection> qweffff = new Dictionary<SelectExpressionModel, TableQueryColumnInfoCollection>();

         List<SelectExpressionModel> dfeqww = new List<SelectExpressionModel>();
         if (yyydrw == YieldMoel.Distinct)
         {
            dfeqww = S.Where(x => x is DistinctExpressionModel).ToList();
         }
         else if (yyydrw == YieldMoel.Max)
         {
            dfeqww = S.Where(x => x is MaxExpressionModel).ToList();
         }
         else if (yyydrw == YieldMoel.Min)
         {
            dfeqww = S.Where(x => x is MinExpressionModel).ToList();
         }
         else if (yyydrw == YieldMoel.Sum)
         {
            dfeqww = S.Where(x => x is SumExpressionModel).ToList();
         }
         else if (yyydrw == YieldMoel.Count)
         {
            dfeqww = S.Where(x => x is CountExpressionModel).ToList();
         }
         else if (yyydrw == YieldMoel.CountForPaging || yyydrw == YieldMoel.Exists)
         {
            dfeqww = new List<SelectExpressionModel>();
         }
         else // if (mode == SelectSQLYieldMode.None)
         {
            dfeqww = S;
         }
         for (int i = 0; i < dfeqww.Count; i++)
         {
            SelectExpressionModel em = dfeqww[i];
            if (!qweffff.ContainsKey(em))
            {
               if (em is SelectChildQueryModel)
               {
                  qweffff.Add(em, new TableQueryColumnInfoCollection { 
                     new TableQueryColumnInfo { can = em.als, iscq = true,   }
                  });
               }
               else
               {
                  TableQueryColumnInfoCollection list = new TableQueryColumnInfoCollection();
                  if (em.sion != null)
                  {
                     list = GEXNAME_Info(em.sion);
                     if (!string.IsNullOrEmpty(em.als)) //selectAs
                     {
                        list[0].can = em.als;
                     }
                     distinctedSelectList.Add(em);
                  }
                  qweffff.Add(em, list);
               }
            }
         }
         Dictionary<string, int> dsqeidic = new Dictionary<string, int>();
         for (int i = 0; i < distinctedSelectList.Count; i++)
         {
            SelectExpressionModel trewd = distinctedSelectList[i];
            TableQueryColumnInfoCollection nlalist = qweffff[trewd];
            if (nlalist == null || nlalist.Count == 0)
            {
               continue;
            }
            if (nlalist[0].iscq)
            {
               TableQueryColumnInfo cnmexm = nlalist[0];
               if (string.IsNullOrEmpty(cnmexm.can))
               {
                  throw new InvalidOperationException("子查询必须具有别名");
               }
               if (qweffff.SelectMany(x => x.Value).Except(new TableQueryColumnInfo[] { cnmexm }).Any(x => x.can == cnmexm.can))
               {
                  throw new Exception("引用了重复的列名:" + cnmexm.can);
               }
            }
            else
            {
               for (int c = 0; c < nlalist.Count; c++)
               {
                  TableQueryColumnInfo cnoi = nlalist[c];
                  if (string.IsNullOrEmpty(cnoi.cn))
                  {
                     continue;
                  }
                  if (!string.IsNullOrEmpty(trewd.als))
                  {
                     cnoi.can = trewd.als;
                  }
                  foreach (KeyValuePair<SelectExpressionModel, TableQueryColumnInfoCollection> k in qweffff)
                  {
                     if (k.Value != null)
                     {
                        foreach (TableQueryColumnInfo tigm in k.Value)
                        {
                           if (tigm != null && tigm != cnoi && string.Equals(tigm.can, cnoi.can, StringComparison.OrdinalIgnoreCase))
                           {
                              if (string.Equals(tigm.cn, cnoi.cn, StringComparison.OrdinalIgnoreCase) && string.Equals(tigm.tan, cnoi.tan)) //列名相同，列别名相同，
                              {
                                 tigm.cn = null; //不论item的表是否是主表，都得删
                                 tigm.can = null;
                              }
                              else //列名不相同，列别名相同，
                              {
                                 if (!dsqeidic.ContainsKey(tigm.can))
                                 {
                                    dsqeidic.Add(tigm.can, 1);
                                 }
                                 tigm.can = tigm.can + "__" + tigm.tn + "__" + dsqeidic[tigm.can]++;
                              }
                           }
                        }
                     }
                  }
               }
            }
            nlalist.RemoveAll(x => x.cn == null);
         }
         int cc = qweffff.Values.Sum(x => x.Count);
         if (yyydrw == YieldMoel.Min || yyydrw == YieldMoel.Max || yyydrw == YieldMoel.Sum)
         {
            if (cc == 0)
            {
               throw new InvalidOperationException("筛选列使用聚合函数时，不能传入0个列");
            }
            if (cc > 1)
            {
               throw new InvalidOperationException("筛选列使用聚合函数时，不能传入多个列");
            }
         }
         return qweffff;
      }

      #region IExpressionBuilder成员
      public string bssql()
      {
         return BSL(YieldMoel.None);
      }

      private string BSL(YieldMoel hjer)
      {
         if (hjer == YieldMoel.None)
         {
            SelectExpressionModel m = S.FirstOrDefault(x => x is IJH);
            if (m is MaxExpressionModel)
            {
               hjer = YieldMoel.Max;
            }
            else if (m is DistinctExpressionModel)
            {
               hjer = YieldMoel.Distinct;
            }
            else if (m is MinExpressionModel)
            {
               hjer = YieldMoel.Min;
            }
            else if (m is SumExpressionModel)
            {
               hjer = YieldMoel.Sum;
            }
            else if (m is TopExpressionModel)
            {
               hjer = YieldMoel.Top;
            }
            else if (m is CountExpressionModel)
            {
               hjer = YieldMoel.Count;
            }
         }

         Dictionary<SelectExpressionModel, TableQueryColumnInfoCollection> SelectListAll = GCI(hjer);
         int cc = SelectListAll.Values.Sum(x => x.Count);
         if (hjer == YieldMoel.Min || hjer == YieldMoel.Max || hjer == YieldMoel.Sum)
         {
            if (cc == 0)
            {
               throw new InvalidOperationException("筛选列使用" + hjer + "时，不能传入0个列");
            }
            if (cc > 1)
            {
               throw new InvalidOperationException("筛选列使用" + hjer + "时，不能传入多个列");
            }
         }

         string select = "";
         string field = "";
         switch (hjer)
         {
            case YieldMoel.RowNumber:
               select = "select {0},row_number() over(" + this.BOB().TrimStart().TrimEnd() + ") as RowNumber from " + TI.tn2; break;
            case YieldMoel.Count:
               select = "select count({0}{{0}}) from " + TI.tn2; break;
            case YieldMoel.CountForPaging:
            case YieldMoel.Exists:
               select = "select count(1) from " + TI.tn2; break;
            case YieldMoel.Distinct:
               select = "select distinct {0} from " + TI.tn2; break;
            case YieldMoel.Max:
               select = "select max({0}) from " + TI.tn2; break;
            case YieldMoel.Min:
               select = "select min({0}) from " + TI.tn2; break;
            case YieldMoel.Sum:
               select = "select sum({0}) from " + TI.tn2; break;
            case YieldMoel.Top:
               select = "select top ({0}) {{0}} from " + TI.tn2; break;
            default:
               select = "select {0} from " + TI.tn2; break;
         }
         if (!string.IsNullOrEmpty(TI.tan))
         {
            select += " as " + TI.tan2;
         }
         if (SelectListAll.Any(x => x.Key is TopExpressionModel))
         {
            select = string.Format(select, (SelectListAll.FirstOrDefault(x => x.Key is TopExpressionModel).Key as TopExpressionModel).rct);
         }
         if (hjer == YieldMoel.Count)
         {
            bool flag5 = true;
            if (SelectListAll.Any(x => x.Key is CountExpressionModel))
            {
               CountExpressionModel cm = SelectListAll.FirstOrDefault(x => x.Key is CountExpressionModel).Key as CountExpressionModel;
               if (cm.CountType == CTType.Distinct)
               {
                  flag5 = false;
                  select = string.Format(select, "distinct ");
               }
            }
            if (flag5)
            {
               select = string.Format(select, "");
               select = string.Format(select, "1");
            }
         }

         int columnCount = 0;
         int nochildCount = 0;
         foreach (KeyValuePair<SelectExpressionModel, TableQueryColumnInfoCollection> info in SelectListAll)
         {
            SelectExpressionModel expressionModel = info.Key;

            TableQueryColumnInfoCollection List = info.Value;
            if (expressionModel is SelectChildQueryModel)
            {
               SelectChildQueryModel child = expressionModel as SelectChildQueryModel;
               if (field != "")
               {
                  field += ",";
               }
               if (string.IsNullOrEmpty(child.als))
               {
                  throw new ArgumentNullException("子查询别名不能为空");
               }
               field += "(" + child.cq.bs() + ") as " + child.als;
               columnCount++;
            }
            else
            {
               for (int c = 0; c < List.Count; c++, columnCount++)
               {
                  TableQueryColumnInfo currentNameInfo = List[c];
                  if (field != "")
                  {
                     field += ",";
                  }
                  if (HJL && !string.IsNullOrEmpty(currentNameInfo.tan2))
                  {
                     field += currentNameInfo.tan2 + "." + currentNameInfo.cn2;
                  }
                  else
                  {
                     field += currentNameInfo.cn2;
                  }
                  if (!string.IsNullOrEmpty(currentNameInfo.can) && currentNameInfo.can != currentNameInfo.cn)
                  {
                     field += " as " + currentNameInfo.can2;
                  }
                  nochildCount++;
               }
            }
         }
         if (nochildCount == 0) //非子查询的列为空
         {
            if (!string.IsNullOrEmpty(field))
            {
               field = field.Insert(0, "*,");
            }
            else
            {
               field = field.Insert(0, "*");
            }
         }

         string select2 = string.Format(select, field);

         //连接语句
         for (int d = 0; d < J.Count; d++)
         {
            JoinExpressionModel joinExpression = J[d] as JoinExpressionModel;
            TableQueryColumnInfoCollection condition = null;
            if (joinExpression.haso)
            {
               condition = GEXNAME_Info(joinExpression.essin);
            }
            if (joinExpression.jt == JTypes.InnerJoin)
            {
               select2 += " inner";
            }
            if (joinExpression.jt == JTypes.LeftOuterJoin)
            {
               select2 += " left outer";
            }
            if (joinExpression.jt == JTypes.RightOuterJoin)
            {
               select2 += " right outer";
            }
            if (joinExpression.jt == JTypes.CrossJoin)
            {
               select2 += " cross";
            }
            select2 += " join ";

            if (joinExpression.haso)
            {
               for (int r = 0; r < condition.Count; r += 2)
               {
                  if (r == 0)
                  {
                     select2 += condition[1].tn2 + " as " + condition[1].tan2 + " on (";
                  }
                  if (r >= 2)
                  {
                     select2 += " and ";
                  }
                  select2 += condition[r].tan2 + "." + condition[r].cn2 + "=" + condition[r + 1].tan2 + "." + condition[r + 1].cn2;
               }
               select2 += ")";
            }
            else
            {
               TableNameInfo tinfo = GTIO(tas.gtty((joinExpression.essin as LambdaExpression).Body.Type));
               select2 += tinfo.tn2;
            }
         }
         return select2;
      }
      public string bwsql()
      {
         return BWS(W);
      }
      private string BWSL(Expression expressions)
      {
         return BWS(new List<WhereExpressionModel> { new WhereExpressionModel { exss = expressions } });
      }

      private void ARS()
      {
         foreach (var item in Relates)
         {
            item.InitTableInfo();
            foreach (KeyValuePair<Type, TableNameInfo> k in item.TableInfoDictioanry)
            {
               if (!this.TableInfoDictioanry.ContainsKey(k.Key))
               {
                  this.TableInfoDictioanry.Add(k.Key, k.Value);
               }
               else
               {
                  this.TableInfoDictioanry[k.Key] = k.Value;
               }
            }
         }
      }
      private string BWS(List<WhereExpressionModel> essions)
      {
         ARS();
         StringBuilder str = new StringBuilder();
         if (essions != null)
         {
            for (int i = 0; i < essions.Count; i++)
            {
               WhereExpressionModel wsel = essions[i];
               if (str.Length > 0)
               {
                  str.Append(" " + wsel.lj + " ");
               }
               if (wsel.exss != null)
               {
                  str.Append(GW(wsel.exss));
               }
               else if (wsel.eb != null)
               {
                  str.Append(wsel.eb.bs());
               }
               else if (!string.IsNullOrEmpty(wsel.ws))
               {
                  str.Append(wsel.ws);
               }
            }
         }
         if (str.Length > 0)
         {
            str.Insert(0, " where ");
         }
         return str.ToString();
      }
      public string bcsql()
      {
         return BSL(YieldMoel.Count) + bwsql();
      }
      private string BPS()
      {
         return BSL(YieldMoel.CountForPaging);
      }
      public string bpsql()
      {
         //倒序分页
         if (IP(true))
         {
            //分页语句（内层嵌套的）
            if (O.Count == 0)
            {
               throw new Exception("OrderBy方法未调用, 必须调用OrderBy才能分页!");
            }
            if (SearchInfo.PageInfo.PageIndex < 1)
            {
               throw new InvalidOperationException("页码不正确!");
            }
            if (SearchInfo.PageInfo.PageSize <= 0)
            {
               throw new InvalidOperationException("分页的pageSize不能小于等于0!");
            }
            string str1 = bwsql();
            string str2 = BPS() + str1;
            string str3 = BSL(YieldMoel.RowNumber) + str1;
            return string.Format("declare @count int;set @count=({0});select @count as RowTotalCount;select * from ({1}) rr where rr.RowNumber between {2} and {3}",
               str2, str3, (SearchInfo.PageInfo.PageIndex - 1) * SearchInfo.PageInfo.PageSize + 1, (SearchInfo.PageInfo.PageIndex) * SearchInfo.PageInfo.PageSize);
         }
         return "";
      }
      private string BOB()
      {
         StringBuilder bnstr = new StringBuilder();
         int q = 0;
         Dictionary<string, string> vb = new Dictionary<string, string>();
         for (int i = 0; i < O.Count; i++)
         {
            OrderByExpressionModel pre = O[i];
            if (pre == null || pre == null)
            {
               throw new NullReferenceException("未发现排序表达式");
            }
            TableQueryColumnInfoCollection nios48 = GEXNAME_Info(pre.pres);

            for (int c = 0; c < nios48.Count; c++)
            {
               TableQueryColumnInfo nio = nios48[c];
               string str = string.IsNullOrEmpty(nio.tan) ? nio.cn2 : ((nio.tan2 + ".") + nio.cn2);
               if (!vb.ContainsKey(str))
               {
                  vb.Add(str, "");
               }
               else
               {
                  continue;
               }
               if (i == 0 && c == 0)
               {
                  bnstr.Append(" order by ");
               }
               if (q > 0)
               {
                  bnstr.Append(",");
               }
               q++;
               if (pre.o)
               {
                  bnstr.Append(str + " asc");
               }
               else
               {
                  bnstr.Append(str + " desc");
               }
            }
         }
         return bnstr.ToString();
      }
      public string bs()
      {
         return bssql() + bwsql() + BOB();
      }
      #endregion

      #region IExpressionBuilder`T成员
      /// <summary>
      /// 生成insert语句
      /// </summary>
      /// <param name="m"></param>
      /// <returns></returns>
      public string bisql(T m)
      {
         if (m == null)
         {
            throw new NullReferenceException("你传入的" + typeof(T) + "的model为null,因此错误");
         }
         StringBuilder cs = new StringBuilder();
         StringBuilder cc = new StringBuilder();
         IList<Column> cs2 = tas.ics(m.GetType());
         if (cs2 == null || cs2.Count == 0)
         {
            throw new InvalidOperationException("没有筛选到要插入的列名集合");
         }
         for (int sqw = 0; sqw < cs2.Count; sqw++)
         {
            Column column = cs2[sqw];
            if (sqw > 0)
            {
               cs.Append(",");
               cc.Append(",");
            }
            cs.Append(column.fn);
            cc.Append(column.gv(m));
         }
         return "insert into " + TI.tn2 + " (" + cs + ") values(" + cc + ")";
      }
      /// <summary>
      /// 生成update语句
      /// </summary>
      /// <param name="m"></param>
      /// <returns></returns>
      public string busql(T m)
      {
         return busql(m, null, null, null);
      }
      /// <summary>
      /// 生成update语句
      /// </summary>
      /// <param name="m"></param>
      /// <returns></returns>
      public string busql(T m, Expression<Func<T, bool>> wp)
      {
         return busql(m, null, null, wp);
      }
      /// <summary>
      /// 生成update语句
      /// </summary>
      /// <param name="m"></param>
      /// <returns></returns>
      public string busql(T m, Expression<Func<T, object>> usp, Expression<Func<T, bool>> wp)
      {
         return busql(m, null, usp, wp);
      }
      /// <summary>
      /// 生成update语句
      /// </summary>
      /// <param name="m"></param>
      /// <returns></returns>
      public string busql(T m, Expression<Func<T, object>> usp, Expression<Func<T, object>> uecsp, Expression<Func<T, bool>> wherePredicate)
      {
         if (m == null)
         {
            throw new NullReferenceException();
         }
         string[] updateFields = null;
         string[] updateExceptFields = null;
         if (usp != null)
         {
            updateFields = GEXNAME_Info(usp).cn2ss2;
         }
         if (uecsp != null)
         {
            updateExceptFields = GEXNAME_Info(uecsp).cn2ss2;
         }
         if (updateFields != null && updateExceptFields != null)
         {
            if (updateFields.Intersect(updateExceptFields).Count() > 0)
            {
               throw new InvalidOperationException("要更新的列和要排除的列有重复，不能重复，请检查!");
            }
         }
         StringBuilder updateColumns = new StringBuilder();
         IList<Column> columns = tas.UpdateColumnSelector(m.GetType());
         if (columns == null || columns.Count == 0)
         {
            throw new InvalidOperationException("没有筛选到要更新的列名集合");
         }
         for (int i = 0; i < columns.Count; i++)
         {
            Column column = columns[i];
            if (updateFields == null || updateFields.Length == 0 || (updateFields != null && MaxUtils.Exists(updateFields, column.n)))
            {
               if (updateExceptFields == null || !MaxUtils.Exists(updateExceptFields, column.n))
               {
                  if (updateColumns.Length > 0)
                  {
                     updateColumns.Append(",");
                  }
                  updateColumns.Append(column.fn + "=" + column.gv(m));
               }
            }
         }
         if (updateColumns.Length == 0)
         {
            throw new Exception("没有找到要更新的列！");
         }
         if (wherePredicate == null)
         {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "xi");
            pkv key = tas.gpmv(m);
            if (key == null)
            {
               throw new Exception("此方法只支持定义了主键的表，但是没找到该表的主键在哪里，因此错误！");
            }
            BinaryExpression binaryExpression = Expression.MakeBinary(ExpressionType.Equal, Expression.PropertyOrField(parameter, key.na), Expression.Constant(key.aue));
            wherePredicate = (Expression<Func<T, bool>>)Expression.Lambda(binaryExpression, parameter);
         }
         return "update " + TI.tn2 + " set " + updateColumns + BWSL(wherePredicate);
      }
      /// <summary>
      /// 生成delete语句
      /// </summary>
      /// <param name="m"></param>
      /// <returns></returns>
      public string bdsql()
      {
         return bdsql(null);
      }
      /// <summary>
      /// 生成delete语句
      /// </summary>
      /// <param name="m"></param>
      /// <returns></returns>
      public string bdsql(Expression<Func<T, bool>> wp)
      {
         return "delete from " + TI.tn2 + BWSL(wp);
      }
      #endregion
   }
}