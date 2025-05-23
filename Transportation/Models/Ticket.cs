using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string? School1 { get; set; }

        public string? Staff1 { get; set; }

        public string? Student1 { get; set; }

        public string? Grade1 { get; set; }

        public string? Route1 { get; set; }

        public string? Address1 { get; set; }

        public string? Stop1 { get; set; }

        public string? Time1 { get; set; }

        public string? Driver1 { get; set; }

        public string? DA1 { get; set; }

        public string? Description { get; set; }

        public string? Text { get; set; }

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

        //[ForeignKey("Class")]
        //public int? CLassId { get; set; }

        //public virtual Class? Class { get; set; }

        //              ___________________ In

        public ICollection<Contact>? Contacts { get; set; }

        public ICollection<Equipment>? Equipments { get; set; }

        public ICollection<Route>? Routes { get; set; }

        public ICollection<Run>? Runs { get; set; }

        public ICollection<Student>? Students { get; set; }

        public ICollection<Calendar>? Calendars { get; set; }

        //              ___________________ Authentication

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }

        //              ___________________ 

    }
}
