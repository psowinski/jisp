namespace Jisp.Core;

public class TailCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var list = args.ToList(1);
      var seq = list[0] as IEnumerable<object> ?? Enumerable.Empty<object>();
      var tail = seq.Skip(1).ToList();
      return tail;
   }
}
