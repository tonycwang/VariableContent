using Sitecore.Data.Items;

namespace VariableContent.Domain.BaseTemplates
{
    public class BaseVariableMapping
        : BaseMapping
    {
        public const string BaseVariableMappingTemplateId = "{BB2B2527-6F08-4C75-9A59-249C1D63EFB3}";
        public const string VariableNameFieldId = "{A4F4B45F-6ADA-4F32-8ACB-646ABE50A81F}";

        public string VariableName { get { return base.GetTextField(VariableNameFieldId); } }

        public BaseVariableMapping(Item item)
            : base(item)
        { }
    }
}