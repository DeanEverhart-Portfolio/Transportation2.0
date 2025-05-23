using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Transportation.Models
{
    public class Student
    {
        public int Id { get; set; }

        public String FirstName { get; set; }

        public string LastName { get; set; }

        // ____________ phone _____________

        public string? AreaCode { get; set; }

        public string? Prefix { get; set; }

        public string? Line { get; set; }

        public string? Extension { get; set; }

        public string? PhoneLabel { get; set; }

        [Display(Name = "Gatekeeper")]
        public string? Gatekeeper { get; set; }

        public string? GatekeeperNote { get; set; }

        [Display(Name = "Note")]
        public string? PhoneNote { get; set; }

        public string? PhoneSort { get; set; }

        [Display(Name = "Phone")]
        public string? FullPhone
        {
            get
            {
                return PhoneLabel + " " + " " + " " + "(" + AreaCode + ")" + " " + Prefix + "-" + Line + " " + " " + Extension;
            }
        }

        // ____________ phone2 ________________

        public string? AreaCode2 { get; set; }

        public string? Prefix2 { get; set; }

        public string? Line2 { get; set; }

        public string? Extension2 { get; set; }

        public string? Phone2Label { get; set; }

        public string? Gatekeeper2 { get; set; }

        public string? Gatekeeper2Note { get; set; }

        [Display(Name = "Note")]
        [DisplayFormat(NullDisplayText = "Note")]
        public string? Phone2Note { get; set; }

        public string? Phone2Sort { get; set; }

        public string? FullPhone2
        {
            get
            {
                return Phone2Label + " " + " " + " " + "(" + AreaCode2 + ")" + " " + Prefix2 + " " + Line2 + " " + Extension2;
            }
        }

        // ____________ phone3 ________________

        public string? AreaCode3 { get; set; }

        public string? Prefix3 { get; set; }

        public string? Line3 { get; set; }

        public string? Extension3 { get; set; }

        public string? Phone3Label { get; set; }

        public string? Gatekeeper3 { get; set; }

        public string? Gatekeeper3Note { get; set; }

        [Display(Name = "Note")]
        [DisplayFormat(NullDisplayText = "Note")]
        public string? Phone3Note { get; set; }

        public string? Phone3Sort { get; set; }

        public string? FullPhone3
        {
            get
            {
                return Phone3Label + " " + Prefix3 + " " + Line3 + " " + Extension3;
            }
        }

        //_________ phone (end) __________

        //__________ email __________

        [Display(Name = "Email")]
        [DisplayFormat(NullDisplayText = "Email")]
        public string? Email { get; set; }

        public string? EmailLabel { get; set; }

        public string? EmailSort { get; set; }

        // ----------------

        public string? Email2 { get; set; }

        public string? Email21Label { get; set; }

        public string? Email2Sort { get; set; }

        // ----------------

        public string? Email3 { get; set; }

        public string? Email2Label { get; set; }

        public string? Email3Sort { get; set; }

        //__________ email (end) __________

        // __________ website _____________

        [Display(Name = "Domain")]
        public string? Domain { get; set; }

        [Display(Name = "DNS")]
        public string? Domain1 { get; set; }

        // __________ website _____________
        [Display(Name = "Website")]
        [DisplayFormat(NullDisplayText = "Website")]
        public string? Website { get; set; }

        public string? WebsiteLabel { get; set; }

        public string? Website2 { get; set; }

        public string? Website2Label { get; set; }

        public string? Website3 { get; set; }

        public string? Website3Label { get; set; }

        // _______ website (end) __________

        // _________ address __________

        public string? StreetNumber { get; set; }

        public string? StreetName { get; set; }

        public string? StreetDesignator { get; set; }

        public string? Street2 { get; set; }

        public string? TownCity { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }

        public string? County { get; set; }

        public string? Country { get; set; }

        public string? Map { get; set; }

        [Display(Name = "Address")]
        [DisplayFormat(NullDisplayText = "Address")]
        public string? FullAddress
        {
            get
            {
                return StreetNumber + " " + StreetName + " " + StreetDesignator + " " + Street2 + ", " + TownCity + ", " + ZipCode;
            }
        }

        // _________ address (end) __________

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

        // ________________________________________________________

        //              ___________________ In

        //public ICollection<Class>? Classes { get; set; }

        //              ___________________ Out

        [ForeignKey("Run")]
        public int? RunId { get; set; }

        public virtual Run? Run { get; set; }

        // __________________

        [ForeignKey("Ticket")]
        public int? TicketId { get; set; }

        public virtual Ticket? Ticket { get; set; }

        // __________________

        //              ___________________ Authentication

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }
    }
}
