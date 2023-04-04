namespace Jisp.Core;

public class DefCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      try
      {
         var list = args.ToList(2);
         var name = list[0].RequireString();
         var value = list[1].EvaluateJisp(context);
         context.FindAppContext().Add(name, value);
         return Nil.Value;
      }
      catch (Exception ex)
      {
         throw new Exception(
            $"ERR: Invalid definition at {args.ToJistr()}", ex);
      }
   }
}
