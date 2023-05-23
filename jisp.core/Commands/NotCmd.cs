namespace Jisp.Core;

public class NotCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var first = args.FirstOrNil().EvaluateJisp(context);
      var ret = !first.ToBool();
      return ret;
   }
}
