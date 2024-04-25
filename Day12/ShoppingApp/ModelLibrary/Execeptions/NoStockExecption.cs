using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Execeptions
{
    public class NoStockExecption:Exception
    {
        public string message;
        public NoStockExecption() 
        {
            message = "The Product is out of Stock";
        }
        public override string Message => message;
    }
}
