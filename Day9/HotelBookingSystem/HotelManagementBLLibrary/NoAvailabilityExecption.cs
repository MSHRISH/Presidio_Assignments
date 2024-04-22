using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBLLibrary
{
    public class NoAvailabilityExecption:Exception
    {
        string message;
        public NoAvailabilityExecption()
        {
            message = "There is no availability for this Room";
        }
        public override string Message => Message; 
    }
}
