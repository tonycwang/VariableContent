using System;
using System.Collections.Generic;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.RenderField;
using VariableContent.Handlers;

namespace VariableContent.Pipeline.RenderingField
{
    // Configuration Example
    //
    // <processor type="VariableContent.Pipeline.RenderingField.VariableReplace, VariableContent" >
    //   <openEnclosure>{</openEnclosure>
    //   <closeEnclosure>{</closeEnclosure>
    //   <fieldTypes hint="list:AddFieldType">
    //     <fieldTypeKey>rich text</fieldTypeKey>
    //     <fieldTypeKey>single-line text</fieldTypeKey>
    //     <fieldTypeKey>multi-line text</fieldTypeKey>
    //   </fieldTypes>
    // </processor>

    public class VariableReplace
    {
        #region fields
        private readonly IList<string> _fieldTypes;
        private readonly IVariableContentHandler _varaibleContentHandler;
        #endregion

        #region properties
        public string OpenEnclosure
        {
            get { return _varaibleContentHandler.Enclosure.Open; }
            set { _varaibleContentHandler.Enclosure.Open = value; }
        }

        public string CloseEnclosure
        {
            get { return _varaibleContentHandler.Enclosure.Close; }
            set { _varaibleContentHandler.Enclosure.Close = value; }
        }
        #endregion

        #region ctor
        public VariableReplace()
            : this(new VariableContentHandler())
        { }

        public VariableReplace(IVariableContentHandler variableContentHandler)
        {
            _fieldTypes = new List<string>();
            _varaibleContentHandler = variableContentHandler;
        }
        #endregion

        #region methods
        public void Process(RenderFieldArgs args)
        {
            Assert.IsNotNull(Context.Site, "context site is null");
            Assert.IsNotNull(args.Item, "render field item is null");
            Assert.IsNotNull(_fieldTypes, "no field types defined");

            if (Context.PageMode.IsPageEditor ||
                Context.Site.Name.Equals("shell", StringComparison.CurrentCultureIgnoreCase) ||
                _fieldTypes.Count == 0 ||
                !_fieldTypes.Contains(args.FieldTypeKey))
            {
                return;
            }

            args.Result.FirstPart = _varaibleContentHandler.Handle(args);
        }

        public void AddFieldType(string fieldTypeKey)
        {
            Assert.ArgumentNotNull(fieldTypeKey, "fieldTypeKey");
            _fieldTypes.Add(fieldTypeKey);
        }
        #endregion
    }
}