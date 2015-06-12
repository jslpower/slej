using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Web.Html.Collections
{
   public class HtmlNodeCollection : IList<HtmlNode>
   {
      private List<HtmlNode> innerList = new List<HtmlNode>();
      public void Add(HtmlNode node)
      {
         if (node == null)
         {
            throw new ArgumentNullException();
         }
         innerList.Add(node);
      }

      public bool Remove(HtmlNode node)
      {
         if (node == null)
         {
            throw new ArgumentNullException();
         }
         if (innerList == null)
            throw new NullReferenceException();
         node.Dispose();
         //if (this.OnNodeRemove != null)
         //{
         //   OnNodeRemove(node, -1);
         //}
         return innerList.Remove(node);
      }

      public int IndexOf(HtmlNode node)
      {
         if (innerList == null)
            throw new NullReferenceException();
         return innerList.IndexOf(node);
      }

      public void Insert(int index, HtmlNode node)
      {
         if (innerList == null)
            throw new NullReferenceException();
         //if (this.OnNodeAdded != null)
         //{
         //   OnNodeAdded(node, index);
         //}
         innerList.Insert(index, node);
      }

      public void RemoveAt(int index)
      {
         if (index < 0 || index > innerList.Count - 1)
         {
            throw new IndexOutOfRangeException();
         }
         if (innerList == null)
            throw new NullReferenceException();
         innerList[index].Dispose();
         innerList.RemoveAt(index);
         //if (this.OnNodeRemove != null)
         //{
         //   OnNodeRemove(innerList[index], index);
         //}
      }

      public HtmlNode this[int index]
      {
         get
         {
            if (index > innerList.Count - 1)
            {
               throw new IndexOutOfRangeException();
            }
            return innerList[index];
         }
         set
         {
            if (index > innerList.Count - 1)
            {
               throw new IndexOutOfRangeException();
            }
            innerList[index] = value;
         }
      }

      public void Clear()
      {
         if (innerList == null)
            throw new NullReferenceException();
         foreach (HtmlNode op in innerList) { op.Dispose(); }
         innerList.Clear();
         //if (this.OnNodeRemove != null)
         //{
         //   foreach (HtmlNode no in innerList)
         //   {
         //      OnNodeRemove(no, -1);
         //   }
         //}
      }

      public bool Contains(HtmlNode item)
      {
         if (innerList == null)
            throw new NullReferenceException();
         return innerList.Contains(item);
      }

      public void CopyTo(HtmlNode[] array, int arrayIndex)
      {
         if (array == null) throw new NullReferenceException();
         innerList.CopyTo(array, arrayIndex);
      }

      public int Count
      {
         get
         {
            if (innerList == null)
               throw new NullReferenceException();
            return innerList.Count;
         }
      }

      public IEnumerator<HtmlNode> GetEnumerator()
      {
         if (innerList == null)
            throw new NullReferenceException();
         return innerList.GetEnumerator();
      }

      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
         if (innerList == null)
            throw new NullReferenceException();
         return innerList.GetEnumerator();
      }


      public bool IsReadOnly
      {
         get { return false; }
      }
   }
}
