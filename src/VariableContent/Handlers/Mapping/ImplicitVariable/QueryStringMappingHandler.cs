using System.Web;
using Sitecore.Diagnostics;

namespace VariableContent.Handlers.Mapping.ImplicitVariable
{
    public class QueryStringMappingHandler
        : IMappingHandler
    {
        public string Handle(MappingArgs args)
        {
            Assert.IsNotNull(args, "Null mapping arguments");
            Assert.IsNotNull(HttpContext.Current, "Null HttpContext");
            Assert.IsNotNull(HttpContext.Current.Request, "Null HttpRequest");
            
            var result = HttpContext.Current.Request.QueryString[args.Variable];
            return result ?? string.Empty;
        }
    }
}