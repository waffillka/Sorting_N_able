using Sorting_N_able.TaskTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sorting_N_able.Test
{
    public class UpperFormaterTest
    {
        [Theory]
        [InlineData("qqq","QQQ")]
        [InlineData("", "")]
        [InlineData("qwert  yuiop", "QWERT  YUIOP")]
        [InlineData("QWERTY", "QWERTY")]
        [InlineData("hollow, world!", "HOLLOW, WORLD!")]
        [InlineData("qwer_tyu[iop", "QWER_TYU[IOP")]
        [InlineData("125+125", "125+125")]
        //[InlineData("", "")]
        //[InlineData("", "")]
        public void StringToUpper(string testString, string rigntString)
        {
            IFormatterFactory formatterFactory = new UpperCaseFormatterFactory();
            Printer printer = new Printer(formatterFactory.CreateFormatter());
            Assert.Equal(rigntString, printer.print(testString));
        }
    }
}
