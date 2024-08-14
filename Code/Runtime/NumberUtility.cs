using System;

namespace NiGames.Utility
{
    /// <summary>
    /// Provides utility methods for abbreviating numeric values.
    /// </summary>
    public static class NumberUtility
    {
        private static readonly string[] _abbreviationsShort = { "", "k", "m", "b", "t", "q", "Q", "s", "S", "o", "n", "d", "U", "D" };
        private static readonly string[] _abbreviationsFull = { "", 
            "thousand", "million", "billion", "trillion", "quadrillion", 
            "quintillion", "sextillion", "septillion", "octillion", 
            "nonillion", "decillion", "undecillion", "duodecillion" 
        };
        
        private static readonly string[] _romanThousands = { "", "M", "MM", "MMM" };
        private static readonly string[] _romanHundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static readonly string[] _romanTens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private static readonly string[] _romanOnes = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        
        /// <summary>
        /// Converts a large number to a more readable format with a metric abbreviation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="full">If true, full abbreviations such as "thousand" and "million" are used instead of single letters.</param>
        /// <param name="decimalPlaces">The number of decimal places to display in the result.</param>
        /// <returns>The formatted string representation of the given value with a metric abbreviation.</returns>
        public static string AbbreviateNumber(double value, bool full = false, int decimalPlaces = 2)
        {
            var abbreviations = full ? _abbreviationsFull : _abbreviationsShort;
            
            var suffixIndex = 0;
            while (value >= 1000 && suffixIndex < abbreviations.Length - 1)
            {
                value /= 1000;
                suffixIndex++;
            }
            
            var suffix = abbreviations[suffixIndex];
            var formatString = decimalPlaces > 0 ? $"F{decimalPlaces.ToString()}" : "F0";
            
            return $"{value.ToString(formatString)}{suffix}";
        }
        
        /// <summary>
        /// Formats a number into Roman letters. Values from <c>1</c> to <c>3999</c> are allowed.
        /// </summary>
        public static string ToRoman(int value)
        {
            if (value is < 1 or > 3999)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 1 and 3999");
            }
            
            return $"{_romanThousands[value / 1000]}{_romanHundreds[value % 1000 / 100]}{_romanTens[value % 100 / 10]}{_romanOnes[value % 10]}";
        }
    }
}