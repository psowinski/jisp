namespace Jisp.Core;

public static class JispEvaluator
{
   private static bool debugMode = false;
   private static uint debugIdx = 0;

   public static void Debug(bool enable = true)
   {
      debugIdx = 0;
      debugMode = enable;
   }

   public static object EvaluateJisp(this object value, IContext context)
   {
      if (value is List<object> list)
         value = EvaluateList(list, context);

      return value;
   }

   private static object EvaluateList(List<object> list, IContext context)
   {
      if (list.Count == 0)
         return list;

      var element = GetFirstCommand(list, context);

      if (element is string name)
         element = RecognizeString(name, context);

      if (element is IEveluator eval)
         element = EvaluateIEveluator(eval, list, context);

      return element ?? Nil.Value;
   }

   private static object GetFirstCommand(List<object> list, IContext context)
   {
      return list[0].EvaluateJisp(context);
   }

   private static object RecognizeString(string name, IContext context)
      => context.Find(name) ?? throw new ArgumentException($"Unknown command {name}");

   private static object EvaluateIEveluator(IEveluator eval, IEnumerable<object> list, IContext context)
   {
      BeginCmd(list);
      var ret = eval.Evaluate(list.Skip(1), context);
      EndCmd(ret);

      return ret;
   }

   private static void BeginCmd(IEnumerable<object> list)
   {
      if (debugMode)
      {
         Console.WriteLine($"DBG({++debugIdx}): {list.ToJistr(40).ToLiteral()} => ");
      }
   }

   private static void EndCmd(object ret)
   {
      if (debugMode)
      {
         Console.WriteLine($"DBG({debugIdx}): => {ret.ToJistr().ToLiteral()}");
      }
   }

   public static object EvaluateJispSeq(this IEnumerable<object> seq, IContext context)
   {
      object last = Nil.Value;
      foreach (var expr in seq)
         last = expr.EvaluateJisp(context);
      return last;
   }
}