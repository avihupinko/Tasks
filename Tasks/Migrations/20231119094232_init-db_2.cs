using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tasks.Migrations
{
    /// <inheritdoc />
    public partial class initdb_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "IsCompleted", "Subject", "TargetDate", "UserId" },
                values: new object[,]
                {
                    { 1, false, "Task1", new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, true, "Task2", new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, false, "Task3", new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTasks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
