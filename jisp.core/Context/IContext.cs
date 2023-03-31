namespace Jisp.Core;

public interface IContext
{
   ContextType Type { get; }
   IContext? UpperContext(ContextType type);
   void Add(string name, object value);
   object? Find(string name);
}
