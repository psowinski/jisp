namespace Jisp.Core;

public class CondCmd : IEveluator
{
   //["cond", "if-a", "then expr-a", "if-b", "then expr-b"]
   //["cond", "if-a", "a", "if-b", "b", "then else expr"]
   //["cond", "then else expr"]
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var seq = args.GetEnumerator();
      while(seq.MoveNext())
      {
         var value = seq.Current.EvaluateJisp(context);
         if (!seq.MoveNext())
            return value;

         if (value.ToBool())
            return seq.Current.EvaluateJisp(context);
      }
      return Nil.Value;
   }
}