namespace Jisp.Core;

public class LocalContext : Context
{
   public LocalContext(IContext upper) : base(ContextType.Local, upper)
   {
   }
   
   public override IContext CreateLocal() => new LocalContext(this);
}
