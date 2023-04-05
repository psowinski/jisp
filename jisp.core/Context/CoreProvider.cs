using System.Collections.ObjectModel;
namespace Jisp.Core;

public static class CoreProvider
{
   public static ReadOnlyCollection<(string, object)> Commands { get; }
   public static ReadOnlyCollection<object> Libs { get; }

   static CoreProvider()
   {
      Commands = new CommandsProvider().Provide()
         .Select(x => (x.Item1, (object)x.Item2))
         .ToList()
         .AsReadOnly();

      var libs = new List<object>();
      var sysLibText = Resources.GetTextFile("jisp.lib.json");
      var sysLibCode = JispParser.Parse(sysLibText);
      libs.Add(sysLibCode);
      Libs = libs.AsReadOnly();
   }
}