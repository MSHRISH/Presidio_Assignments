using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Execeptions
{
    public class CartLimitReachedExecption:Exception
    {
        public string message;
        public CartLimitReachedExecption()
        {
            message = "Cart Limit Reached.Can't Add More Than 5 Items";
        }
        public override string Message => message;
    }
}
