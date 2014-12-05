using Sitecore.Diagnostics;
using VariableContent.Domain.MappingTemplates;

namespace VariableContent.Handlers.Mapping.ExplicitVariable
{
    public class FieldMappingHandler
        : IMappingHandler
    {
        public string Handle(MappingArgs args)
        {
            Assert.IsNotNull(args, "Null mapping arguments");
            Assert.IsNotNull(args.Mapper, "No mapping defined");

            var fieldMapping = new FieldMapping(args.Mapper);

            return (fieldMapping.ItemField != null)
                ? fieldMapping.ItemField.Value
                : string.Empty;
        }
    }
}