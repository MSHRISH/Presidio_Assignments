using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Execeptions
{
    public class ItemAlreadyInCart:Exception
    {
        public string message;
        public ItemAlreadyInCart() 
        {
            message = "Item Already Exists in the Cart";
        }
        public override string Message => message;
    }
}
