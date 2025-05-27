using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbd11.Migrations
{
    /// <inheritdoc />
    public partial class CompleteDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor1",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient1",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "IdPatient1",
                table: "Prescriptions",
                newName: "IdPatient");

            migrationBuilder.RenameColumn(
                name: "IdDoctor1",
                table: "Prescriptions",
                newName: "IdDoctor");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_IdPatient1",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdPatient");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_IdDoctor1",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdDoctor");

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicament", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicament_Medicaments_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicament_Prescriptions_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "john.doe@fake.com", "John", "Doe" },
                    { 2, "jane.doe@fake.com", "Jane", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "It's Cope", "Cope", "Inhaler" },
                    { 2, "It's Music", "Music", "Injection" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "K", "N" },
                    { 2, new DateTime(1987, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gon", "Freecss" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2018, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicament_IdPrescription",
                table: "PrescriptionMedicament",
                column: "IdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient",
                table: "Prescriptions",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "PrescriptionMedicament");

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "IdPatient",
                table: "Prescriptions",
                newName: "IdPatient1");

            migrationBuilder.RenameColumn(
                name: "IdDoctor",
                table: "Prescriptions",
                newName: "IdDoctor1");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdPatient1");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdDoctor1");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor1",
                table: "Prescriptions",
                column: "IdDoctor1",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient1",
                table: "Prescriptions",
                column: "IdPatient1",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
