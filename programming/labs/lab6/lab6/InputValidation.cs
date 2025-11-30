using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal static class InputValidation
    {
        public static bool ValidateDouble(char ch, string text)
        {
            if (char.IsDigit(ch) || ch == (char)Keys.Back)
                return true; ;

            if (ch == ',' && !text.Contains(","))
                return true;
            if (ch == '-' && text.Length == 0)
                return true;

            return false;
        }
    }
}
