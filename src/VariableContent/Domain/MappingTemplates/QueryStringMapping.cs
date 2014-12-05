using Sitecore.Data.Items;
using VariableContent.Domain.BaseTemplates;

namespace VariableContent.Domain.MappingTemplates
{
    public class QueryStringMapping
        : BaseVariableMapping
    {
        public const string QueryStringMappingTemplateId = "{B6B1EA53-A11C-448B-B147-A1EA457EF481}";
        public const string QueryStringParameterNameFieldId = "{5A15F0F3-A007-4B10-BDB9-C9C0F2A1D50E}";

        public string QueryStringParameterName { get { return base.GetTextField(QueryStringParameterNameFieldId); } }

        public QueryStringMapping(Item item)
            : base(item)
        { }
    }
}