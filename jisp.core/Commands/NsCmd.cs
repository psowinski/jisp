namespace Jisp.Core;

public class NsCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var arg1 = args.FirstOrNil();
      if (arg1 is not string name)
         throw new Exception($"ERR: Expected namespace name at {args.ToJistr()}");

      var appContext = context.FindAppContext();
      var nsContext = appContext.CreateNamespace(name);

      object last = Nil.Value;
      foreach (var arg in args.Skip(1))
         last = arg.EvaluateJisp(nsContext);
      return last;
  }
}
