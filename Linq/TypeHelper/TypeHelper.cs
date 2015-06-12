using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections;

namespace Linq.TypeHelpers
{
    public class TypeHelper
    {
        public static bool IsNullable(Type type)
        {
            return type.IsValueType && type.IsGenericType && typeof(Nullable<>).IsAssignableFrom(type.GetGenericTypeDefinition());
        }
        public static object createObject(Type t)
        {
            if (t == null)
            {
                throw new InvalidOperationException();
            }
            if (TypeHelper.IsNullable(t))
            {
                t = t.GetGenericArguments()[0];
            }
            return Activator.CreateInstance(t);
        }
        internal static bool IsComplex(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException();
            }
            if (type.IsClass)
            {
                if (typeof(IEnumerable).IsAssignableFrom(type) || typeof(IList).IsAssignableFrom(type)
                   || (type.IsGenericType && !typeof(Nullable<>).IsAssignableFrom(type))
                   || !type.IsPublic || type.IsAbstract || type.IsSealed
                   || type.GetConstructor(Type.EmptyTypes) == null) //GetConstructor性能有点慢
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        Type[] primitiveTypes = new Type[] { typeof(bool), typeof(byte), typeof(char), typeof(double), typeof(short), typeof(int), typeof(long), typeof(System.IntPtr), typeof(sbyte), typeof(float), typeof(ushort), typeof(uint), typeof(ulong), typeof(System.UIntPtr) };
        public static bool isB(Type type)
        {
            if (IsNullable(type))
            {
                type = type.GetGenericArguments()[0];
            }
            if (type.IsPrimitive || type == typeof(decimal) || type == typeof(string) || type == typeof(DateTime) || type == typeof(Guid))
            {
                return true;
            }
            if (type.IsEnum)
            {
                return true;
            }
            return false;
        }

        internal static string sfm(object value, Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("格式化的值的类型不能为空");
            }
            if (value == null)
            {
                if (type.IsValueType)
                {
                    if (TypeHelper.IsNullable(type))
                    {
                        return "null";
                    }
                    else
                    {
                       throw new Exception("非可空列不能插入空值,type:" + type);
                    }
                }
                else if (type == typeof(object))
                {
                    return "null";
                }
                else
                {
                    return "''";
                }
            }

            if (type!= typeof(bool) && type != typeof(DateTime)&& type != typeof(Guid) 
                &&!type.IsAssignableFrom(value.GetType()))
            {
                throw new InvalidCastException(value + "和类型" + type.FullName + "不兼容");
            }

            type = value.GetType();

            if (type.IsArray)
            {
                Array arr = value as Array;
                Type elementType = type.GetElementType();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(sfm(arr.GetValue(i), elementType));
                }
                return sb.ToString();
            }
            else if (type.IsValueType)
            {
                if (TypeHelper.IsNullable(type))
                {
                    type = type.GetGenericArguments()[0];
                }
                if (type.IsEnum)
                {
                    return Convert.ChangeType(value, Enum.GetUnderlyingType(type)).ToString();
                }
                if (type == typeof(DateTime))
                {
                    DateTime t;
                    bool isValid = DateTime.TryParse(value.ToString(), out t);
                    if (!isValid)
                    {
                        throw new Exception("值：" + t + "不是有效的日期格式!");
                    }
                    else if (t < new DateTime(1753, 1, 1) || t > new DateTime(9999, 12, 31))
                    {
                        throw new Exception("值：" + t + "不符合sqlserver的日期范围!");
                    }
                    return "'" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
                else if (type == typeof(char))
                {
                    return "'" + value + "'";
                }
                else if (type == typeof(Guid))
                {
                    try
                    {
                        Guid g = new Guid(value.ToString());
                        return "'" + value + "'";
                    }
                    catch
                    {
                        throw new InvalidCastException("Guid格式无效");
                    }
                }
                else if (type == typeof(bool))
                {
                    string valueStr = value.ToString().ToLower();
                    if (valueStr == "1" || string.Equals(valueStr ,"true", StringComparison.OrdinalIgnoreCase))
                    {
                        return "1";
                    }
                    else if (valueStr == "0" || string.Equals(valueStr ,"false", StringComparison.OrdinalIgnoreCase))
                    {
                        return "0";
                    }
                    else
                    {
                        throw new InvalidCastException("bool类型的值" + value + "不正确!");
                    }
                }
                return value.ToString();
            }
            else
            {
                string str = value.ToString();
                str = Regex.Replace(str, "([^'])?'([^'])?", "$1\'\'$2", RegexOptions.Compiled); //特殊字符的处理待参考
                return "'" + str + "'";
            }
        }

        public static string FormatToHtmlValue(object value)
        {
            if (value == null)
                return "";
            else if (value is ValueType)
            {
                Type t = value.GetType();
                if (TypeHelper.IsNullable(value.GetType()))
                {
                    t = value.GetType().GetGenericArguments()[0];
                }
                if (t.IsEnum)
                {
                    return Convert.ChangeType(value, Enum.GetUnderlyingType(t)).ToString();
                }
            }
            if (value is Array)
            {
                Array arr = (Array)value;
                //Array.ForEach arr
            }
            return value.ToString();
        }

        internal static bool IsCompatible<T>(object model)
        {
            if (model == null)
            {
                if (typeof(T).IsClass)
                {
                    return true;
                }
            }
            if (typeof(T).IsAssignableFrom(model.GetType()))
            {
                return true;
            }
            return false;
        }



        internal static bool IsComplexType(Type type)
        {
            return !TypeDescriptor.GetConverter(type).CanConvertFrom(typeof(string));
        }
    }
}
