using Transportation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Route = Transportation.Models.Route;

namespace Transportation.Data
{
    public class blonddachshund : IdentityDbContext<Users>
    {
        public blonddachshund(DbContextOptions<blonddachshund> options)
            : base(options)
        {
        }

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Run> Run { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}


// ___________________ from FVM _________________________

//using Transportation.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Route = Transportation.Models.Route;

//namespace Transportation.Data
//{
//    public class ApplicationDbContext : IdentityDbContext<Users>
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<Calendar> Calendars { get; set; }
//        public DbSet<Contact> Contacts { get; set; }
//        public DbSet<Equipment> Equipment { get; set; }
//        public DbSet<Route> Route { get; set; }
//        public DbSet<Run> Run { get; set; }
//        public DbSet<Service> Service { get; set; }
//        public DbSet<Student> Student { get; set; }
//    }
//}


// __________________ original ________________________

//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace Transportation.Data
//{
//    public class ApplicationDbContext : IdentityDbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }
//    }
//}