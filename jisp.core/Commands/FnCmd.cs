namespace Jisp.Core;

public class FnCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, Context context)
   {
      var list = args.ToList(2);
      var fn = new Function(list[0], list[1]);
      return fn;
   }
}
