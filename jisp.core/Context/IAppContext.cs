namespace Jisp.Core;

public interface IAppContext : IContext
{
   void AddArgs(object value);
   IContext CreateNamespace(string name);
}
