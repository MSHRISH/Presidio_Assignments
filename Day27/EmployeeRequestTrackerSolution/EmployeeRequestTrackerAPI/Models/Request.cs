using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRequestTrackerAPI.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestedDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }="Active";

        public int? RequestRaisedBy { get; set; }
        [ForeignKey("RequestRaisedBy")]
        public Employee RaisedByEmployee { get; set; }
        public int? RequestClosedBy { get; set; } = null;

        [ForeignKey("RequestClosedBy")]
        public Employee RequestClosedByEmployee { get; set; }
    }
}
