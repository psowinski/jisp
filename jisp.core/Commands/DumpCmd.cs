namespace Jisp.Core;

public class DumpCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      foreach (var item in args)
         Console.WriteLine(item.ToJistr());
      return Nil.Value;
   }
}
