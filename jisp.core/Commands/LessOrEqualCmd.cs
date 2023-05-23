namespace Jisp.Core;

[CmdName("<=")]
public class LessOrEqualCmd : CompareToCmdBase
{
   public LessOrEqualCmd() : base(x => x <= 0) {}
}
