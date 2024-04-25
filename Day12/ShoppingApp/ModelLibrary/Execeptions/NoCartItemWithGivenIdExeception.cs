using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Execeptions
{
    public class NoCartItemWithGivenIdExeception:Exception
    {
        public string message;
        public NoCartItemWithGivenIdExeception()
        {
            message = "The Given Cat Item Id does not exist";
        }

        public override string Message => message;
    }
}
