using System;
using Sitecore.Diagnostics;
using Sitecore.StringExtensions;
using VariableContent.Domain.MappingTemplates;

namespace VariableContent.Handlers.Mapping.ExplicitVariable
{
    public class DateTimeMappingHandler
        : IMappingHandler
    {
        public string Handle(MappingArgs args)
        {
            Assert.IsNotNull(args, "Null mapping arguments");
            Assert.IsNotNull(args.Mapper, "No mapping defined");

            var dateTimeMapping = new DateTimeMapping(args.Mapper);

            var dateTime = DateTime.Now;
            if (dateTimeMapping.HasOffset)
            {
                dateTime = ApplyOffset(dateTime, dateTimeMapping);
            }

            return (!dateTimeMapping.Format.IsNullOrEmpty())
                ? dateTime.ToString(dateTimeMapping.Format)
                : dateTime.ToString();
        }

        private static DateTime ApplyOffset(DateTime dateTime, DateTimeMapping mapping)
        {
            var result = dateTime;

            if (mapping.HasOffset)
            {
                switch (mapping.OffsetUnit)
                {
                    case "Year":
                        result = result.AddYears(mapping.OffsetValue.Value);
                        break;
                    case "Month":
                        result = result.AddMonths(mapping.OffsetValue.Value);
                        break;
                    case "Day":
                        result = result.AddDays(mapping.OffsetValue.Value);
                        break;
                    case "Hour":
                        result = result.AddHours(mapping.OffsetValue.Value);
                        break;
                    case "Minute":
                        result = result.AddMinutes(mapping.OffsetValue.Value);
                        break;
                    case "Second":
                        result = result.AddSeconds(mapping.OffsetValue.Value);
                        break;
                }
            }

            return result;
        }
    }
}