namespace Jisp.Core;

public class AppContext : Context
{
   public AppContext() : this(Nil.Value)
   {
   }

   public AppContext(object args) : this(CoreProvider.Commands, CoreProvider.Libs, args)
   {
   }

   public AppContext(IEnumerable<(string, object)> commands, IEnumerable<object> libs, object args)
   {
      Add(JispKeys.ModulesManager, new ModulesManager(this.CreateNextContext));
      Add(JispKeys.ModuleName, JispKeys.AppContextName);
      Add(JispKeys.Args, args);

      foreach (var (name, cmd) in commands)
         Add(name, cmd);
      foreach (var code in libs)
         code.EvaluateJisp(this);
   }
}
