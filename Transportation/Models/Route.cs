using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Models
{
    public class Route
    {

        public int Id { get; set; }

        public string? Designator { get; set; }

        public string? District { get; set; }

        public string? DayOfWeek { get; set; }

        // _________ Requirements ______________

        public string? Hardware { get; set; }

        public string? Supervision { get; set; }

        // ____________ Times _________________

        // Time
        public DateTime? AmReport { get; set; }

        // Time
        public DateTime? AmLeave { get; set; }

        // Time
        public DateTime? AmArrive { get; set; }

        // Time
        public DateTime? PmReport { get; set; }

        // ____________ Internal _________________

        [DataType(DataType.Date)]
        public DateTime? Published { get; set; }

        public bool? Inactive { get; set; }

        public bool? Select { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }

        public bool? Publc { get; set; }

        // _______________________________________




        //              ___________________ Out

        // __________________

        [ForeignKey("Ticket")]
        public int? TicketId { get; set; }

        public virtual Ticket? Ticket { get; set; }

        // __________________

        //              ___________________ In

        public ICollection<Contact>? Contacts { get; set; }

        public ICollection<Equipment>? Equipments { get; set; }

        public ICollection<Run>? Runs { get; set; }

        public ICollection<Calendar>? Calendars { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }

    }
}
