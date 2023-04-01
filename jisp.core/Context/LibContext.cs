namespace Jisp.Core;

internal class LibContext : AppContext
{
   public static LibContext Instance { get; }

   static LibContext()
   {
      var cp = new CommandsProvider();
      Instance = new LibContext();
      Instance.Add(cp.Provide());

      var libText = Resources.GetTextFile("jisp.lib.json");
      var libCode = JispParser.Parse(libText);
      libCode.EvaluateJisp(Instance);
   }
}
