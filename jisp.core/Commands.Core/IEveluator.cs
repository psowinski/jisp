namespace Jisp.Core;

public interface IEveluator
{
   object Evaluate(IEnumerable<object> collection, Context context);
}
