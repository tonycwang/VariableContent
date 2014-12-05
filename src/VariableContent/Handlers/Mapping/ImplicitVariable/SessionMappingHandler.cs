using System.Web;
using Sitecore.Diagnostics;

namespace VariableContent.Handlers.Mapping.ImplicitVariable
{
    public class SessionMappingHandler
        : IMappingHandler
    {
        public string Handle(MappingArgs args)
        {
            Assert.IsNotNull(args, "Null mapping arguments");
            Assert.IsNotNull(HttpContext.Current, "Null HttpContext");
            Assert.IsNotNull(HttpContext.Current.Session, "Null HttpSessionState");
            
            var result = HttpContext.Current.Session[args.Variable];
            return (result == null)
                ? string.Empty
                : result.ToString();
        }
    }
}