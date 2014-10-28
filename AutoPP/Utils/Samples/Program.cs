using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Match _tempQry = Regex.Match("Leukemia AND \"Breast AND Cancer\"", @"""[^""\\]*(?:\\.[^""\\]*)*""");
        }
    }
}
