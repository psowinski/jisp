namespace Jisp.Core;

public static class ContextExt
{
   public static IContext FindAppContext(this IContext context)
   {
      var value = context.Find(JispKeys.ModuleName);
      if (value is string str && str == JispKeys.AppContextName)
         return context;

      if (context.Upper != null)
         return context.Upper.FindAppContext();

      throw new ArgumentException("ERR: Missing app context.");
   }

   public static IContext FindModuleContext(this IContext context)
   {
      var value = context.Find(JispKeys.ModuleName);
      if (value is string)
         return context;

      if (context.Upper != null)
         return context.Upper.FindModuleContext();

      throw new ArgumentException("ERR: Missing module context.");
   }   

   public static IContext GetModule(this IContext context, string path)
   {
      var manager = context.Find(JispKeys.ModulesManager) as IModulesManager ?? throw new InvalidOperationException("ERR: Missing modules manager.");
      var moduleContext = manager.GetModule(path);
      return moduleContext;
   }

   public static IContext CreateNextContext(this IContext context) => new Context(context);
}
