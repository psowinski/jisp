namespace Jisp.Core;

public class DumpCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, Context context)
   {
      foreach (var item in args)
         Console.WriteLine(item.ToJistr());
      return Nil.Value;
   }
}
