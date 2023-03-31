namespace Jisp.Core;

public class DoCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      object last = Nil.Value;
      foreach (var arg in args)
         last = arg.EvaluateJisp(context);
      return last;
   }
}
