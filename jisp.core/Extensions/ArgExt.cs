namespace Jisp.Core;

public static class ArgExt
{
      public static List<string> RequireStringList(this object value)
   {
      if (value is IEnumerable<object> seq)
      {
         var list = seq.Select(x => x.RequireString()).ToList();
         return list;
      }
      throw new ArgumentException($"ERR: Expected strings list {value.ToJistr()}");
   }   

   public static string RequireString(this object value)
   {
      if (value is string text) return text;

      throw new ArgumentException($"ERR: Expected string at {value.ToJistr()}");
   } 
}
