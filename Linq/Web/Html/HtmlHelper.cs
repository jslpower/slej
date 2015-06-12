using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Linq.Mvc3;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Linq.Web.Html;
using Linq.TypeHelpers;
using Linq.Web.Html.Interface;
using Linq.Web.Html.Attrib;
using Linq.Web.Html.Enums;
using System.Text.RegularExpressions;

namespace Linq.Web.Html
{
    public enum NameMode
    {
        ID,
        Name,
    }
    public class HtmlHelper
    {
        public object Model { get; set; }
        internal IDictionary<string, IValueFormatter> MemberFormatterCollections;
        public bool IsAllControlEnabled { get; set; }
        internal static string CreateSubPropertyName(string propertyName, NameMode mode)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new Exception("属性名不能为空");
            }
            if (mode == NameMode.Name)
            {
                return "." + propertyName;
            }
            if (mode == NameMode.ID)
            {
                return "_" + propertyName;
            }
            throw new Exception("");
        }
        internal static string CreateSubIndexName(string index, NameMode mode)
        {
            if (string.IsNullOrEmpty(index))
            {
                throw new Exception("索引不能为空值");
            }
            if (mode == NameMode.Name)
            {
                return "[" + index + "]";
            }
            if (mode == NameMode.ID)
            {
                return "_" + index + "_";
            }
            throw new Exception("");
        }
        internal string FormatValue(string name, object value)
        {
            return FormatValue(name, value, null);
        }
        internal static object Eval(Expression exp, object model)
        {
            try
            {
                if (exp is LambdaExpression)
                {
                    return ((LambdaExpression)exp).Compile().DynamicInvoke(model);// (exp as LambdaExpression).Compile().DynamicInvoke(Model);
                }
                else if (exp is ConstantExpression)
                {
                    return (exp as ConstantExpression).Value;
                }
            }
            catch
            {
                try
                {
                    return ((LambdaExpression)exp).Compile().DynamicInvoke();
                }
                catch
                {
                    return null;
                }
            }
            throw new NotSupportedException("无法计算" + exp.ToString() + "的值,不支持该表达式");
        }
        internal static string GetModelName(Expression expression, NameMode mode, object model)
        {
            string name = "";
            Expression exp = null;
            if (expression.NodeType == ExpressionType.Lambda)
            {
                exp = ((LambdaExpression)expression).Body;
            }
            else
            {
                exp = expression;
            }
            if (exp != null)
            {
                if (exp is MemberExpression)
                {
                    if (exp.NodeType == ExpressionType.MemberAccess)
                    {
                        MemberExpression mexp = (MemberExpression)exp;
                        //表达式是按照从右往左的方向分析的，mexp.Expressioin这个属性，看文档说明，就是指的mexp.Member的父对象，
                        //这个父有可能是TypedParameterExpression(NodeType为Prarmeter)顶级参数对象，也有可能仍是一个MemberExpression,故这里要做递归处理。
                        string modelName = GetModelName(mexp.Expression, mode, model);
                        if (string.IsNullOrEmpty(modelName))
                        {
                            name = mexp.Member.Name;
                        }
                        else
                        {
                            name = modelName + CreateSubPropertyName(mexp.Member.Name, mode);
                        }
                    }
                }
                if (exp is ParameterExpression) //参数
                {
                    if (exp.NodeType == ExpressionType.Parameter)
                    {
                        ParameterExpression para = (ParameterExpression)exp;
                        //if (para.Type == typeof(TModel))
                        {
                            name = "";
                        }
                    }
                    return "";
                }
                if (exp is NewArrayExpression)
                {
                    NewArrayExpression newArryExp = exp as NewArrayExpression;
                    if (exp.NodeType == ExpressionType.NewArrayInit) //像这种new string[]{ }
                    {
                        ReadOnlyCollection<Expression> exps = newArryExp.Expressions;
                        if (newArryExp.Expressions.Count > 0)
                        {
                            object obj = Eval(exps[0], null);
                            if (obj != null)
                            {
                                name = obj.ToString();
                            }
                        }
                    }
                    return "";
                }
                if (exp is BinaryExpression) //索引这种操作，对应的是SimpleBinaryExpression，NodeType为ArrayIndex
                {
                    BinaryExpression bexp = (BinaryExpression)exp;
                    if (bexp.NodeType == ExpressionType.ArrayIndex)
                    {
                        string modelName = GetModelName(bexp.Left, mode, model);
                        string index = Eval(bexp.Right, null).ToString();
                        name = modelName + CreateSubIndexName(index, mode);
                    }
                }
                if (exp is MethodCallExpression)
                {
                    MethodCallExpression me = exp as MethodCallExpression;
                    if (me.NodeType == ExpressionType.Call)
                    {
                        object value = Eval(expression, model);
                        name = value.ToString();
                    }
                }
            }
            return name;
        }

        /// <summary>
        /// 格式化Value属性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        internal string FormatValue(string name, object value, MemberInfo memberInfo)
        {
            if (Model != null)
            {
                if (memberInfo == null)
                {
                    MemberInfo[] members = Model.GetType().GetMember(name);
                    if (members.Length > 0)
                    {
                        memberInfo = members[0];
                    }
                }
                if (memberInfo != null)
                {
                    ValueFormatterAttribute valueFormatter = memberInfo.GetCustomAttributes(true).OfType<ValueFormatterAttribute>().FirstOrDefault();
                    if (valueFormatter != null && valueFormatter.ValueFormatter != null)
                    {
                        return valueFormatter.ValueFormatter.GetFormattedValue(value);
                    }
                }
                if (MemberFormatterCollections.ContainsKey(name))
                {
                    return MemberFormatterCollections[name].GetFormattedValue(value);
                }
            }
            return TypeHelper.FormatToHtmlValue(value);
        }
        internal string GetID(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            return name.Replace(".", "_");
        }
        private string GetValidatedName(string name)
        {
            if (!Regex.IsMatch(name, "^[_a-zA-Z]\\w*$"))
            {
                throw new InvalidOperationException("无效的名称" + name);
            }
            return name;
        }

        public string TextBox(string name)
        {
            return TextBox(name, null, null);
        }
        public string TextBox(string name, object value)
        {
            return TextBox(name, value, null);
        }
        public string TextBox(string name, object value, object htmlAttribute)
        {
            HtmlInputText text = new HtmlInputText();
            text.Name = GetValidatedName(name);
            text.ID = GetID(text.Name);
            text.Value = FormatValue(text.Name, value);
            text.AddCustomAttributes(htmlAttribute);
            return text;
        }

        public string Password(string name)
        {
            return Password(name, null, null);
        }
        public string Password(string name, object value)
        {
            return Password(name, value, null);
        }
        public string Password(string name, object value, object htmlAttribute)
        {
            HtmlInputPassword text = new HtmlInputPassword();
            text.Name = GetValidatedName(name);
            text.ID = GetID(text.Name);
            text.Value = FormatValue(text.Name, value);
            text.AddCustomAttributes(htmlAttribute);
            return text;
        }

        public string TextArea(string name)
        {
            return TextArea(name, null, null);
        }
        public string TextArea(string name, object value)
        {
            return TextArea(name, value, null);
        }
        public string TextArea(string name, object value, object htmlAttribute)
        {
            HtmlTextArea text = new HtmlTextArea();
            text.Name = GetValidatedName(name);
            text.ID = GetID(text.Name);
            text.Value = FormatValue(text.Name, value);
            text.AddCustomAttributes(htmlAttribute);
            return text;
        }

        public string Hidden(string name)
        {
            return Hidden(name, null);
        }
        public string Hidden(string name, object value)
        {
            HtmlInputHidden text = new HtmlInputHidden();
            text.Name = name;
            text.ID = GetID(name);
            text.Value = FormatValue(text.Name, value);
            return text;
        }

        public string DropDownList(string name)
        {
            return DropDownList(name, null, null, null, null);
        }
        public string DropDownList(string name, object value)
        {
            return DropDownList(name, value, null, null, null);
        }
        public string DropDownList(string name, object value, object htmlAttribute)
        {
            return DropDownList(name, value, null, null, htmlAttribute);
        }
        public string DropDownList(string name, Func<IEnumerable<SelectListItem>> options)
        {
            return DropDownList(name, null, options, null, null);
        }
        public string DropDownList(string name, Func<IEnumerable<SelectListItem>> options, SelectListItem selectedText)
        {
            return DropDownList(name, null, options, selectedText, null);
        }
        public string DropDownList(string name, object value, Func<IEnumerable<SelectListItem>> options)
        {
            return DropDownList(name, value, options, null, null);
        }
        public string DropDownList(string name, object value, Func<IEnumerable<SelectListItem>> options, object htmlAttribute)
        {
            return DropDownList(name, value, options, null, htmlAttribute);
        }
        public string DropDownList(string name, object value, Func<IEnumerable<SelectListItem>> options, SelectListItem selectedText)
        {
            return DropDownList(name, value, options, selectedText, null);
        }
        public string DropDownList(string name, object value, Func<IEnumerable<SelectListItem>> options, SelectListItem selectedText, object htmlAttribute)
        {
            HtmlSelect select = new HtmlSelect();
            select.Name = GetValidatedName(name);
            select.ID = GetID(select.Name);
           string dvalue = FormatValue(select.Name, value);

            List<SelectListItem> selectItemLists = new List<SelectListItem>();
            if (options != null)
            {
                selectItemLists.AddRange(options());
            }

           foreach(var item in selectItemLists)
           {
              if(string.Equals(item.Value , dvalue, StringComparison.InvariantCultureIgnoreCase))
              {
                 item.IsSelected = true; break;
              }
           }

            SelectListItem defaultOption = null;
            if (selectedText != null)
            {
                defaultOption = new SelectListItem(selectedText.Value, selectedText.Text, selectedText.IsSelected);
                selectItemLists.Add(defaultOption);
            }
            if (defaultOption != null)
            {
                if (!selectItemLists.Any(x => x.IsSelected))
                {
                    defaultOption.IsSelected = true;
                }
            }
            if (selectItemLists.Count > 0 && !selectItemLists.Any(x => x.IsSelected))
            {
                selectItemLists[0].IsSelected = true;
            }

            for (int i = 0; i < selectItemLists.Count; i++)
            {
                SelectListItem item = selectItemLists[i];
                HtmlOption option = new HtmlOption(item.Value, item.Text, item.IsSelected);
                select.Options.Add(option);
            }
            if (selectItemLists.Count > 0)
            {
                select.Value = selectItemLists.FirstOrDefault(x => x.IsSelected).Value;
            }
            select.AddCustomAttributes(htmlAttribute);
            return select;
        }
    }
    public class HtmlHelper<TModel> : HtmlHelper
    {
        public HtmlHelper()
        {
            IsAllControlEnabled = true;
            MemberFormatterCollections = new Dictionary<string, IValueFormatter>();
        }

        private void AddFormatter(string name, IValueFormatter formatter)
        {
            MemberFormatterCollections.Add(name, formatter);
        }

        public void AddFormatter<TResult>(Expression<Func<TModel, TResult>> member, IValueFormatter valueFormatter)
        {
            AddFormatter(GetModelName(member, NameMode.Name), valueFormatter);
        }

        public void AddFormatter<TResult>(Expression<Func<TModel, TResult>> member, Func<TResult, string> valueFormatterPredicate)
        {
            AddFormatter(GetModelName(member, NameMode.Name), new CustomValueFormatter(valueFormatterPredicate));
        }

        private object GetModelValue(Expression exp)
        {
            if (exp == null)
            {
                throw new Exception();
            }
            if (Model == null)
            {
                Model = Activator.CreateInstance(typeof(TModel));
            }
            try
            {
                return Eval(exp, (TModel)Model);
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException is ArgumentNullException)
                {
                    throw ex.InnerException;
                }
                if (ex.InnerException is IndexOutOfRangeException)
                {
                    throw ex.InnerException;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        internal string FormatValue<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            MemberExpression member = (expression.Body as MemberExpression);
            if (member == null)
            {
                return base.FormatValue(GetModelName(expression, NameMode.Name), GetModelValue(expression), null);
            }
            return base.FormatValue(GetModelName(expression, NameMode.Name), GetModelValue(expression), member.Member);
        }
        /// <summary>
        /// 此值可能不是来自expression，故有此重载
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        internal string FormatValue(object value, LambdaExpression expression)
        {
            MemberExpression member = (expression.Body as MemberExpression);
            return base.FormatValue(GetModelName(expression, NameMode.Name), value, member.Member);
        }

        public string DisplayNameFor<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                MemberInfo member = (expression.Body as MemberExpression).Member;
                object[] attr = member.GetCustomAttributes(true);
                for (int i = 0; i < attr.Length; i++)
                {
                    if (attr[i] is DisplayNameAttribute)
                    {
                        string name = (attr[i] as DisplayNameAttribute).DisplayName;
                        if (!string.IsNullOrEmpty(name))
                        {
                            return name;
                        }
                    }
                }
                return member.Name;
            }
            throw new InvalidOperationException();
        }

        public string DisplayFor<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            object value = GetModelValue(expression);
            string str = "";
            if (value != null)
            {
                MemberInfo memberInfo = (expression.Body as MemberExpression).Member;
                foreach (IValueFormatter formatter in memberInfo.GetCustomAttributes(false).OfType<IValueFormatter>())
                {
                    str = formatter.GetFormattedValue(value);
                }
            }
            return str;
        }
        public string TextBoxFor<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            return TextBoxFor<TResult>(expression, null);
        }
        public string GetModelName(Expression exp, NameMode nameMode)
        {
            return GetModelName(exp, nameMode, Model);
        }
        public string TextBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttribute)
        {
            HtmlInputText text = new HtmlInputText();
            text.Name = GetModelName(expression, NameMode.Name);
            text.ID = GetModelName(expression, NameMode.ID);
            text.Value = FormatValue(expression);
            text.AddCustomAttributes(htmlAttribute);
            return text;
        }

        public string PasswordFor<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            return PasswordFor<TResult>(expression, null);
        }
        public string PasswordFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttribute)
        {
            HtmlInputPassword text = new HtmlInputPassword();
            text.ID = GetModelName(expression, NameMode.ID);
            text.Name = GetModelName(expression, NameMode.Name);
            text.Value = FormatValue(expression);
            text.AddCustomAttributes(htmlAttribute);
            return text;
        }

        public string TextAreaFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttribute)
        {
            HtmlTextArea textArea = new HtmlTextArea();
            textArea.ID = GetModelName(expression, NameMode.ID);
            textArea.Name = GetModelName(expression, NameMode.Name);
            textArea.Value = FormatValue(expression);
            textArea.AddCustomAttributes(htmlAttribute);
            return textArea;
        }
        public string TextAreaFor<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            return TextAreaFor(expression, null);
        }

        public string HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttribute)
        {
            HtmlInputHidden hidden = new HtmlInputHidden();
            hidden.ID = GetModelName(expression, NameMode.ID);
            hidden.Name = GetModelName(expression, NameMode.Name);
            hidden.Value = FormatValue(expression);
            return hidden;
        }
        public string HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            return HiddenFor(expression, null);
        }

        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            return DropDownListFor(expression, null, null, null, null);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, object value, object htmlAttribute)
        {
           return DropDownListFor(expression, value, null, null, htmlAttribute);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttribute)
        {
            return DropDownListFor(expression, null, null, null, htmlAttribute);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, SelectListItem selectedText)
        {
            return DropDownListFor(expression, null, null, selectedText, null);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, SelectListItem selectedText, object htmlAttribute)
        {
            return DropDownListFor(expression, null, null, selectedText, htmlAttribute);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, Func<IEnumerable<SelectListItem>> options)
        {
            return DropDownListFor(expression, null, options, null, null);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, object value, Func<IEnumerable<SelectListItem>> options)
        {
            return DropDownListFor(expression, value, options, null, null);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, Func<IEnumerable<SelectListItem>> options, object htmlAttribute)
        {
            return DropDownListFor(expression, null, options, null, htmlAttribute);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, Func<IEnumerable<SelectListItem>> options, SelectListItem selectedText)
        {
            return DropDownListFor(expression, null, options, selectedText, null);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, Func<IEnumerable<SelectListItem>> options, SelectListItem selectedText, object htmlAttribute)
        {
            return DropDownListFor(expression, null, options, selectedText, htmlAttribute);
        }
        public string DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, object value, Func<IEnumerable<SelectListItem>> options, SelectListItem selectedText, object htmlAttribute)
        {
            HtmlSelect select = new HtmlSelect();
            select.ID = GetModelName(expression, NameMode.ID);
            select.Name = GetModelName(expression, NameMode.Name);
            object finalValue = FormatValue(expression);
            Type memberType = typeof(TResult);

            if (TypeHelper.IsNullable(memberType))
            {
                memberType = memberType.GetGenericArguments()[0];
                if (value == null)
                {
                    //finalValue = value;
                }
                else
                {
                    if (value.GetType() != memberType)
                    {
                        throw new InvalidCastException("传入的value和" + expression + "类型不匹配");
                    }
                    else
                    {
                        finalValue = value;
                    }
                }
            }
            else
            {
                if (value == null)
                {
                    if (memberType.IsValueType)
                    {
                    }
                    else
                    {
                        //finalValue = null;
                    }
                }
                else
                {
                    if (value.GetType() != memberType)
                    {
                        throw new InvalidCastException("传入的value和" + expression + "类型不匹配");
                    }
                    else
                    {
                        finalValue = value;
                    }
                }
            }
            List<SelectListItem> selectItemLists = new List<SelectListItem>();
            if (options != null)
            {
                selectItemLists.AddRange(options());
            }
            if (memberType.IsEnum)
            {
                Array arr = Enum.GetValues(memberType);
                ValueFormatterAttribute enumFormatter = (ValueFormatterAttribute)memberType.GetCustomAttributes(true).FirstOrDefault(x => x is ValueFormatterAttribute);
                for (int i = 0; i < arr.Length; i++)
                {
                    object enumValue = arr.GetValue(i);
                    string enumName = enumValue.ToString();
                    SelectListItem item = new SelectListItem();
                    item.Value = FormatValue((int)enumValue, expression);
                    item.IsSelected = false;

                    ValueFormatterAttribute fieldFormatter = (ValueFormatterAttribute)memberType.GetField(enumName).GetCustomAttributes(true).FirstOrDefault(x => x is ValueFormatterAttribute);
                    if (fieldFormatter != null)
                    {
                        item.Text = fieldFormatter.ValueFormatter.GetFormattedValue(enumValue);
                    }
                    else if (enumFormatter != null)
                    {
                        item.Text = enumFormatter.ValueFormatter.GetFormattedValue(enumValue);
                    }
                    else
                    {
                        item.Text = enumValue.ToString();
                    }
                    if (!selectItemLists.Any(x => x.Value == item.Value))
                    {
                        selectItemLists.Add(item);
                    }
                }
            }

            for (int i = 0; i < selectItemLists.Count; i++)
            {
                SelectListItem item = selectItemLists[i];
                if (finalValue != null && finalValue.ToString() != "")
                {
                    if (memberType.IsEnum && (item.Value == Convert.ToInt32(finalValue).ToString() || item.Value == finalValue.ToString()))
                    {
                        item.IsSelected = true;
                        break;
                    }
                    else if (finalValue.ToString() == item.Value)
                    {
                       item.IsSelected = true;
                    }
                    else
                    {
                       item.IsSelected = false;
                    }
                }
            }
            SelectListItem defaultOption = null;
            if (selectedText != null)
            {
                defaultOption = new SelectListItem(selectedText.Value, selectedText.Text, selectedText.IsSelected);
                selectItemLists.Add(defaultOption);
            }
            if (defaultOption != null)
            {
                if (!selectItemLists.Any(x => x.IsSelected))
                {
                    defaultOption.IsSelected = true;
                }
            }
            if (selectItemLists.Count > 0 && !selectItemLists.Any(x => x.IsSelected))
            {
                selectItemLists[0].IsSelected = true;
            }

            foreach(var item in selectItemLists.OrderBy(x=>x.Value))
            {
                HtmlOption option = new HtmlOption(item.Value, item.Text, item.IsSelected);
                select.Options.Add(option);
            }
            if (selectItemLists.Count > 0)
            {
                select.Value = selectItemLists.FirstOrDefault(x => x.IsSelected).Value;
            }
            select.AddCustomAttributes(htmlAttribute);
            return select;
        }
    }
}




