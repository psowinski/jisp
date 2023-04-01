namespace Jisp.Core;

public class LocalContext : Context
{
   public LocalContext(IContext upper) : base(ContextType.Local, upper)
   {
   }
}
