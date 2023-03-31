namespace Jisp.Core;

public interface IContextFactory
{
   IContext CreateApp();
   IContext CreateLocal(IContext upper);
   IContext CreateNs(string ns, IContext context);
}
