using System.Text;
namespace Jisp.Core;

public class StrCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var sb = new StringBuilder();
      foreach (var item in args)
         sb.Append(item.EvaluateJisp(context).ToJistr());
      return sb.ToString();
   }
}
