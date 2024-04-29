using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Execeptions
{
    public class CartAlreadyExistExecption:Exception
    {
        public string message;
        public CartAlreadyExistExecption()
        {
            message = "The Customer Already has a Cart";
        }
        public override string Message => Message;

    }
}
