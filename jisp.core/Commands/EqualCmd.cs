namespace Jisp.Core;

[CmdName("=")]
public class EqualCmd : CompareToCmdBase
{
   public EqualCmd() : base(x => x == 0) {}
}
