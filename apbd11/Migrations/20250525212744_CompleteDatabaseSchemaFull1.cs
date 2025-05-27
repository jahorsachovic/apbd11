using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd11.Migrations
{
    /// <inheritdoc />
    public partial class CompleteDatabaseSchemaFull1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicament_Medicaments_IdMedicament",
                table: "PrescriptionMedicament");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicament_Prescriptions_IdPrescription",
                table: "PrescriptionMedicament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionMedicament",
                table: "PrescriptionMedicament");

            migrationBuilder.RenameTable(
                name: "PrescriptionMedicament",
                newName: "PrescriptionsMedicaments");

            migrationBuilder.RenameIndex(
                name: "IX_PrescriptionMedicament_IdPrescription",
                table: "PrescriptionsMedicaments",
                newName: "IX_PrescriptionsMedicaments_IdPrescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionsMedicaments",
                table: "PrescriptionsMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionsMedicaments_Medicaments_IdMedicament",
                table: "PrescriptionsMedicaments",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionsMedicaments_Prescriptions_IdPrescription",
                table: "PrescriptionsMedicaments",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionsMedicaments_Medicaments_IdMedicament",
                table: "PrescriptionsMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionsMedicaments_Prescriptions_IdPrescription",
                table: "PrescriptionsMedicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionsMedicaments",
                table: "PrescriptionsMedicaments");

            migrationBuilder.RenameTable(
                name: "PrescriptionsMedicaments",
                newName: "PrescriptionMedicament");

            migrationBuilder.RenameIndex(
                name: "IX_PrescriptionsMedicaments_IdPrescription",
                table: "PrescriptionMedicament",
                newName: "IX_PrescriptionMedicament_IdPrescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionMedicament",
                table: "PrescriptionMedicament",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicament_Medicaments_IdMedicament",
                table: "PrescriptionMedicament",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicament_Prescriptions_IdPrescription",
                table: "PrescriptionMedicament",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
