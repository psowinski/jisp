namespace Jisp.Core;

public class ExternalFunction : IEveluator
{
   private readonly Func<object[], object> fun;

   public ExternalFunction(Func<object[], object> fun)
   {
      this.fun = fun;
   }

   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var inargs = args
         .Select(arg => arg.EvaluateJisp(context))
         .ToArray() ?? new object[0];
      var ret = this.fun.Invoke(inargs);
      return ret ?? Nil.Value;
   }
}