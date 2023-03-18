using System.Reflection;

namespace Jisp.Core;

public class CommandsProvider
{
   public List<(string, IEveluator)> Provide()
   {
      var cmds = new List<(string, IEveluator)>();
      var implementingTypes = GetCommandTypes();
      foreach (var implementingType in implementingTypes)
      {
         var instance = Activator.CreateInstance(implementingType) as IEveluator;
         if (instance is null) continue;

         var name = GetCommandName(implementingType);
         cmds.Add((name, instance));
      }
      return cmds;
   }

   private IEnumerable<Type> GetCommandTypes()
   {
      var interfaceType = typeof(IEveluator);
      var implementingTypes = Assembly.GetExecutingAssembly().GetTypes()
          .Where(
            t => t.IsClass
            && interfaceType.IsAssignableFrom(t)
            && t.Name.ToUpper().EndsWith("CMD"));
      return implementingTypes;
   }

   private static string GetCommandName(Type implementingType)
   {
      var attribute = implementingType
         .GetCustomAttributes(typeof(CmdNameAttribute), false)
         .FirstOrDefault() as CmdNameAttribute;
      if (attribute is not null)
         return attribute.Name;

      var name = implementingType.Name.ToLower()[0..^3];
      return name;
   }
}
