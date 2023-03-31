namespace Jisp.Core;

class Context : IContext
{
   private Dictionary<string, object> data = new ();
   public ContextType Type { get; }
   protected IContext? upper = null;

   public Context(IContext upper) : this(ContextType.Local)
   {
      this.upper = upper;
   }

   protected Context(ContextType type)
   {
      Type = type;
   }

   public IContext? UpperContext(ContextType type)
   {
      if (this.upper != null)
      {
         if (this.upper.Type == type)
            return this.upper;
         return this.upper.UpperContext(type);
      }
      return null;
   }

   public bool TryAdd(string name, object value)
   {
      return this.data.TryAdd(name, value);
   }
   
   public void Add(string name, object value)
   {
      if(!TryAdd(name, value))
         throw new Exception($"ERR: Object {name} already exists in current context");
   }

   public object? Find(string name)
   {
      if (this.data.TryGetValue(name, out var value))
         return value;
      else if (this.upper != null)
         return this.upper.Find(name);
      return null;
   }
}
