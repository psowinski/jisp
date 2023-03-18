using Jisp.Core;
using AppContext = Jisp.Core.AppContext;

public static class Code
{
   public static string ExecuteJisp(string codeFile, string inputFile)
   {
      object code;
      object input;

      try
      {
         code = JispParser.Parse(File.ReadAllText(codeFile));
      }
      catch (FileNotFoundException)
      {
         Console.WriteLine($"ERR: Fail to load code file {codeFile}");
         return "";
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.ToString());
         return "";
      }

      try
      {
         input =
            string.IsNullOrEmpty(inputFile)
            ? Nil.Value
            : JispParser.Parse(File.ReadAllText(inputFile));
      }
      catch (FileNotFoundException)
      {
         Console.WriteLine($"ERR: Fail to load data input file {inputFile}");
         return "";
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.ToString());
         return "";
      }

      return RunApp(code, input);
   }

   private static string RunApp(object code, object input)
   {
      var appContext = new AppContext();
      appContext.Add("input", input);

      var numbering = new TestNumbering();
      appContext.Add("generate-number",
         new ExternalFunction(
            args => numbering.Generate((string)args[0], (string)args[1])));

      var ret = code.EvaluateJisp(appContext);
      return ret.ToJistr();
   }
}
