using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Converter.Models
{
    public static class Calculator
    {
        private static Dictionary<Units, decimal> UnitValuesToBit = new Dictionary<Units, decimal>
        {
            { Units.Bit, 1M },
            { Units.Byte, 0.125m },
            { Units.Kilobit, 0.001m },
            { Units.Kilobyte, 0.000125m },
            { Units.Megabit,  1.0E-6m},
            { Units.Megabyte,  1.25E-7m},
            { Units.Gigabit,  1.0E-9m},
            { Units.Gigabyte,  1.25E-10m},
            { Units.Terabit,  1.0E-12m},
            { Units.Terabyte,  1.25E-13m},
            { Units.Petabit,  1.0E-15m},
            { Units.Petabyte,  1.25E-16m},
            { Units.Exabit,  1.0E-18m},
            { Units.Exabyte,  1.25E-19m},
            { Units.Zettabit,  1.0E-21m},
            { Units.Zettabyte,  1.25E-22m},
            { Units.Yottabit,  1.0E-24m},
            { Units.Yottabyte,  1.25E-25m}
        };

        public static Dictionary<string, string> Calculate(int quantity, Units type, int kilo)
        {
            var typeQuantityToBit = UnitValuesToBit[Units.Bit] / UnitValuesToBit[type] * quantity;
            var result = new Dictionary<string, string>();
            foreach (var unit in UnitValuesToBit.Keys)
            {
                var value = UnitValuesToBit[unit] * typeQuantityToBit * 1000 / kilo;
                var valueAsString = value.ToString("G6", CultureInfo.InvariantCulture);
                result.Add(unit.ToString(), valueAsString);
            }

            return result;
        }
    }
}