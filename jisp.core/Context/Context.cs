namespace Jisp.Core;

public class Context : IContext
{
   private Dictionary<string, object> data = new();
   public IContext? Upper { get; }

   protected Context(IContext? upper = null)
   {
      this.Upper = upper;
   }

   public bool TryAdd(string name, object value)
   {
      return this.data.TryAdd(name, value);
   }

   public void Add(string name, object value)
   {
      if (!TryAdd(name, value))
         throw new Exception($"ERR: Object {name} already exists in current context");
   }

   public object? Find(string name)
   {
      if (this.data.TryGetValue(name, out var value))
         return value;
      else if (this.Upper != null)
         return this.Upper.Find(name);
      return null;
   }

   public IContext CreateNextContext() => new Context(this);
}
