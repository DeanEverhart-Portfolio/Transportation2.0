using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transportation.Data.Migrations
{
    public partial class InitialTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Joined",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Staff1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Route1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stop1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Driver1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DA1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    Select = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publc = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hardware = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supervision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmLeave = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmArrive = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PmReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    Select = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publc = table.Column<bool>(type: "bit", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Route_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    StatusNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Replacement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Radio = table.Column<int>(type: "int", nullable: true),
                    RadioNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DVR = table.Column<bool>(type: "bit", nullable: true),
                    BuiltIns = table.Column<int>(type: "int", nullable: true),
                    Wheelchair = table.Column<int>(type: "int", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacityAdult = table.Column<int>(type: "int", nullable: true),
                    CapacityChild = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    Select = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publc = table.Column<bool>(type: "bit", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Run",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    PmStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    AmArrive = table.Column<TimeSpan>(type: "time", nullable: true),
                    PmArrive = table.Column<TimeSpan>(type: "time", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hardware = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supervision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    Select = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publc = table.Column<bool>(type: "bit", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Run", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Run_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Run_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Run_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scheduled1 = table.Column<bool>(type: "bit", nullable: true),
                    Scheduled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assigned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    Select = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publc = table.Column<bool>(type: "bit", nullable: true),
                    EquipmmentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Service_Equipment_EquipmmentId",
                        column: x => x.EquipmmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endorsement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMReport = table.Column<TimeSpan>(type: "time", nullable: true),
                    PMReport = table.Column<TimeSpan>(type: "time", nullable: true),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GatekeeperNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneSort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper2Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2Sort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper3Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3Sort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email21Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2Sort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email3Sort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website2Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website3Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetDesignator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    Select = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publc = table.Column<bool>(type: "bit", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    RunId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Run_RunId",
                        column: x => x.RunId,
                        principalTable: "Run",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GatekeeperNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneSort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper2Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2Sort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatekeeper3Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3Sort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email21Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2Sort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email3Sort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website2Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website3Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetDesignator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    Select = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publc = table.Column<bool>(type: "bit", nullable: true),
                    RunId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Student_Run_RunId",
                        column: x => x.RunId,
                        principalTable: "Run",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Student_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dismissal = table.Column<TimeSpan>(type: "time", nullable: true),
                    Return = table.Column<TimeSpan>(type: "time", nullable: true),
                    ReturnDayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: true),
                    Select = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publc = table.Column<bool>(type: "bit", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    RunId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendars_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendars_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendars_Run_RunId",
                        column: x => x.RunId,
                        principalTable: "Run",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendars_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_ContactId",
                table: "Calendars",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_RouteId",
                table: "Calendars",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_RunId",
                table: "Calendars",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_TicketId",
                table: "Calendars",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_RouteId",
                table: "Contacts",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_RunId",
                table: "Contacts",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TicketId",
                table: "Contacts",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RouteId",
                table: "Equipment",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_TicketId",
                table: "Equipment",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_UserId",
                table: "Equipment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_TicketId",
                table: "Route",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_UserId",
                table: "Route",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Run_RouteId",
                table: "Run",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Run_TicketId",
                table: "Run",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Run_UserId",
                table: "Run",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_EquipmmentId",
                table: "Service",
                column: "EquipmmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_UserId",
                table: "Service",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_RunId",
                table: "Student",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_TicketId",
                table: "Student",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Run");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropColumn(
                name: "Joined",
                table: "AspNetUsers");
        }
    }
}
