using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_N_able.TaskTest
{
    public class Printer
    {
        private IFormatter formatter;

        public Printer(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        public string print(string str)
        {
            return formatter.Format(str);
        }

    }
}
