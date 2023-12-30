using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Infrastructure.Migrations
{
    public partial class seedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Swimming Pool" },
                    { 2, "Gym" },
                    { 3, "Spa" },
                    { 4, "Wi-Fi" },
                    { 5, "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0b1ca85c-6d66-4a76-b583-7723302e8542"), 0, "0e05a81a-2753-4e94-862c-acfbd6a06ec9", "user1@example.com", false, false, null, null, null, null, null, false, null, false, "user1" },
                    { new Guid("9f17e229-a27e-4d05-beee-a2882cd42e18"), 0, "e469b147-31f5-467c-b446-32ceb060d813", "user5@example.com", false, false, null, null, null, null, null, false, null, false, "user5" },
                    { new Guid("a04c6d0d-9e0f-4fa2-a7f6-4d61cf154c37"), 0, "e6ee3d86-649a-4044-8ca1-dbae46fdeea2", "user4@example.com", false, false, null, null, null, null, null, false, null, false, "user4" },
                    { new Guid("c5766467-afbf-4e85-930c-871a2169959c"), 0, "e945f952-8de4-418f-821f-f40a76cb39bb", "user2@example.com", false, false, null, null, null, null, null, false, null, false, "user2" },
                    { new Guid("c6649427-b81a-4dd3-8793-d1a7d3f1424d"), 0, "3cc75993-0944-472b-8177-4faedb5c4bba", "user3@example.com", false, false, null, null, null, null, null, false, null, false, "user3" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beach Vacation" },
                    { 2, "Mountain Retreat" },
                    { 3, "City Tour" },
                    { 4, "Cruise" },
                    { 5, "Safari Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "CategoryId", "Description", "Destination", "ImageUrl" },
                values: new object[,]
                {
                    { 1, 1, "Enjoy the sun and sand", "Maldives Paradise", "https://hips.hearstapps.com/hmg-prod/images/beach-quotes-1559667853.jpg" },
                    { 2, 2, "Escape to the mountains", "Rhodopes Mountain", "https://assets.traveltriangle.com/blog/wp-content/uploads/2018/09/mt.-cook-cover.jpg?tr=w-400" },
                    { 3, 3, "Discover the urban charm", "Rome", "https://hips.hearstapps.com/hmg-prod/images/most-expensive-cities-in-the-world-new-york-city-new-york-1658760364.jpg" },
                    { 4, 4, "Set sail on the open sea", "European Cruise Adventure", "https://static.toiimg.com/thumb/80582831/Cruise.jpg?width=1200&height=900" },
                    { 5, 5, "Explore the wild side", "Kenya Safari Expedition", "https://media.cntraveller.com/photos/611becdb24f18e2bd3cbe71d/16:9/w_2992,h_1683,c_limit/open-vehicle-with-tracker-bushman.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b1ca85c-6d66-4a76-b583-7723302e8542"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9f17e229-a27e-4d05-beee-a2882cd42e18"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a04c6d0d-9e0f-4fa2-a7f6-4d61cf154c37"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c5766467-afbf-4e85-930c-871a2169959c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6649427-b81a-4dd3-8793-d1a7d3f1424d"));

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
