namespace Jisp.Core;

public class AppContext : Context, IAppContext
{
   public static readonly string ArgsName = "#args";

   public AppContext() : this(CoreProvider.Commands, CoreProvider.Libs)
   {
   }

   public AppContext(IEnumerable<(string, object)> commands, IEnumerable<object> libs)
   {
      foreach (var (name, cmd) in commands)
         Add(name, cmd);
      foreach (var code in libs)
         code.EvaluateJisp(this);
   }

   public void AddArgs(object value)
   {
      Add(ArgsName, value);
   }

   public IContext CreateNamespace(string name)
      => new NamespacedContext(name, this);
}
