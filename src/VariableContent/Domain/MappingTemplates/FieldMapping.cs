using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.StringExtensions;
using VariableContent.Domain.BaseTemplates;

namespace VariableContent.Domain.MappingTemplates
{
    public class FieldMapping
        : BaseVariableMapping
    {
        public const string FieldMappingTemplateId = "{8D47F24E-C87A-4B00-8EED-CCD15FA41B8C}";
        public const string ItemFieldId = "{864F281E-44E8-4C61-BDDF-B1FFBC66E88A}";
        public const string FieldNameFieldId = "{2F7331F7-9860-446C-89C7-473167E8F8F0}";

        public Item Item { get { return base.GetInternalLinkField(ItemFieldId); } }

        public Field ItemField
        {
            get
            {
                return (Item != null && !FieldName.IsNullOrEmpty())
                    ? Item.Fields[FieldName]
                    : null;
            }
        }

        public string FieldName { get { return base.GetTextField(FieldNameFieldId); } }

        public FieldMapping(Item item)
            : base(item)
        { }
    }
}