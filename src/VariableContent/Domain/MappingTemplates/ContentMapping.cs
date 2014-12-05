using Sitecore.Data.Items;
using VariableContent.Domain.BaseTemplates;

namespace VariableContent.Domain.MappingTemplates
{
    public class ContentMapping
        : BaseVariableMapping
    {
        public const string ContentMappingTemplateId = "{3CE51D40-AE96-4CB6-857E-326ECE892A4E}";
        public const string ContentFieldId = "{1C9F1889-65BD-4A7D-86A8-9E7ED8B702BA}";

        public string Content { get { return base.GetTextField(ContentFieldId); } }

        public ContentMapping(Item item)
            : base(item)
        { }
    }
}