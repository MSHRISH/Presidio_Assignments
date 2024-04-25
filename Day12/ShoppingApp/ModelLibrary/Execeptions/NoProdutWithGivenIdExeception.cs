using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Execeptions
{
    public class NoProdutWithGivenIdExeception:Exception
    {
        string message;
        public NoProdutWithGivenIdExeception()
        {
            message = "Product with the given ID is not found";
        }
        public override string Message => message;
    }
}
