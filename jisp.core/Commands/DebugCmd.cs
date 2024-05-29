namespace Jisp.Core;

public class DebugCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> collection, IContext context)
   {
      var state = collection.FirstOrNil().ToBool();
      JispEvaluator.Debug(state);
      return Nil.Value;
   }
}
