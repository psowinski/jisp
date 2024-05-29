namespace Jisp.Core;

/*public class NsCmd : IEveluator
{
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var name = args.FirstOrNil().RequireString();
      var nsContext = context.FindAppContext().CreateNamespace(name);
      var last = args.Skip(1).EvaluateJispSeq(nsContext);
      return last;
  }
}*/

public class ImportCmd : IEveluator
{
   //cmd           file       alias   fn to import
   //["import", "./lib.json", "ext", "sum"]
   //["ext/sum", 1, 2]
   public object Evaluate(IEnumerable<object> args, IContext context)
   {
      var prms = args.ToList(2);
      var path = prms[0].RequireString();
      var alias = prms[1].RequireString();

      var moduleContext = context.GetModule(path);
      foreach (var import in args.Skip(2))
      {
         var name = import.RequireString();
         var proxy = new Proxy(name, moduleContext);
         context.Add($"{alias}/{name}", proxy);
      }
      return moduleContext.Find(JispKeys.ModuleResult) ?? throw new ArgumentNullException("ERR: Missing module result.");
  }
}