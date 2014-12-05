 using System.Web;
 using Sitecore.Diagnostics;
 using VariableContent.Domain.MappingTemplates;

namespace VariableContent.Handlers.Mapping.ExplicitVariable
{
    public class QueryStringMappingHandler
        : IMappingHandler
    {
        public string Handle(MappingArgs args)
        {
            Assert.IsNotNull(args, "Null mapping arguments");
            Assert.IsNotNull(args.Mapper, "No mapping defined");
            
            var queryStringMapping = new QueryStringMapping(args.Mapper);
            
            Assert.IsNotNull(HttpContext.Current, "Null HttpContext");
            Assert.IsNotNull(HttpContext.Current.Request, "Null HttpRequest");

            var result = HttpContext.Current.Request.QueryString[queryStringMapping.QueryStringParameterName];
            return result ?? string.Empty;
        }
    }
}