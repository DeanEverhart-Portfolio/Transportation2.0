using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string? Item { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        // service, repair
        public string? Type { get; set; }

        public bool? Scheduled1 { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Scheduled { get; set; }

        public string? Description { get; set; }

        public string? Assigned { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Completed { get; set; }

        public string? Note { get; set; }

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

        // ______________________________________________________

        //              ___________________ Out

        [ForeignKey("Equipment")]
        public int? EquipmmentId { get; set; }

        public virtual Equipment? Equipment { get; set; }

        //              ___________________ Authentication
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }

    }
}
