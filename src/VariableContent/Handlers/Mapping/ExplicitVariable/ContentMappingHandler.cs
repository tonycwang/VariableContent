using Sitecore.Diagnostics;
using VariableContent.Domain.MappingTemplates;

namespace VariableContent.Handlers.Mapping.ExplicitVariable
{
    public class ContentMappingHandler
        : IMappingHandler
    {
        public string Handle(MappingArgs args)
        {
            Assert.IsNotNull(args, "Null mapping arguments");
            Assert.IsNotNull(args.Mapper, "No mapping defined");

            var contentMapping = new ContentMapping(args.Mapper);

            return contentMapping.Content;
        }
    }
}