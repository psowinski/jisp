namespace Jisp.Core;

public class ApplyCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var input = args
         .Skip(1)
         .Select(x => x.EvaluateJisp(context))
         .SelectMany(x => {
            if (x is IEnumerable<object> seq)
               return seq;
            return new[] {x};
         });

      var list = args.Take(1).Union(input).ToList();
      var ret = list.EvaluateJisp(context);
      return ret;
   }
}
