using System.Collections.Generic;
using System.Management.Instrumentation;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.RenderField;
using Sitecore.StringExtensions;
using VariableContent.Domain.BaseTemplates;
using VariableContent.Handlers.Mapping;

namespace VariableContent.Handlers
{
    public class VariableContentHandler
        : IVariableContentHandler
    {
        #region properties
        public Enclosure Enclosure { get; private set; }
        #endregion

        #region ctor
        public VariableContentHandler()
        {
            Enclosure = new Enclosure();
        }

        public VariableContentHandler(string openEnclosure, string closeEnclosure)
        {
            Enclosure = new Enclosure(openEnclosure, closeEnclosure);
        }
        #endregion

        #region methods
        public string Handle(RenderFieldArgs args)
        {
            var variables = Enclosure.GetMatchList(args.FieldValue);
            var variableContentItem = new Domain.SectionTemplates.VariableContent(args.Item);
            return Handle(args.Result.FirstPart, variableContentItem, variables, 0);
        }

        public string Handle(string content, Domain.SectionTemplates.VariableContent item, IList<string> variables, int recursionDepth)
        {
            if (item.MappingSet == null) return content;

            var result = content;

            foreach (var variable in variables)
            {
                var token = variable;
                var replacementValue = GetReplacementValue(Enclosure.RemoveEnclosure(variable), item, recursionDepth + 1);

                if (replacementValue == null) continue;
                
                result = result.Replace(token, replacementValue);
            }

            return result;
        }

        public string GetReplacementValue(string variableNoEnclosure, Domain.SectionTemplates.VariableContent item, int recursionDepth)
        {
            if (recursionDepth > item.MaxRecursionDepth)
            {
                Log.Error("Maximum recursion depth exceeded.", this);
                return null;
            }

            var mappingSet = item.MappingSet;
            if (mappingSet == null)
            {
                return null;
            }
            
            //Execute MappingHandler from MappingSet
            var query = string.Format("{0}//*[@Variable Name = '{1}']", mappingSet.Paths.Path, variableNoEnclosure);
            var mappingItem = Context.Database.SelectSingleItem(query);
            if (mappingItem != null)
            {
                return ExecuteHandler(new BaseMapping(mappingItem), variableNoEnclosure, item, recursionDepth);
            }

            //Execute SystemMappingHandlers 
            foreach (var defaultMapper in mappingSet.SystemMappers)
            {
                var value = ExecuteHandler(defaultMapper, variableNoEnclosure, item, recursionDepth);
                if (!value.IsNullOrEmpty())
                {
                    return value;
                }
            }

            Log.Error(string.Format("No mapper defined to handle {0}.", variableNoEnclosure), this);
            return null;
        }

        public string ExecuteHandler(BaseMapping mappingItem, string variable, Domain.SectionTemplates.VariableContent item, int recursionDepth)
        {
            var mappingHandler = mappingItem.MappingHandler;
            if (mappingHandler == null)
            {
                throw new InstanceNotFoundException(string.Format("Could not instantiate: {0}.", mappingItem.MappingHandlerType));
            }

            var mappedValue = mappingHandler.Handle(new MappingArgs(item, mappingItem, Enclosure, variable));
            var variables = Enclosure.GetMatchList(mappedValue);
            return Handle(mappedValue, item, variables, recursionDepth);
        }

        #endregion
    }
}