using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.ComponentModel;
using Linq.Web.Html.Attrib;
using Linq.Web.Html.Collections;
using Linq.Web.Html.Enums;
using System.Web;
using Linq.Web.Html.ValidateUtility;
using Linq.TypeHelpers;
using System.Runtime.Remoting;
using Linq.Web.Html.Interface;
namespace Linq.Web.Html
{
   public abstract class HtmlElement : HtmlNode, IHtmlNodeContainer
   {
      [HtmlAttribute]
      public string ID { get; set; }
      public string TagName { get { return Tag.ToString().ToLower(); } }
      [HtmlAttribute]
      public string Title { get; set; }
      public override HtmlNodeType NodeType { get { return HtmlNodeType.Element; } }
      private HtmlElementTag Tag { get; set; }
      /// <summary>
      /// innnerHtml解析方式
      /// </summary>
      protected virtual ContentResolveWay ContentResolveWay { get; set; }
      /// <summary>
      /// 只能哪些标记
      /// </summary>
      public IList<HtmlElementTag> ChildElementType { get; set; }
      public virtual HtmlNodeCollection Children { get; set; }
      public TagCloseType TagCloseType { get; set; }
      IList<KeyValuePair<string, HtmlAttributeAttribute>> attributes;

      private List<KeyValuePair<string, HtmlAttributeAttribute>> customAttributes;
      public void AddCustomAttributes(object attributes)
      {
         AddCustomAttributes(GetAttribDic(attributes));
      }
      public void AddCustomAttributes(IList<KeyValuePair<string, HtmlAttributeAttribute>> list)
      {
         if (customAttributes == null)
         {
            customAttributes = new List<KeyValuePair<string, HtmlAttributeAttribute>>();
         }
         customAttributes.AddRange(list);
      }

      IList<KeyValuePair<string, HtmlAttributeAttribute>> GetAttribDic(object attr)
      {
         List<KeyValuePair<string, HtmlAttributeAttribute>> attributes = new List<KeyValuePair<string, HtmlAttributeAttribute>>();
         if (attr != null)
         {
            foreach (PropertyDescriptor p in TypeDescriptor.GetProperties(attr))
            {
               attributes.Add(new KeyValuePair<string, HtmlAttributeAttribute>(p.Name, new HtmlAttributeAttribute(p.GetValue(attr))));
            }
         }
         return attributes;
      }
      public IList<KeyValuePair<string, HtmlAttributeAttribute>> Attributes
      {
         get
         {
            if (attributes == null)
            {
               attributes = GetAttributes();
            }
            return attributes;
         }
      }
      public HtmlElement(HtmlElementTag tag, TagCloseType closeType)
      {
         if (tag == HtmlElementTag.None)
         {
            throw new Exception("未指定的Element名称");
         }
         this.Tag = tag;
         this.TagCloseType = closeType;
         this.ContentResolveWay = Enums.ContentResolveWay.Html;
         this.Children = new HtmlNodeCollection();
         AddChildren();
      }
      public HtmlElement(HtmlElementTag tag)
         : this(tag, TagCloseType.Plain)
      {

      }

      protected virtual void AddChildren()
      {
         IEnumerable<PropertyInfo> ps = base.GetType().GetProperties().Where(x => x.Name != "Parent");
         foreach (PropertyInfo p in ps.Where(x => x.PropertyType == typeof(HtmlElement)))
         {
            HtmlElement element = (HtmlElement)p.GetValue(this, null);
            element.Parent = this;
            Children.Add(element);
         }
         foreach (PropertyInfo pc in ps.Where(x => typeof(HtmlNodeCollection).IsAssignableFrom(x.PropertyType) && x.PropertyType.IsDefined(typeof(HtmlElementChildrenAttribute), true)))
         {
            HtmlNodeCollection collection = (HtmlNodeCollection)pc.GetValue(this, null);
            foreach (HtmlNode node in collection)
            {
               node.Parent = this;
               Children.Add((HtmlElement)node);
            }
         }
      }

      public static implicit operator string(HtmlElement elmement)
      {
         return elmement.ToString();
      }
      string innerhtml;
      public virtual string InnerHtml
      {
         get
         {
            if (ContentResolveWay == Enums.ContentResolveWay.Html)
            {
               if (Children != null)
               {
                  StringBuilder attributesString = new StringBuilder(100);
                  for (int i = 0; i < Children.Count; i++)
                  {
                     HtmlNode node = Children[i];
                     if (node.NodeType == HtmlNodeType.Element)
                     {
                        HtmlElement element = node as HtmlElement;
                        if (ChildElementType != null && ChildElementType.Count > 0 && !ChildElementType.Any(x => string.Equals(x.ToString(), element.TagName, StringComparison.OrdinalIgnoreCase)))
                        {
                           throw new Exception(TagName + "不能包含子元素" + element.TagName);
                        }
                     }
                     attributesString.Append(node.ToString());
                  }
                  innerhtml = attributesString.ToString();
               }
            }
            return innerhtml;
         }
         set
         {
            if (ContentResolveWay == Enums.ContentResolveWay.Html)
            {
               Children = ParseHtml(value);
               innerhtml = value;
            }
            else if (ContentResolveWay == Enums.ContentResolveWay.OnlyText)
            {
               Children = null;
               if (value != null)
               {
                  int matchIndex;
                  if (Linq.Web.Html.ValidateUtility.CrossSiteScriptingValidation.IsDangerousString(value, out matchIndex))
                  {
                     innerhtml = HtmlEncodeUtility.HtmlEncode(value);
                  }
                  else
                  {
                     innerhtml = value;
                  }
               }
            }
         }
      }

      HtmlNodeCollection ParseHtml(string text)
      {
         if (text == null)
            return null;

         HtmlTextNode tn = new HtmlTextNode { Text = text };
         return new HtmlNodeCollection() { tn };
      }

      public virtual string OuterHtml
      {
         get
         {
            StringBuilder sb = new StringBuilder(100);
            sb.Append("<");
            sb.Append(TagName);
            sb.Append(GetAttributesString());
            if (TagCloseType == TagCloseType.SingleTag)
            {
               sb.Append(" />");
            }
            else if (TagCloseType == TagCloseType.Plain)
            {
               sb.Append(">");
               sb.Append(InnerHtml);
               sb.Append("</" + TagName + ">");
            }
            else
            {
            }
            return sb.ToString();
         }
      }
      public override string ToString()
      {
         return OuterHtml;
      }

      private string GetAttributesString()
      {
         StringBuilder attributesString = new StringBuilder(100);

         foreach (KeyValuePair<string, HtmlAttributeAttribute> kv in Attributes)
         {
            HtmlAttributeAttribute attr = kv.Value;
            if (attr.IsVisible)
            {
               string value;
               if (attr.ValueFormatter == null)
               {
                  value = TypeHelper.FormatToHtmlValue(attr.RawValue);
               }
               else
               {
                  value = kv.Value.ValueFormatter.GetFormattedValue(attr.RawValue);
               }
               if (attr.AllowEmptyString || (value != null && value.ToString() != ""))
               {
                  attributesString.Append(" ");
                  attributesString.Append(kv.Key.ToLower());
                  attributesString.Append("=\"");
                  attributesString.Append(value);
                  attributesString.Append("\"");
               }
            }
         }
         return attributesString.ToString();

      }
      protected virtual IList<KeyValuePair<string, HtmlAttributeAttribute>> GetAttributes()
      {
         List<KeyValuePair<string, HtmlAttributeAttribute>> attributes = new List<KeyValuePair<string, HtmlAttributeAttribute>>();
         Dictionary<PropertyInfo, HtmlAttributeAttribute> ps = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.IsDefined(typeof(HtmlAttributeAttribute), true))
            .ToDictionary(x => x, j => j.GetCustomAttributes(true).OfType<HtmlAttributeAttribute>().First());

         foreach (KeyValuePair<PropertyInfo, HtmlAttributeAttribute> kv in ps)
         {
            string name = kv.Key.Name;
            object value = kv.Key.GetValue(this, null);
            HtmlAttributeAttribute attributeInfo = kv.Value;
            attributeInfo.RawValue = value;
            if (attributeInfo.Name!=null && !string.IsNullOrEmpty(attributeInfo.Name.Trim()))
            {
               name = attributeInfo.Name;
            }
            attributes.Add(new KeyValuePair<string, HtmlAttributeAttribute>(name, attributeInfo));
         }

         if (customAttributes != null)
         {
            foreach (KeyValuePair<string, HtmlAttributeAttribute> p in customAttributes)
            {
               attributes.Add(new KeyValuePair<string, HtmlAttributeAttribute>(p.Key, p.Value));
            }
         }
         return attributes;
      }

      public HtmlElement GetElementById(string id)
      {
         foreach (HtmlElement element in Children)
         {
            if (element.ID == id)
            {
               return element;
            }
            else
            {
               return element.GetElementById(id);
            }
         }
         return null;
      }

      public IList<HtmlElement> GetElementsByTagName(string tagName)
      {
         List<HtmlElement> elements = new List<HtmlElement>();
         foreach (HtmlElement element in Children)
         {
            if (element.TagName == tagName)
            {
               elements.Add(element);
            }
            elements.AddRange(element.GetElementsByTagName(tagName));
         }
         if (elements.Count == 0)
         {
            return null;
         }
         return elements;
      }

      public override void Dispose()
      {
         this.Parent = null;
      }

      internal static HtmlElement Create(HtmlElementTag tagType)
      {
         string name = "Html" + tagType.ToString();
         ObjectHandle o = Activator.CreateInstance(typeof(HtmlElement).Assembly.FullName, "Linq.Web.Html." + name);
         object obj = o.Unwrap();

         if (obj == null)
         {
            throw new NullReferenceException("未反射到名为：" + tagType + "的类");
         }
         return (HtmlElement)obj;
      }
   }
}
