using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public string RequestMessage { get; set; }  
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; } = "Active";

        public int RequestRaisedBy { get; set; }
        public Employee RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; } = null;
        public Employee RequestClosedByEmployee { get; set; }

        public ICollection<Solution> Solutions { get; set; }
        public override string ToString()
        {
            return $"Request Number: {RequestId}\n" +
                $"Request Message: {RequestMessage}\n" +
                $"Request Date: {RequestDate}\n" +
                $"Closed Date: {ClosedDate}\n" +
                $"Request Status: {RequestStatus}\n" +
                $"Raised By Employee Id: {RequestRaisedBy}\n" +
                $"Closed By Employee Id: {RequestClosedBy}";
        }
    }
}
