namespace Jisp.Core;

public class Proxy : IEveluator
{
   private readonly IContext proxyContext;
   private readonly string name;
   
   public override string ToString() 
      => $"[proxy {this.name} in {this.proxyContext.Find(JispKeys.ModuleName) ?? ""}]";

   public Proxy(string name, IContext proxyContext)
   {
      this.name = name;
      this.proxyContext = proxyContext;
   }

   public object Evaluate(IEnumerable<object> collection, IContext context)
   {
      var evlSeq = collection.Select(x => x.EvaluateJisp(context));
      var code = this.proxyContext.Find(this.name);
      var ret = (new [] { code }).Union(evlSeq).EvaluateJisp(this.proxyContext);
      return ret;
   }
}
