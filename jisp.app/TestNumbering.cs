public class TestNumbering
{
   Dictionary<string, decimal> numbers = new ();

   public decimal Generate(string domain, string name)
   {
      var key = $"{domain}/{name}";
      if (this.numbers.ContainsKey(key))
         return ++this.numbers[key];
      this.numbers.Add(key, 1);
      return 1;
   }
}