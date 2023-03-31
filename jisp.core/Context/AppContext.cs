namespace Jisp.Core;

public class AppContext : IContext
{
   public static readonly string ArgsName = "#args";

   public AppContext() : base(ContextType.App)
   {
      this.upper = CoreContext.Instance;
   }

   public void AddArgs(object value)
   {
      Add(ArgsName, value);
   }
}
