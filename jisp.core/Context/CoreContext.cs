namespace Jisp.Core;

internal class CoreContext : Context
{
   public static CoreContext Instance { get; }

   CoreContext(IEnumerable<(string, IEveluator)> cmds) : base(ContextType.Core)
   {
      foreach (var (name, cmd) in cmds)
         Add(name, cmd);
   }

   static CoreContext()
   {
      Instance = new CoreContext(new CommandsProvider().Provide());
   }   
}
