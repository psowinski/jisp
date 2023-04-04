using System.Collections;

namespace Jisp.Core;

public class DataList : IEnumerable<object>
{
   public List<object> Data { get; }
   public DataList(List<object> data)
   {
      Data = data;
   }

   public IEnumerator<object> GetEnumerator() => Data.GetEnumerator();
   IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();

   public override string ToString() => Data.ToJistr();
}
