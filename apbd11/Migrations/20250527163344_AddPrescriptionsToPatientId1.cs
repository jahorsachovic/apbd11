using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbd11.Migrations
{
    /// <inheritdoc />
    public partial class AddPrescriptionsToPatientId1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 4, new DateTime(2015, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { new DateTime(2015, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });
        }
    }
}
