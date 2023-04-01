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

   public void Add(string name, object value) 
      => this.appContext.Add($"{this.ns}/{name}", value);

   public IContext CreateNextContext()
      => this.appContext.CreateNextContext();

   public object? Find(string name)
      => this.appContext.Find(name);
}
