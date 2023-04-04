namespace Jisp.Core;

public static class JispEvaluator
{
   public static bool Debug { get; set; }
   public static uint DebugIdx = 0;

   public static object EvaluateJisp(this object value, IContext context)
   {
      if (value is DataList) return value;

      if (value is List<object> list && list.Count > 0)
      {
         var element = list[0].EvaluateJisp(context);

         if (element is string cmd)
            element = context.Find(cmd) ?? throw new Exception($"Unknown command {cmd}");
         
         if (element is IEveluator eval)
         {
            var idx = Debug ? ++DebugIdx : 0;
            if (Debug) Console.WriteLine($"DBG({idx}): {list.ToJistr(40).ToLiteral()} => ");
            
            var ret = eval.Evaluate(list.Skip(1), context);
            
            if (Debug && idx > 0) Console.WriteLine($"DBG({idx}): => {ret.ToJistr().ToLiteral()}");
            return ret;
         }
         
         return element ?? Nil.Value;
      }
      return value;
   }
   
   public static object EvaluateJispSeq(this IEnumerable<object> seq, IContext context)
   {
      object last = Nil.Value;
      foreach (var expr in seq)
         last = expr.EvaluateJisp(context);
      return last;
   }
}