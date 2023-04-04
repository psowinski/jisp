namespace Jisp.Core;

public class FnCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      try
      {
         var list = args.ToList(2);
         var names = list[0].RequireStringList();
         var fn = new Function(names, list[1]);
         return fn;
      }
      catch(Exception ex)
      {
         throw new Exception(
            $"ERR: Invalid function declaration at {args.ToJistr()}", ex);
      }
   }
}
