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
         var name = args.FirstOrNil();
         this.def.Evaluate(new [] {name, ret}, context);
         return Nil.Value;
      }
      catch (Exception ex)
      {
         throw new Exception(
            $"ERR: Invalid function definition at {args.ToJistr()}", ex);
      }
   }
}