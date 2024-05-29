namespace Jisp.Core;

public class ModulesManager : IModulesManager
{
   private readonly Dictionary<string, IContext> modules = new();
   private readonly Func<IContext> createNextContext;

   public ModulesManager(Func<IContext> createNextContext)
   {
      this.createNextContext = createNextContext;
   }

   public IContext GetModule(string path)
   {
      path = Path.GetFullPath(path);
      if (this.modules.TryGetValue(path, out var moduleContext))
         return moduleContext;

      moduleContext = LoadModule(path);
      this.modules.Add(path, moduleContext);

      return moduleContext;
   }

   private IContext LoadModule(string path)
   {
      var text = File.ReadAllText(path);
      var code = JispParser.Parse(text);

      var moduleContext = this.createNextContext();
      moduleContext.Add(JispKeys.ModuleName, path);

      var last = code.EvaluateJisp(moduleContext);
      moduleContext.Add(JispKeys.ModuleResult, last);

      return moduleContext;
   }
}