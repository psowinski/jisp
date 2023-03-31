namespace Jisp.Core;
public class Function : IEveluator
{
   private List<string> names;
   private object code;
   private IContextFactory factory;
   
   public override string ToString() 
      => $"[function {this.names.ToJistr()} {this.code.ToJistr()}]";

   public Function(IContextFactory factory, object args, object code)
   {
      try
      {
         var names = (args as IEnumerable<object>)?.Cast<string>().ToList();
         if (names is null)
            throw new Exception("Missing parameters list");

         this.names = names;
         this.code = code;
         this.factory = factory;
      }
      catch(Exception ex)
      {
         throw new Exception(
            $"ERR: Invalid function declaration at {args.ToJistr()} {code.ToJistr()}",
            ex);
      }
   }

   public object Evaluate(IEnumerable<object> seq, IContext context)
   {
      var localContext = CreateContext(seq, context);
      var ret = this.code.EvaluateJisp(localContext);
      return ret;
   }

   private IContext CreateContext(IEnumerable<object> seq, IContext context)
   {
      if (this.names.Count == 0)
         return context;

      var localContext = this.factory.CreateLocal(context);

      var bindings = this.names.Zip(seq.ToSeq(this.names.Count));
      foreach (var (name, expr) in bindings)
      {
         var value = expr.EvaluateJisp(context);
         localContext.Add(name, value);
      }

      return localContext;
   }
}
