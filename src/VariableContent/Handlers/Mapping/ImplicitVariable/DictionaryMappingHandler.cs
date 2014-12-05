using Sitecore.Diagnostics;
using Sitecore.Globalization;

namespace VariableContent.Handlers.Mapping.ImplicitVariable
{
    public class DictionaryMappingHandler
        : IMappingHandler
    {
        public string Handle(MappingArgs args)
        {
            Assert.IsNotNull(args, "Null mapping arguments");

            var result = Translate.Text(args.Variable);

            return (args.Variable.Equals(result))
                ? string.Empty
                : result;
        }
    }
}