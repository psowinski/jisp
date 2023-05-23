namespace Jisp.Core;

[CmdName("<")]
public class LessCmd : CompareToCmdBase
{
   public LessCmd() : base(x => x < 0) {}
}
