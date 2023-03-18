namespace Jisp.Core;

public static class EnumerableExt
{
   public static object FirstOrNil<T>(this IEnumerable<T> value)
   {
      var first = value.FirstOrDefault();
      if (first is null) return Nil.Value;
      return first;
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
}