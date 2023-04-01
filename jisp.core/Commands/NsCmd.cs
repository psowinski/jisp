namespace Jisp.Core;

public class NsCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var arg1 = args.FirstOrNil();
      if (arg1 is not string name)
         throw new Exception($"ERR: Expected namespace name at {args.ToJistr()}");

      if (context.UpperContext(ContextType.App) is AppContext appContext)
         context = appContext.CreateNamespace(name);
      else
         throw new Exception($"ERR: Missing app context at {args.ToJistr()}");

      object last = Nil.Value;
      foreach (var arg in args.Skip(1))
         last = arg.EvaluateJisp(context);
      return last;
  }
}
