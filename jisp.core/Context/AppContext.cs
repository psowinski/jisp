namespace Jisp.Core;

public class AppContext : Context, IAppContext
{
   public static readonly string ArgsName = "#args";

   public AppContext() : base(CoreContext.Instance)
   {
   }

   public void AddArgs(object value)
   {
      Add(ArgsName, value);
   }

   public IContext CreateNamespace(string name)
      => new NamespacedContext(name, this);
}
