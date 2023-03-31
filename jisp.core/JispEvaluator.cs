namespace Jisp.Core;

public static class JispEvaluator
{
   public static object EvaluateJisp(this object value, IContext context)
   {
      if (value is List<object> list && list.Count > 0)
      {
         var element = list[0].EvaluateJisp(context);
         if (element is string cmd)
            element = context.Find(cmd) ?? element;
         if (element is IEveluator eval)
         {
            var ret = eval.Evaluate(list.Skip(1), context);
            return ret;
         }
         if (element is not null)
            return element;
      }
      return value;
   }
}