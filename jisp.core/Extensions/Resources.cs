using System.Reflection;

namespace Jisp.Core;

public static class Resources
{
   public static string GetTextFile(string embeddedFileName)
   {
      var assembly = Assembly.GetExecutingAssembly();
      var resourceName = assembly.GetManifestResourceNames().First(s => s.EndsWith(embeddedFileName, StringComparison.CurrentCultureIgnoreCase));

      using var stream = assembly.GetManifestResourceStream(resourceName);
      if (stream == null)
         throw new InvalidOperationException($"Could not load resource {embeddedFileName}");

      using var reader = new StreamReader(stream);
      var text = reader.ReadToEnd();
      return text;
   }
}
