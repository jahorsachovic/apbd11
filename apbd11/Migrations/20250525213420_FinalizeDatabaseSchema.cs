using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd11.Migrations
{
    /// <inheritdoc />
    public partial class FinalizeDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2015, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2018, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
