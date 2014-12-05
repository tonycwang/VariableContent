using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using VariableContent.Domain.MappingTemplates;

namespace VariableContent.Domain.SectionTemplates
{
    public class VariableContent
        : Item
    {
        public const string VariableContentTemplateId = "{99154DB7-F1DC-46CB-B1A5-F1AAE330B318}";
        public const string MappingSetFieldId = "{464C84B9-7982-4D7E-A4C5-045D64E4E8FF}";
        public const string MaxRecursionDepthFieldId = "{D3D2F9EF-1F38-47A2-A153-D8923C73D150}";

        public MappingSet MappingSet
        {
            get
            {
                ReferenceField referenceField = this.Fields[new ID(MappingSetFieldId)];

                Assert.IsNotNull(referenceField, "Mapping Set Field");
                return (referenceField.TargetItem != null)
                    ? new MappingSet(referenceField.TargetItem) 
                    : null;
            }
        }

        public int MaxRecursionDepth
        {
            get
            {
                var integerField = this.Fields[new ID(MaxRecursionDepthFieldId)];

                var result = 0;
                return int.TryParse(integerField.Value, out result)
                    ? result
                    : 0;
            }
        }

        public VariableContent(Item item)
            : base(item.ID, item.InnerData, item.Database)
        { }
    }
}