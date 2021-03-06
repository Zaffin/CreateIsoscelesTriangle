﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using CreateIsoscelesTriangle.Resources;

namespace CreateIsoscelesTriangle.ValidationRules
{
    public class PositiveNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var number = value as string;

            if (double.TryParse(number, out double doubleValue))
            {
                if (doubleValue > 0)
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, UIStrings.PositiveNumberRuleLabel);
                }
            }
            else
            {
                return new ValidationResult(false, UIStrings.PositiveNumberRuleLabel);
            }
        }
    }
}
