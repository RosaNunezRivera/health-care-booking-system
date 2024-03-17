using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEntities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoctorEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoctorSpecialization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    AvailabilityTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.AvailabilityId);
                    table.ForeignKey(
                        name: "FK_Availabilities_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingPatientID = table.Column<int>(type: "int", nullable: false),
                    BookingDoctorID = table.Column<int>(type: "int", nullable: false),
                    BookingAvailabilityId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Availabilities_BookingAvailabilityId",
                        column: x => x.BookingAvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "AvailabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Doctors_BookingDoctorID",
                        column: x => x.BookingDoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID");
                    table.ForeignKey(
                        name: "FK_Bookings_Patients_BookingPatientID",
                        column: x => x.BookingPatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_DoctorID",
                table: "Availabilities",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingAvailabilityId",
                table: "Bookings",
                column: "BookingAvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingDoctorID",
                table: "Bookings",
                column: "BookingDoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingPatientID",
                table: "Bookings",
                column: "BookingPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DoctorID",
                table: "Bookings",
                column: "DoctorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
