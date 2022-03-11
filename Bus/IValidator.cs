using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mybikes.Bus
{
    interface IValidator
    {
        bool IsDigit(string text);
        bool IsAlphabetLetters(string text);
    }
}
