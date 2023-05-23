namespace Jisp.Core;

[CmdName("!=")]
public class NotEqualCmd : CompareToCmdBase
{
   public NotEqualCmd() : base(x => x != 0) {}
}
