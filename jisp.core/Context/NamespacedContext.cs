namespace Jisp.Core;

public class NamespacedContext : IContext
{
   private readonly string ns;
   private readonly IAppContext appContext;

   public NamespacedContext(string ns, IAppContext appContext)
   {
      this.ns = ns;
      this.appContext = appContext;
   }

   public IContext? Upper => this.appContext.Upper;

   private string Prefix(string name) => $"{this.ns}/{name}";

   public void Add(string name, object value) 
      => this.appContext.Add(Prefix(name), value);

   public IContext CreateNextContext()
      => this.appContext.CreateNextContext();

   public object? Find(string name)
   {
      var ret = this.appContext.Find(Prefix(name));
      if (ret is null)
         ret = this.appContext.Find(name);
      return ret;
   }
}
