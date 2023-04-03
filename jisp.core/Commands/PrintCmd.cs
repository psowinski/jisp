namespace Jisp.Core;

public class PrintCmd : IEveluator
{
   StrCmd str = new StrCmd();
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var ret = this.str.Evaluate(args, context) as string;
      Console.Write(ret);
      return Nil.Value;
   }
}