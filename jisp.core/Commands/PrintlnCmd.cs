namespace Jisp.Core;

public class PrintlnCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, Context context)
   {
      foreach (var item in args)
         Console.Write(item.EvaluateJisp(context).ToJistr());

      Console.Write(Environment.NewLine);
      return Nil.Value;
   }
}
