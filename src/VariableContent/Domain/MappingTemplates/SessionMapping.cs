using Sitecore.Data.Items;
using VariableContent.Domain.BaseTemplates;

namespace VariableContent.Domain.MappingTemplates
{
    public class SessionMapping
        : BaseVariableMapping
    {
        public const string SessionMappingTemplateId = "{89326A0D-6418-4B16-B955-433BB318D4B4}";
        public const string SessionVariableNameFieldId = "{AE4EBFA3-2309-451C-BDEB-26404488646D}";

        public string SessionVariableName { get { return base.GetTextField(SessionVariableNameFieldId); } }

        public SessionMapping(Item item) 
            : base(item)
        { }
    }
}