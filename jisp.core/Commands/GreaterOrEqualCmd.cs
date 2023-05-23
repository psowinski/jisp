namespace Jisp.Core;

[CmdName("<=")]
public class GreaterOrEqualCmd : CompareToCmdBase
{
   public GreaterOrEqualCmd() : base(x => x >= 0) {}
}
