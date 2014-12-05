using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VariableContent
{
    public class Enclosure
    {
        #region properties
        public string Open { get; set; }
        public string Close { get; set; }
        #endregion

        #region ctor
        public Enclosure()
        {
            Open = "<";
            Close = ">";
        }

        public Enclosure(string open, string close)
        {
            Open = open;
            Close = close;
        }
        #endregion

        #region methods
        public IList<string> GetMatchList(string value)
        {
            var regex = new Regex(string.Format(@"\{0}(.*?)\{1}", Open, Close));
            var result = new List<string>();
            foreach (Match match in regex.Matches(value))
            {
                result.Add(match.Value);
            }
            return result;
        }

        public string RemoveEnclosure(string value)
        {
            return value
                .Replace(Open, string.Empty)
                .Replace(Close, string.Empty);
        }
        #endregion
    }
}