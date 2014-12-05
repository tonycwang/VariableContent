using System;
using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace VariableContent.InsertRules
{
    public class MappingSetInsertRule
        : Sitecore.Data.Masters.InsertRule
    {
        public const string ExplicitVariableTemplatesItemId = "{637E6B84-2C78-41C3-B2E9-EA93062AB6DB}";

        public MappingSetInsertRule(Int32 count)
        { }

        public override void Expand(List<Item> masters, Item item)
        {
            var variableMappingsFolder = item.Database.GetItem(new ID(ExplicitVariableTemplatesItemId));
            foreach (Item variableMapping in variableMappingsFolder.Children)
            {
                masters.Add(variableMapping);
            }
        }
    }
}