namespace Jisp.Core;

public class AndCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      object ret = Nil.Value;
      foreach (var item in args)
      {
         ret = item.EvaluateJisp(context);
         if (!ret.ToBool()) break;
      }
      return ret;
   }
}
