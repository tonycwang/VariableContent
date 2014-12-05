using System.Web;
using Sitecore.Diagnostics;
using VariableContent.Domain.MappingTemplates;

namespace VariableContent.Handlers.Mapping.ExplicitVariable
{
    public class SessionMappingHandler
        : IMappingHandler
    {
        public string Handle(MappingArgs args)
        {
            Assert.IsNotNull(args, "Null mapping arguments");
            Assert.IsNotNull(args.Mapper, "No mapping defined");

            var sessionMapping = new SessionMapping(args.Mapper);

            Assert.IsNotNull(HttpContext.Current, "Null HttpContext");
            Assert.IsNotNull(HttpContext.Current.Session, "Null HttpSessionState");
            
            var result = HttpContext.Current.Session[sessionMapping.SessionVariableName];
            return (result == null)
                ? string.Empty
                : result.ToString();
        }
    }
}