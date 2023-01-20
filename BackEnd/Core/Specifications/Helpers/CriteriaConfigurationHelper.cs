using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;

namespace Core.Specifications.Helpers
{
    public static class CriteriaConfigurationHelper
    {
        public static bool IfHasParameter(int? entityField, int? parameter)
        {
            return (!parameter.HasValue || entityField == parameter);
        }

        public static bool IfHasParameter(string entityField, string? parameter)
        {
            return (string.IsNullOrEmpty(parameter) || entityField.ToLower().Contains(parameter));
        }
    }
}
