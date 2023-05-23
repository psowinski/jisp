namespace Jisp.Core;

[CmdName("zero?")]
public class IsZeroCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var first = args.FirstOrNil().EvaluateJisp(context);
      var ret = first.JispCompare(0m);
      return ret;
   }
}