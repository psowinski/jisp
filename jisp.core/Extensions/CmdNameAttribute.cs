namespace Jisp.Core;

[AttributeUsage(AttributeTargets.Class)]
class CmdNameAttribute : Attribute
{
    public string Name { get; }

    public CmdNameAttribute(string name)
    {
        Name = name;
    }
}