namespace Jisp.Core;

public class GetCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, Context context)
   {
      object? collection = null;
      foreach(var expr in args)
      {
         var value = expr.EvaluateJisp(context);
         collection = (collection is null)
            ? value 
            : GetFrom(collection, value);
      }
      return collection ?? Nil.Value;
   }

   private object GetFrom(object collection, object key)
   {
      if (collection is IList<object> list)
      {
         if (key is not decimal idx)
            throw new Exception($"ERR: Expected index at {key.ToJistr()}");

         if (idx >= 0 && idx < list.Count)
            return list[(int)idx];
      }
      if (collection is IDictionary<string, object> dict)
      {
         if (key is not string name)
            throw new Exception($"ERR: Expected key at {key.ToJistr()}");

         if (dict.TryGetValue(name, out var ret))
            return ret;
      }
      return Nil.Value;
   }
}
