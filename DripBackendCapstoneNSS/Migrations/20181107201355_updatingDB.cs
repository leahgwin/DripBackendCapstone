using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DripBackendCapstoneNSS.Migrations
{
    public partial class updatingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "388c803e-2dd9-4188-8a59-a89455022e8b", "f59976cd-70c9-4f58-bd07-bba909676d51" });

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Neighborhood", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "12651ded-f517-4f9d-9489-ed0ef15bed07", 0, "ca7c848b-87a1-4a57-a379-07bf4d9e6885", "admin@admin.com", true, false, null, "Camps Bay", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEGj9d4Hjl4sE3wC5HDqp35g4C8rGzz5Dpp4qcxdvcBUJATjXeNpkmdSH2zs91AzZ1A==", null, false, "3bf5249f-c8ff-48e8-bb01-f155e2a92236", false, 0, "admin" });

            migrationBuilder.UpdateData(
                table: "UserActivity",
                keyColumn: "UserActivityId",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2018, 11, 7, 14, 13, 53, 30, DateTimeKind.Local), "12651ded-f517-4f9d-9489-ed0ef15bed07" });

            migrationBuilder.UpdateData(
                table: "UserActivity",
                keyColumn: "UserActivityId",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2018, 11, 7, 14, 13, 53, 33, DateTimeKind.Local), "12651ded-f517-4f9d-9489-ed0ef15bed07" });

            migrationBuilder.UpdateData(
                table: "UserActivity",
                keyColumn: "UserActivityId",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2018, 11, 7, 14, 13, 53, 33, DateTimeKind.Local), "12651ded-f517-4f9d-9489-ed0ef15bed07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "12651ded-f517-4f9d-9489-ed0ef15bed07", "ca7c848b-87a1-4a57-a379-07bf4d9e6885" });

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Neighborhood", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "388c803e-2dd9-4188-8a59-a89455022e8b", 0, "f59976cd-70c9-4f58-bd07-bba909676d51", "admin@admin.com", true, false, null, "Camps Bay", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEDvkeVBVI6g6CE+x0KkHm8M+AxusP0eDbyXh7lJ59B3rMR1VFCM3T4oeS4APHRa9uw==", null, false, "e6d4c6f5-1843-445a-b518-953078cbbedc", false, 0, "admin" });

            migrationBuilder.UpdateData(
                table: "UserActivity",
                keyColumn: "UserActivityId",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2018, 11, 5, 14, 50, 1, 826, DateTimeKind.Local), "388c803e-2dd9-4188-8a59-a89455022e8b" });

            migrationBuilder.UpdateData(
                table: "UserActivity",
                keyColumn: "UserActivityId",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2018, 11, 5, 14, 50, 1, 835, DateTimeKind.Local), "388c803e-2dd9-4188-8a59-a89455022e8b" });

            migrationBuilder.UpdateData(
                table: "UserActivity",
                keyColumn: "UserActivityId",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2018, 11, 5, 14, 50, 1, 835, DateTimeKind.Local), "388c803e-2dd9-4188-8a59-a89455022e8b" });
        }
    }
}
