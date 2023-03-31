namespace Jisp.Core;

public class NsContext : Context
{
   public NsContext(IContext appContext) : base(ContextType.App, appContext)
   {
      if (appContext.Type != ContextType.App)
         throw new ArgumentException(nameof(appContext));
   }
}
