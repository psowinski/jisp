namespace Jisp.Core;

public class AppContext : Context
{
   public static readonly string ArgsName = "#args";

   public AppContext() : base(ContextType.App, CoreContext.Instance)
   {
   }

   public void AddArgs(object value)
   {
      Add(ArgsName, value);
   }
   
   public override IContext CreateLocal() => new LocalContext(this);

   public IContext CreateNamespace(string name)
   {
      return this; //TODO: return decorator
   }
}
