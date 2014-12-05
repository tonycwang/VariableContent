using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using VariableContent.Domain.BaseTemplates;

namespace VariableContent.Domain.MappingTemplates
{
    public class MappingSet
        : Item
    {
        public const string MappingSetTemplateId = "{B03138E6-8D02-4657-BCA6-32C20852D062}";
        public const string SystemMappersFieldId = "{8557F57E-F38E-4950-A97B-661E75AB6627}";

        private IList<BaseMapping> _defaultMappings;
        public IList<BaseMapping> SystemMappers
        {
            get
            {
                if (_defaultMappings == null)
                {
                    _defaultMappings = new List<BaseMapping>();

                    MultilistField multilistField = this.Fields[new ID(SystemMappersFieldId)];
                    foreach (var targetId in multilistField.TargetIDs)
                    {
                        var target = Sitecore.Context.Database.GetItem(targetId);
                        _defaultMappings.Add(new BaseMapping(target));
                    }
                }

                return _defaultMappings;
            }
        }

        public MappingSet(Item item)
            : base(item.ID, item.InnerData, item.Database)
        {
            _defaultMappings = null;
        }
    }
}