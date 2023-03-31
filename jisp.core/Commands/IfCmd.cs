namespace Jisp.Core;

public class IfCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var list = args.ToList(3);
      var condition = list[0].EvaluateJisp(context).ToBool();
      return list[condition ? 1 : 2].EvaluateJisp(context);
   }
}
