using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanFormatter
{
    /// <summary>
    /// Sources
    ///     https://fr.wikipedia.org/wiki/Num%C3%A9ration_romaine
    ///     https://stackoverflow.com/questions/22392810/integer-to-roman-format
    /// </summary>
    class RomanFormatter : ICustomFormatter, IFormatProvider
    {
        private static List<Tuple<string, int>> table = new List<Tuple<string, int>>
        {
            new Tuple<string, int>("M",  1000),
            new Tuple<string, int>("CM", 900),
            new Tuple<string, int>("D",  500),
            new Tuple<string, int>("CD", 400),
            new Tuple<string, int>("C",  100),
            new Tuple<string, int>("XC", 90),
            new Tuple<string, int>("L",  50),
            new Tuple<string, int>("XL", 40),
            new Tuple<string, int>("X",  10),
            new Tuple<string, int>("IX", 9),
            new Tuple<string, int>("V",  5),
            new Tuple<string, int>("IV", 4),
            new Tuple<string, int>("I",  1),
        };

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if ((format == "Roman") && (arg.GetType() == typeof(int)))
            {
                var romanNumber = string.Empty;

                var number = (int)arg;

                while (number > 0)
                {
                    var element = table.First(n => n.Item2 <= number);
                    number -= element.Item2;
                    romanNumber += element.Item1;
                }
                return romanNumber;
            }
            else return HandleOtherFormats(format, arg);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
    }
}
