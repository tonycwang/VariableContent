using Sitecore.Data.Items;
using Sitecore.StringExtensions;
using VariableContent.Domain.BaseTemplates;

namespace VariableContent.Domain.MappingTemplates
{
    public class DateTimeMapping
        : BaseVariableMapping
    {
        public const string DateTimeMappingTemplateId = "{947E05A6-6541-444B-A278-289182B87B81}";
        public const string FormatFieldId = "{B87991F6-539F-408A-84CD-2CB7C01E72F5}";
        public const string OffsetUnitFieldId = "{DC767579-817C-4DBB-8BC0-26AB37BFD37D}";
        public const string OffsetValueFieldId = "{5B5409D7-D753-4DBA-A08A-A21DE1605062}";

        public string Format { get { return base.GetTextField(FormatFieldId); } }

        public bool HasOffset { get { return (!OffsetUnit.IsNullOrEmpty() && OffsetValue.HasValue); } }

        public string OffsetUnit { get { return base.GetTextField(OffsetUnitFieldId); } }

        public int? OffsetValue { get { return base.GetIntegerField(OffsetValueFieldId); } }

        public DateTimeMapping(Item item)
            : base(item)
        { }
    }
}