using System.Collections.Generic;
using Sitecore.Pipelines.RenderField;

namespace VariableContent.Handlers
{
    public interface IVariableContentHandler
    {
        #region properties
        Enclosure Enclosure { get; }
        #endregion

        #region methods
        string Handle(RenderFieldArgs args);

        string Handle(string content, Domain.SectionTemplates.VariableContent item, IList<string> variables, int recursionDepth);
        #endregion
    }
}