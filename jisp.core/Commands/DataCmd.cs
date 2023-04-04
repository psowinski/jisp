namespace Jisp.Core;

[CmdName("#")]
public class DataCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var ret = args.ToList();
      return new DataList(ret);
   }
}
