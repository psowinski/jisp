namespace Jisp.Core;

public class DefnCmd : IEveluator
{
   DefCmd def = new DefCmd();
   FnCmd fn = new FnCmd();

   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      try
      {
         var ret = this.fn.Evaluate(args.Skip(1), context);
         this.def.Evaluate(new [] {args.FirstOrNil(), ret}, context);
         return Nil.Value;
      }
      catch (Exception ex)
      {
         throw new Exception(
            $"ERR: Invalid function definition at {args.ToJistr()}", ex);
      }
   }
}