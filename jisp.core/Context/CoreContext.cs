namespace Jisp.Core;

internal class CoreContext : Context
{
   public static CoreContext Instance { get; }

   CoreContext(IEnumerable<(string, IEveluator)> cmds)
   {
      foreach (var (name, cmd) in cmds)
         Add(name, cmd);
   }

   static CoreContext()
   {
      var cp = new CommandsProvider();
      Instance = new CoreContext(cp.Provide());

      var libText = Resources.GetTextFile("jisp.lib.json");
      var libCode = JispParser.Parse(libText);
      libCode.EvaluateJisp(Instance);
   }
}
