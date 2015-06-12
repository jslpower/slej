using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace Linq.Web.Html.ValidateUtility
{
   internal class HtmlEncodeUtility
   {
      private static int IndexOfHtmlEncodingChars(string s, int startPos)
      {
         int num = s.Length - startPos;
         while (num > 0)
         {
            char ch = s[startPos];
            if (ch <= '>')
            {
               switch (ch)
               {
                  case '&':
                  case '\'':
                  case '"':
                  case '<':
                  case '>':
                     return (s.Length - num);
                  case '=':
                     goto Label_0086;
               }
            }
            else if ((ch >= '\x00a0') && (ch < 'Ā'))
            {
               return (s.Length - num);
            }
         Label_0086:
            startPos++;
            num--;
         }
         return -1;
      }

      public static string HtmlEncode(string value)
      {
         StringWriter output = new StringWriter();
         if (value != null)
         {
            int num = IndexOfHtmlEncodingChars(value, 0);
            if (num == -1)
            {
               output.Write(value);
            }
            else
            {
               int num2 = value.Length - num;
               int po = 0;
               while (num-- > 0)
               {
                  char chPtr = value[po];
                  po++;
                  output.Write(chPtr);
               }
               while (num2-- > 0)
               {
                  char chPtr = value[po];
                  po++;
                  char ch = chPtr;
                  if (ch <= '>')
                  {
                     switch (ch)
                     {
                        case '&':
                           {
                              output.Write("&amp;");
                              continue;
                           }
                        case '\'':
                           {
                              output.Write("&#39;");
                              continue;
                           }
                        case '"':
                           {
                              output.Write("&quot;");
                              continue;
                           }
                        case '<':
                           {
                              output.Write("&lt;");
                              continue;
                           }
                        case '>':
                           {
                              output.Write("&gt;");
                              continue;
                           }
                     }
                     output.Write(ch);
                     continue;
                  }
                  if ((ch >= '\x00a0') && (ch < 'Ā'))
                  {
                     output.Write("&#");
                     output.Write(((int)ch).ToString(NumberFormatInfo.InvariantInfo));
                     output.Write(';');
                  }
                  else
                  {
                     output.Write(ch);
                  }
               }
            }
         }
         return output.ToString();
      }
   }
}
