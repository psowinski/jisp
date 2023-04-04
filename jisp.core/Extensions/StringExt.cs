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

   public static string ToLiteral(this string input)
   {
      var literal = new StringBuilder(input.Length);
      foreach (var c in input)
      {
         switch (c)
         {
            case '\"': literal.Append("\\\""); break;
            case '\\': literal.Append(@"\\"); break;
            case '\0': literal.Append(@"\0"); break;
            case '\a': literal.Append(@"\a"); break;
            case '\b': literal.Append(@"\b"); break;
            case '\f': literal.Append(@"\f"); break;
            case '\n': literal.Append(@"\n"); break;
            case '\r': literal.Append(@"\r"); break;
            case '\t': literal.Append(@"\t"); break;
            case '\v': literal.Append(@"\v"); break;
            default:
               // ASCII printable character
               if (c >= 0x20 && c <= 0x7e)
               {
                  literal.Append(c);
                  // As UTF16 escaped character
               }
               else
               {
                  literal.Append(@"\u");
                  literal.Append(((int)c).ToString("x4"));
               }
               break;
         }
      }
      return literal.ToString();
   }
}
