namespace Jisp.Core;

public static class BooleanExt
{
   public static bool ToBool(this object value)
   {
      if (value is bool condition) return condition;
      if (value is Nil) return false;
      return true;
   }
}
