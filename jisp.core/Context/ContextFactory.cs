namespace Jisp.Core;

public class ContextFactory
{
   IContext CreateApp() => new AppContext();

   IContext CreateLocal(IContext upper) => new LocalContext(upper);

   IContext CreateNs(string ns, IContext context)
   {
      var appContext = context.UpperContext(ContextType.App);
      if (appContext is null) throw new ArgumentException("Missing app context.");
      
      var nsContext = new NsContext(appContext);
      appContext.Add(ns, nsContext);
      return nsContext;
   }
}