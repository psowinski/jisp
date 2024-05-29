namespace Jisp.Core;

public interface IContext
{
   IContext? Upper { get; }
   void Add(string name, object value);
   object? Find(string name);
}
