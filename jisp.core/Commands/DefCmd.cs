namespace Jisp.Core;

public class DefCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var list = args.ToList(2);
      if (list[0] is not string name)
         throw new Exception($"ERR: Expected definition name at {args.ToJistr()}");

      var value = list[1].EvaluateJisp(context);
      context.FindAppContext().Add(name, value);
      return Nil.Value;
   }
}
