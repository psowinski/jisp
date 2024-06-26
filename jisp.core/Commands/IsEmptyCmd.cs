namespace Jisp.Core;

[CmdName("empty?")]
public class IsEmptyCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var arg = args.FirstOrNil();
      if (arg is Nil) return true;
      if (arg is string text) return string.IsNullOrEmpty(text);
      if (arg is IEnumerable<object> coll) return !coll.Any();
      if (arg is IDictionary<string, object> dict) return !dict.Any();
      return false;
   }
}
