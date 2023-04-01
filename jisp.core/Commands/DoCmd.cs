namespace Jisp.Core;

public class DoCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var last = args.EvaluateAllJisp(context);
      return last;
   }
}
