namespace Jisp.Core;

public class DefCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, Context context)
   {
      var list = args.ToList(2);
      if (list[0] is not string name)
         throw new Exception($"ERR: Expected definition name at {args.ToJistr()}");

      context = context.UpperContext(ContextType.App) ?? context;
      context.Add(name, list[1].EvaluateJisp(context));
      return Nil.Value;
   }
}
