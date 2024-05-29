namespace Jisp.Core;

public static class CompareExt
{
   public static int JispCompare(this object a, object b)
   {
      if (a is IEnumerable<object> aSeq && b is IEnumerable<object> bSeq)
         return CompareSequences(aSeq.ToList(), bSeq.ToList());
      else if (a is IDictionary<string, object> aDict && b is IDictionary<string, object> bDict)
         return CompareDictionaries(aDict, bDict);
      else if (a is bool aBool && b is bool bBool)
         return aBool.CompareTo(bBool);
      else if (a is string aStr && b is string bStr)
         return aStr.CompareTo(bStr);
      else if (a is decimal aNum && b is decimal bNum)
         return aNum.CompareTo(bNum);
      else if (a is Nil && b is Nil)
         return 0;
      else if (a is Nil)
         return -1;
      else if (b is Nil)
         return 1;
      else
         return a.GetHashCode().CompareTo(b.GetHashCode());
   }

   private static int CompareSequences<T>(List<T> aSeq, List<T> bSeq)
   {
      var cr = aSeq.Count.CompareTo(bSeq.Count);
      if (cr != 0) return cr;

      for (var idx = 0; idx < aSeq.Count; ++idx)
      {
         var arga = aSeq[idx] ?? throw new ArgumentNullException($"ERR: null at {aSeq.ToJistr()}");
         var argb = bSeq[idx] ?? throw new ArgumentNullException($"ERR: null at {bSeq.ToJistr()}");

         cr = arga.JispCompare(argb);
         if (cr != 0) return cr;
      }
      return 0;
   }

   private static int CompareDictionaries(IDictionary<string, object> aDict, IDictionary<string, object> bDict)
   {
      var cr = aDict.Count.CompareTo(bDict.Count);
      if (cr != 0) return cr;

      cr = CompareSequences(aDict.Keys.Order().ToList(), bDict.Keys.Order().ToList());
      if (cr != 0) return cr;

      foreach (var (key, x) in aDict)
      {
         if (x is null) throw new ArgumentNullException($"ERR: null at key {key}");
         if (!bDict.TryGetValue(key, out var y))
         {
            if (y is null) throw new ArgumentNullException($"ERR: null at key {key}");
            cr = x.JispCompare(y);
            if (cr != 0) return cr;
         }
      }
      return 0;
   }
}