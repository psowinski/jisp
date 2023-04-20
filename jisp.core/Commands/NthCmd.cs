namespace Jisp.Core;

public class NthCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var list = args.ToList(2);
      var seq = list[0] as IEnumerable<object> ?? Enumerable.Empty<object>();
      var idx = list[1].ToJinum();
      var element = seq.Skip((int)Math.Max(0, idx - 1)).FirstOrNil();
      return element;
   }
}
