namespace Jisp.Core;

public class AppContext : Context
{
   public AppContext() : base(ContextType.App)
   {
      this.upper = CoreContext.Instance;
   }
}
