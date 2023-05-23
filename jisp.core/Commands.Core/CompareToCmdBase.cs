namespace Jisp.Core;

public class CompareToCmdBase : IEveluator
{
   private readonly Func<int, bool> resultInterpreter;

   public CompareToCmdBase(Func<int, bool> resultInterpreter)
   {
      this.resultInterpreter = resultInterpreter ?? throw new ArgumentNullException(nameof(resultInterpreter));
   }
   
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var list = args.Select(x => x.EvaluateJisp(context)).ToList(2);
      var ret = list[0].JispCompare(list[1]);
      return this.resultInterpreter.Invoke(ret);
   }
}
