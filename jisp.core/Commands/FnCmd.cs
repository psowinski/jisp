namespace Jisp.Core;

public class FnCmd : IEveluator
{
   private readonly IContextFactory factory;

   public FnCmd(IContextFactory factory)
   {
      this.factory = factory;
   }

   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var list = args.ToList(2);
      var fn = new Function(this.factory, list[0], list[1]);
      return fn;
   }
}
