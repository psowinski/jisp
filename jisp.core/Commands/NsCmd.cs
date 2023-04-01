namespace Jisp.Core;

public class NsCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var arg1 = args.FirstOrNil();
      if (arg1 is not string name)
         throw new Exception($"ERR: Expected namespace name at {args.ToJistr()}");

      var nsContext = context.FindAppContext().CreateNamespace(name);
      var last = args.Skip(1).EvaluateAllJisp(nsContext);
      return last;
  }
}
