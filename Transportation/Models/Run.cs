using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Models
{
    public class Run
    {

        public int Id { get; set; }

        public string? Designator { get; set; }

        public TimeSpan? AmStart { get; set; }

        public TimeSpan? PmStart { get; set; }

        public TimeSpan? AmArrive { get; set; }

        public TimeSpan? PmArrive { get; set; }

        public int? Sequence { get; set; }

        public string? DayOfWeek { get; set; }

        public string? District { get; set; }

        public string? School { get; set; }

        // _________ Requirements ______________

        public string? Hardware { get; set; }

        public string? Supervision { get; set; }


        // ____________ Internal _________________

        [DataType(DataType.Date)]
        public DateTime? Published { get; set; }

        public bool? Inactive { get; set; }

        public bool? Select { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }

        public bool? Publc { get; set; }

        // _______________________________________

        // _______________________________________

        //              ___________________ Out

        [ForeignKey("Route")]
        public int? RouteId { get; set; }

        public virtual Route? Route { get; set; }

        // __________________

        [ForeignKey("Ticket")]
        public int? TicketId { get; set; }

        public virtual Ticket? Ticket { get; set; }

        // __________________

        //              ___________________ In

        public ICollection<Contact>? Contacts { get; set; }

        public ICollection<Calendar>? Calendars { get; set; }

        public ICollection<Student>? Students { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }

    }
}
