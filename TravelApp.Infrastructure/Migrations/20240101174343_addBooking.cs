using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Infrastructure.Migrations
{
    public partial class addBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "DateBooked", "HolidayId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 17, 43, 43, 272, DateTimeKind.Local).AddTicks(3768), 1, new Guid("0b1ca85c-6d66-4a76-b583-7723302e8542") },
                    { 2, new DateTime(2024, 1, 1, 17, 43, 43, 272, DateTimeKind.Local).AddTicks(3837), 2, new Guid("c5766467-afbf-4e85-930c-871a2169959c") },
                    { 3, new DateTime(2024, 1, 1, 17, 43, 43, 272, DateTimeKind.Local).AddTicks(3842), 3, new Guid("c6649427-b81a-4dd3-8793-d1a7d3f1424d") },
                    { 4, new DateTime(2024, 1, 1, 17, 43, 43, 272, DateTimeKind.Local).AddTicks(3846), 4, new Guid("a04c6d0d-9e0f-4fa2-a7f6-4d61cf154c37") },
                    { 5, new DateTime(2024, 1, 1, 17, 43, 43, 272, DateTimeKind.Local).AddTicks(3948), 5, new Guid("9f17e229-a27e-4d05-beee-a2882cd42e18") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "HolidayAmenities");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
