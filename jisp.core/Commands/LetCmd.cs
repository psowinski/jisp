namespace Jisp.Core;

public class LetCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var arg1 = args.FirstOrNil();
      if (arg1 is not IEnumerable<object> bindings)
         throw new Exception($"ERR: Expected let bindings at {args.ToJistr()}");

      var localContext = context.CreateNextContext();
      FillContext(localContext, bindings.ToList());

      var last = args.Skip(1).EvaluateJispSeq(localContext);
      return last;
   }

   private void FillContext(IContext context, IEnumerable<object> bindings)
   {
      foreach (var (nameExpr, expr) in bindings.SelectPairs())
      {
         var name = nameExpr.RequireString();
         var value = expr.EvaluateJisp(context);
         context.Add(name, value);
      }
   }
}
