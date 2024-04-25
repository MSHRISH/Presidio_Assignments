using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Execeptions
{
    public class NoCartWithGivenIdExecption:Exception
    {
        string message;

        public NoCartWithGivenIdExecption()
        {
            message = "Cart with given ID not found";
        }
        public override string Message => message;
    }
}
