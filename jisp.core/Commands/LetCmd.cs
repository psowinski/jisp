namespace Jisp.Core;

public class LetCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var arg1 = args.FirstOrNil();
      if (arg1 is not IEnumerable<object> bindings)
         throw new Exception($"ERR: Expected let bindings at {args.ToJistr()}");

      var localContext = FillContext(context.CreateNextContext(), bindings.ToList());
      var last = args.Skip(1).EvaluateAllJisp(localContext);
      return last;
   }

   private IContext FillContext(IContext context, List<object> bindings)
   {
      if (bindings.Count % 2 == 1)
         bindings.Add(Nil.Value);

      for (var idx = 0; idx < bindings.Count; ++idx)
      {
         var expectedName = bindings[idx];
         if (expectedName is not string name)
            throw new Exception($"ERR: Expected let binding name at {expectedName.ToJistr()}");

         var value = bindings[++idx].EvaluateJisp(context);
         context.Add(name, value);
      }
      return context;
   }
}
