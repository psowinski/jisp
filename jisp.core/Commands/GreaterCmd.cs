namespace Jisp.Core;

[CmdName("<=")]
public class GreaterCmd : CompareToCmdBase
{
   public GreaterCmd() : base(x => x > 0) {}
}
