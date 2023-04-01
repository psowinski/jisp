namespace Jisp.Core;

public interface IContext
{
   ContextType Type { get; }
   IContext? Upper { get; }
   void Add(string name, object value);
   object? Find(string name);
   IContext CreateNextContext();
}
