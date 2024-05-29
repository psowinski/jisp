namespace Jisp.Core;

public interface IEveluator
{
   object Evaluate(IEnumerable<object> args, IContext context);
}
