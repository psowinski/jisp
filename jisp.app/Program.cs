if (args.Length == 0)
{
   Console.WriteLine("Jisp v.0.1");
   Console.WriteLine("jisp.app <code file> <optional: input data file>");
   return;
}

var codeFile = args[0];
var inputFile = args.Length > 1 ? args[1] : "";

var ret = Code.ExecuteJisp(codeFile, inputFile);
Console.WriteLine(ret);
