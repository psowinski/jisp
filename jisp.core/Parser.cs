using System.Text.Json;

namespace Jisp.Core;

public static class JispParser
{
   public static object Parse(string code)
   {
      var doc = JsonDocument.Parse(code);
      var tree = Parse(doc);
      return tree;
   }

   public static object Parse(JsonDocument doc)
   {
      var tree = Parse(doc.RootElement);
      return tree;
   }   

   public static object Parse(JsonElement element)
   {
      var tree = ParseJsonElement(element);
      return tree;
   }

   private static object ParseJsonElement(JsonElement element)
   {
      switch (element.ValueKind)
      {
         case JsonValueKind.Object:
            var dic = new Dictionary<string, object>();
            foreach (var prop in element.EnumerateObject())
               dic.Add(prop.Name, ParseJsonElement(prop.Value));
            return dic;
         case JsonValueKind.Array:
            var list = new List<object>();
            foreach (var item in element.EnumerateArray())
               list.Add(ParseJsonElement(item));
            return list;
         case JsonValueKind.String:
            return element.GetString() ?? string.Empty;
         case JsonValueKind.Number:
            return element.GetDecimal();
         case JsonValueKind.True:
            return true;
         case JsonValueKind.False:
            return false;
         case JsonValueKind.Null:
            return Nil.Value;
         default:
            throw new NotImplementedException("Parse of: " + element.ToString());
      }
   }
}