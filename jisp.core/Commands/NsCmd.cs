namespace Jisp.Core;

public class NsCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var name = args.FirstOrNil().RequireString();
      var nsContext = context.FindAppContext().CreateNamespace(name);
      var last = args.Skip(1).EvaluateJispSeq(nsContext);
      return last;
  }
}
