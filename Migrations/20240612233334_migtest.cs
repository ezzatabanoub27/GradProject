using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAppG.Migrations
{
    /// <inheritdoc />
    public partial class migtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BookTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    IsBooked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Car_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Car_Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Driver_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAppointmentIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Driver_Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    FeedBack_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FB_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.FeedBack_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hotel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avilable_single_Rooms = table.Column<int>(type: "int", nullable: true),
                    Avilable_double_Rooms = table.Column<int>(type: "int", nullable: true),
                    Day_Double_Cost = table.Column<double>(type: "float", nullable: true),
                    Day_Single_Cost = table.Column<double>(type: "float", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Photo1URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo2URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photot3Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Has_SwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    Has_SeeView = table.Column<bool>(type: "bit", nullable: false),
                    Has_Free_Wifi = table.Column<bool>(type: "bit", nullable: false),
                    Has_Sports_Gym = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hotel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Job_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripyion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Work_Hourse = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Statue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Job_Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Report_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Report_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Report_Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingHotel",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHotel", x => new { x.BookingsId, x.Hotel_Id });
                    table.ForeignKey(
                        name: "FK_BookingHotel_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingHotel_Hotels_Hotel_Id",
                        column: x => x.Hotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTrips",
                columns: table => new
                {
                    SpecialTrip_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTrips", x => x.SpecialTrip_Id);
                    table.ForeignKey(
                        name: "FK_SpecialTrips_Hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id");
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Trip_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Trip_Id);
                    table.ForeignKey(
                        name: "FK_Trips_Hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingSpecialTrip",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    SpecialTripsSpecialTrip_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSpecialTrip", x => new { x.BookingsId, x.SpecialTripsSpecialTrip_Id });
                    table.ForeignKey(
                        name: "FK_BookingSpecialTrip_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSpecialTrip_SpecialTrips_SpecialTripsSpecialTrip_Id",
                        column: x => x.SpecialTripsSpecialTrip_Id,
                        principalTable: "SpecialTrips",
                        principalColumn: "SpecialTrip_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Government = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jobId = table.Column<int>(type: "int", nullable: false),
                    specialtripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_Users_Jobs_jobId",
                        column: x => x.jobId,
                        principalTable: "Jobs",
                        principalColumn: "Job_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_SpecialTrips_specialtripId",
                        column: x => x.specialtripId,
                        principalTable: "SpecialTrips",
                        principalColumn: "SpecialTrip_Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingTrip",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    Trip_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTrip", x => new { x.BookingsId, x.Trip_Id });
                    table.ForeignKey(
                        name: "FK_BookingTrip_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTrip_Trips_Trip_Id",
                        column: x => x.Trip_Id,
                        principalTable: "Trips",
                        principalColumn: "Trip_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDriverTrips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carId = table.Column<int>(type: "int", nullable: false),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    tripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDriverTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDriverTrips_Cars_carId",
                        column: x => x.carId,
                        principalTable: "Cars",
                        principalColumn: "Car_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarDriverTrips_Drivers_driverId",
                        column: x => x.driverId,
                        principalTable: "Drivers",
                        principalColumn: "Driver_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarDriverTrips_Trips_tripId",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "Trip_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourGuids",
                columns: table => new
                {
                    TourGuid_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    tripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuids", x => x.TourGuid_Id);
                    table.ForeignKey(
                        name: "FK_TourGuids_Trips_tripId",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "Trip_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tripId = table.Column<int>(type: "int", nullable: false),
                    feedbackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripFeedbacks_FeedBacks_feedbackId",
                        column: x => x.feedbackId,
                        principalTable: "FeedBacks",
                        principalColumn: "FeedBack_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripFeedbacks_Trips_tripId",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "Trip_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    feedBackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedBacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFeedBacks_FeedBacks_feedBackId",
                        column: x => x.feedBackId,
                        principalTable: "FeedBacks",
                        principalColumn: "FeedBack_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFeedBacks_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    reportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReports_Reports_reportId",
                        column: x => x.reportId,
                        principalTable: "Reports",
                        principalColumn: "Report_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReports_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTrips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    tripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrips_Trips_tripId",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "Trip_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTrips_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotel_Hotel_Id",
                table: "BookingHotel",
                column: "Hotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSpecialTrip_SpecialTripsSpecialTrip_Id",
                table: "BookingSpecialTrip",
                column: "SpecialTripsSpecialTrip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTrip_Trip_Id",
                table: "BookingTrip",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarDriverTrips_carId",
                table: "CarDriverTrips",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDriverTrips_driverId",
                table: "CarDriverTrips",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDriverTrips_tripId",
                table: "CarDriverTrips",
                column: "tripId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTrips_hotelId",
                table: "SpecialTrips",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuids_tripId",
                table: "TourGuids",
                column: "tripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripFeedbacks_feedbackId",
                table: "TripFeedbacks",
                column: "feedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_TripFeedbacks_tripId",
                table: "TripFeedbacks",
                column: "tripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_hotelId",
                table: "Trips",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedBacks_feedBackId",
                table: "UserFeedBacks",
                column: "feedBackId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedBacks_userId",
                table: "UserFeedBacks",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_reportId",
                table: "UserReports",
                column: "reportId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_userId",
                table: "UserReports",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_jobId",
                table: "Users",
                column: "jobId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_specialtripId",
                table: "Users",
                column: "specialtripId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrips_tripId",
                table: "UserTrips",
                column: "tripId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrips_userId",
                table: "UserTrips",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingHotel");

            migrationBuilder.DropTable(
                name: "BookingSpecialTrip");

            migrationBuilder.DropTable(
                name: "BookingTrip");

            migrationBuilder.DropTable(
                name: "CarDriverTrips");

            migrationBuilder.DropTable(
                name: "TourGuids");

            migrationBuilder.DropTable(
                name: "TripFeedbacks");

            migrationBuilder.DropTable(
                name: "UserFeedBacks");

            migrationBuilder.DropTable(
                name: "UserReports");

            migrationBuilder.DropTable(
                name: "UserTrips");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "SpecialTrips");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
