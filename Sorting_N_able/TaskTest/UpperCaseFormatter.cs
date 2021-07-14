using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_N_able.TaskTest
{
    class UpperCaseFormatter : IFormatter
    {
        public string Format(string input)
        {
            var result = new StringBuilder();

            foreach(var c in input)
            {
                result.Append(char.ToUpper(c));
            }
            return result.ToString();
        }
    }
}
