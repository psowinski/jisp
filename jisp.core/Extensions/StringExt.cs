using System.Text;
namespace Jisp.Core;
public static class StringExt
{
   public static string ToJistr(this object value, int maxLenth)
   {
      var str = value.ToJistr();
      if (str.Length > maxLenth)
         str = str.Substring(0, maxLenth - 3) + "...";
      return str;
   }

   public static string ToJistr(this object value)
   {
      if (value is IEnumerable<object> collection)
         return ListToString(collection);
      else if (value is IDictionary<string, object> dictionary)
         return MapToString(dictionary);
      else if (value is bool logic)
         return logic ? "true" : "false";
      return value.ToString() ?? string.Empty;
   }

   private static string MapToString(IDictionary<string, object> dictionary)
   {
      var sb = new StringBuilder();
      foreach (var (key, val) in dictionary)
      {
         sb.Append(sb.Length == 0 ? "{" : ", ");
         sb.Append(key);
         sb.Append(": ");
         sb.Append(ToJistr(val));
      }
      sb.Append("}");
      return sb.ToString();
   }

   private static string ListToString(IEnumerable<object> collection)
   {
      var sb = new StringBuilder();
      foreach (var item in collection)
      {
         sb.Append(sb.Length == 0 ? "[" : ", ");
         sb.Append(ToJistr(item));
      }
      sb.Append("]");
      return sb.ToString();
   }
}
