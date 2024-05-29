namespace Jisp.Core;

public static class EnumerableExt
{
   public static object FirstOrNil<T>(this IEnumerable<T> value)
   {
      var first = value.FirstOrDefault();
      if (first is null) return Nil.Value;
      return first;
   }
   
   public static object LastOrNil<T>(this IEnumerable<T> value)
   {
      var last = value.LastOrDefault();
      if (last is null) return Nil.Value;
      return last;
   }

   public static IEnumerable<object> ToSeq(this IEnumerable<object> seq, int size)
   {
      var ret = seq.Union(Enumerable.Repeat(Nil.Value, size)).Take(size);
      return ret;
   }

   public static List<object> ToList(this IEnumerable<object> seq, int size)
   {
      var ret = seq.ToSeq(size).ToList();
      return ret;
   }

   public static IEnumerable<(object, object)> SelectPairs(this IEnumerable<object> seq)
   {
      var enumerator = seq.GetEnumerator();
      while(enumerator.MoveNext())
      {
         var first = enumerator.Current;
         var second = enumerator.MoveNext() ? enumerator.Current : Nil.Value;
         yield return (first, second);
      }      
   }

   public static IEnumerable<object> GetRest(this IEnumerator<object> enumerator)
   {
      while(enumerator.MoveNext())
         yield return enumerator.Current;
   }
}