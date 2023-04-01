namespace Jisp.Core;

public static class ContextExt
{
   public static IAppContext FindAppContext(this IContext context)
   {
      if (context is IAppContext appContext)
         return appContext;
      if (context.Upper != null)
         return context.Upper.FindAppContext();
      throw new ArgumentException("ERR: Missing app context.");
   }
}
