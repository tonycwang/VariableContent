using System;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using VariableContent.Handlers.Mapping;

namespace VariableContent.Domain.BaseTemplates
{
    public class BaseMapping
        : Item
    {
        public const string BaseMappingTemplateId = "{2AD23CE7-41EE-4155-B96D-23C40242AC4D}";
        public const string HandlerTypeFieldId = "{73B7767D-5B0B-4EC3-86D8-3F6A0614F927}";

        private Type _mappingHandlerType;
        public Type MappingHandlerType
        {
            get
            {
                if (_mappingHandlerType == null)
                {
                    var textField = this.Fields[new ID(HandlerTypeFieldId)];
                    _mappingHandlerType = (textField != null)
                        ? Type.GetType(textField.Value)
                        : null;
                }

                return _mappingHandlerType;
            }
        }

        private IMappingHandler _mappingHandler;
        public IMappingHandler MappingHandler
        {
            get
            {
                if (_mappingHandler == null)
                {
                    _mappingHandler = (MappingHandlerType != null)
                        ? Activator.CreateInstance(MappingHandlerType) as IMappingHandler
                        : null;

                }

                return _mappingHandler;
            }
        }

        public BaseMapping(Item item)
            : base(item.ID, item.InnerData, item.Database)
        {
            _mappingHandler = null;
            _mappingHandlerType = null;
        }

        #region field retrieval methods
        protected int? GetIntegerField(string fieldId)
        {
            var integerField = this.Fields[new ID(fieldId)];

            var result = 0;
            return int.TryParse(integerField.Value, out result)
                ? result
                : (int?)null;
        }

        protected Item GetInternalLinkField(string fieldId)
        {
            InternalLinkField internalLinkField = this.Fields[new ID(fieldId)];
            return (internalLinkField != null)
                ? internalLinkField.TargetItem
                : null;
        }

        protected string GetTextField(string fieldId)
        {
            TextField textField = this.Fields[new ID(fieldId)];
            return (textField != null)
                ? textField.Value
                : null;
        }
        #endregion
    }
}