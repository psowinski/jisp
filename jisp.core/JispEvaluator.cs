namespace Jisp.Core;

public static class JispEvaluator
{
   public static object EvaluateAllJisp(this IEnumerable<object> seq, IContext context)
   {
      object last = Nil.Value;
      foreach (var expr in seq)
         last = expr.EvaluateJisp(context);
      return last;
   }

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

   public static object EvaluateJisp(this object value, IContext context)
   {
      if (value is List<object> list && list.Count > 0)
      {
         var element = list[0].EvaluateJisp(context);
         if (element is string cmd)
            element = context.Find(cmd) ?? throw new Exception($"Unknown command {cmd}");
         if (element is IEveluator eval)
         {
            var ret = eval.Evaluate(list.Skip(1), context);
            System.Diagnostics.Debug.WriteLine($"Debug: {list.ToJistr(40)} ==> {ret.ToJistr()}");
            return ret;
         }
         if (element is not null)
         {
            System.Diagnostics.Debug.WriteLine($"Debug: {list.ToJistr(40)} ==> {element.ToJistr()}");
            return element;
         }
      }
      return value;
   }
}