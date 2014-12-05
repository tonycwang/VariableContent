using Sitecore.Data.Items;

namespace VariableContent.Handlers.Mapping
{
    public class MappingArgs
    {
        public Enclosure Enclosure { get; private set; }
        public string Variable { get; private set; }
        public Item Item { get; private set; }
        public Item Mapper { get; private set; }

        public MappingArgs(Item item, Item mapper, Enclosure enclosure, string variable)
        {
            Item = item;
            Mapper = mapper;
            Enclosure = enclosure;
            Variable = variable;
        }
    }
}