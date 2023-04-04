namespace Jisp.Core;

public class DebugCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var state = args.FirstOrNil().ToBool();
      JispEvaluator.Debug = state;
      JispEvaluator.DebugIdx = 0;
      return Nil.Value;
   }
}