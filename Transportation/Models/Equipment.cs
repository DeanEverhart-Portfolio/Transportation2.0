using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Transportation.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string? Designator { get; set; }

        public string? Type { get; set; }

        public bool? Status { get; set; }

        public string? StatusNote { get; set; }

        public string? Replacement { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOT { get; set; }

        public string? Note { get; set; }

        // ______________________________________

        public int? Radio { get; set; }

        public string? RadioNote { get; set; }

        public bool? DVR { get; set; }

        public int? BuiltIns { get; set; }

        public int? Wheelchair { get; set; }

        // _______________________________________

        public string? VIN { get; set; }

        public int? CapacityAdult { get; set; }

        public int? CapacityChild { get; set; }

        public string? Location { get; set; }

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

        //              ___________________ In

        public ICollection<Service>? Service { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }

    }
}
