using System;
using System.Globalization;
using System.ComponentModel;
using System.Collections;
namespace Linq.Mvc3
{
   public class ValueProviderResult
   {
      // Fields
      private CultureInfo _instanceCulture;
      private static readonly CultureInfo _staticCulture = CultureInfo.InvariantCulture;

      // Methods
      protected ValueProviderResult()
      {
      }

      public ValueProviderResult(object rawValue, string attemptedValue, CultureInfo culture)
      {
         this.RawValue = rawValue;
         this.AttemptedValue = attemptedValue;
         this.Culture = culture;
      }

      private static object ConvertSimpleType(CultureInfo culture, object value, Type destinationType)
      {
         object obj3;
         if ((value == null) || destinationType.IsInstanceOfType(value))
         {
            return value;
         }
         string str = value as string;
         if ((str != null) && (str.Trim().Length == 0))
         {
            return null;
         }
         TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
         bool flag = converter.CanConvertFrom(value.GetType());
         if (!flag)
         {
            converter = TypeDescriptor.GetConverter(value.GetType());
         }
         if (!flag && !converter.CanConvertTo(destinationType))
         {
            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "", new object[] { value.GetType().FullName, destinationType.FullName }));
         }
         try
         {
            object obj2 = flag ? converter.ConvertFrom(null, culture, value) : converter.ConvertTo(null, culture, value, destinationType);
            obj3 = obj2;
         }
         catch (Exception exception)
         {
            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "", new object[] { value.GetType().FullName, destinationType.FullName }), exception);
         }
         return obj3;
      }

      public object ConvertTo(Type type)
      {
         return this.ConvertTo(type, null);
      }

      public virtual object ConvertTo(Type type, CultureInfo culture)
      {
         if (type == null)
         {
            throw new ArgumentNullException("type");
         }
         CultureInfo info = culture ?? this.Culture;
         return UnwrapPossibleArrayType(info, this.RawValue, type);
      }

      private static object UnwrapPossibleArrayType(CultureInfo culture, object value, Type destinationType)
      {
         if ((value == null) || destinationType.IsInstanceOfType(value))
         {
            return value;
         }
         Array array = value as Array;
         if (destinationType.IsArray)
         {
            Type elementType = destinationType.GetElementType();
            if (array != null)
            {
               IList list = Array.CreateInstance(elementType, array.Length);
               for (int i = 0; i < array.Length; i++)
               {
                  list[i] = ConvertSimpleType(culture, array.GetValue(i), elementType);
               }
               return list;
            }
            object obj2 = ConvertSimpleType(culture, value, elementType);
            IList list2 = Array.CreateInstance(elementType, 1);
            list2[0] = obj2;
            return list2;
         }
         if (array == null)
         {
            return ConvertSimpleType(culture, value, destinationType);
         }
         if (array.Length > 0)
         {
            value = array.GetValue(0);
            return ConvertSimpleType(culture, value, destinationType);
         }
         return null;
      }

      // Properties
      public string AttemptedValue { get; protected set; }

      public CultureInfo Culture
      {
         get
         {
            if (this._instanceCulture == null)
            {
               this._instanceCulture = _staticCulture;
            }
            return this._instanceCulture;
         }
         protected set
         {
            this._instanceCulture = value;
         }
      }

      public object RawValue { get; protected set; }
   }
}