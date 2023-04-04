namespace Jisp.Core;

public class Function : IEveluator
{
   private List<string> names;
   private object code;
   
   public override string ToString() 
      => $"[function {this.names.ToJistr()} {this.code.ToJistr()}]";

   public Function(List<string> names, object code)
   {
      this.names = names;
      this.code = code;
   }

   public object Evaluate(IEnumerable<object> seq, IContext context)
   {
      var localContext = context.CreateNextContext();
      FillContext(localContext, seq.Select(x => x.EvaluateJisp(context)));
      var ret = this.code.EvaluateJisp(localContext);
      return ret;
   }

   private void FillContext(IContext context, IEnumerable<object> seq)
   {
      var enumerator = seq.GetEnumerator();
      foreach (var name in this.names)
      {
         var value = (name.StartsWith("..."))
                     ? enumerator.GetRest().ToList()
                     : (enumerator.MoveNext() ? enumerator.Current : Nil.Value);
         context.Add(name, value);
      }
   }
}
