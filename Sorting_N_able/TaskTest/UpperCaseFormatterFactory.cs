using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_N_able.TaskTest
{
    public class UpperCaseFormatterFactory : IFormatterFactory
    {
        public IFormatter CreateFormatter()
        {
            return new UpperCaseFormatter();
        }
    }
}
