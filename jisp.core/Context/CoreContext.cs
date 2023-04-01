namespace Jisp.Core;

internal class CoreContext : AppContext
{
   public static CoreContext Instance { get; }

   static CoreContext()
   {
      var cp = new CommandsProvider();
      Instance = new CoreContext();
      Instance.Add(cp.Provide());

      var libText = Resources.GetTextFile("jisp.lib.json");
      var libCode = JispParser.Parse(libText);
      libCode.EvaluateJisp(Instance);
   }
}
