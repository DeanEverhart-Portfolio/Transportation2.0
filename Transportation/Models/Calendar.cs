using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Transportation.Models
{
    public class Calendar
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public string? DayOfWeek { get; set; }

        public string? Item { get; set; }

        public string? Event { get; set; }

        public TimeSpan? Dismissal { get; set; }

        public TimeSpan? Return { get; set; }

        public string? ReturnDayOfWeek { get; set; }

        [Display(Name = "Return")]
        public string? CalendarDateReturnDisplay //{ get; set; }
        {
            get
            {
                return ReturnDayOfWeek + " " + Return;
            }
        }

        public string? Type { get; set; }

        public string? SubType { get; set; }

        // ____________ Internal _________________

        [DataType(DataType.Date)]
        public DateTime? Published { get; set; }

        public bool? Inactive { get; set; }

        public bool? Select { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }

        public bool? Publc { get; set; }

        // _______________________________________

        // _____________________________________________

        //              ___________________ Out

        [ForeignKey("Contact")]
        public int? ContactId { get; set; }

        public virtual Contact? Contact { get; set; }

        // __________________

        [ForeignKey("Route")]
        public int? RouteId { get; set; }

        public virtual Route? Route { get; set; }

        // __________________

        [ForeignKey("Run")]
        public int? RunId { get; set; }

        public virtual Run? Run { get; set; }

        // __________________

        [ForeignKey("Ticket")]
        public int? TicketId { get; set; }

        public virtual Ticket? Ticket { get; set; }

        // __________________

        //              ___________________ In


        // __________________


        // ________________________________ Authentication 

        // User Id
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }

    }
}
