namespace Jisp.Core;

public class LetCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, Context context)
   {
      var list = args.ToList(2);
      if (list[0] is not IEnumerable<object> bindings)
         throw new Exception($"ERR: Expected let bindings at {args.ToJistr()}");

      var localContext = CreateContext(context, bindings.ToList());
      var code = list[1];

      var ret = code.EvaluateJisp(localContext);
      return ret;
   }

   private static Context CreateContext(Context context, List<object> bindings)
   {
      if (bindings.Count == 0)
         return context;
      if (bindings.Count % 2 == 1)
         bindings.Add(Nil.Value);

      var localContext = new Context(context);
      for (var idx = 0; idx < bindings.Count; ++idx)
      {
         var expectedName = bindings[idx];
         if (expectedName is not string name)
            throw new Exception($"ERR: Expected let binding name at {expectedName.ToJistr()}");

         var value = bindings[++idx].EvaluateJisp(localContext);
         localContext.Add(name, value);
      }
      return localContext;
   }
}
