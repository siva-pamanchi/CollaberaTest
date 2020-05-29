using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaberaTest
{
    interface IConvertNumberToWord
    {
        string Conversion(int number, string sample);

        string ConvertNumberToWords(double userInput);

    }
}

