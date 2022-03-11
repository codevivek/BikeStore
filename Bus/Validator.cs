using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mybikes.Bus
{
    class Validator : IValidator
    {
        public bool IsDigit(string text)
        {
            Regex number = new Regex(@"^([1-9]+)$");
            return number.IsMatch(text);
        }

        public bool IsAlphabetLetters(string text)
        {
            Regex pattern = new Regex(@"^([a-zA-Z|\s]+)$");
            return pattern.IsMatch(text);
        }
    }
}
