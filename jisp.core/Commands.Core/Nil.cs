namespace Jisp.Core;

public class Nil
{
   private Nil() {}
   private static Nil instance = new Nil();
   public static Nil Value => Nil.instance;

   public override string ToString() => "nil";
}
