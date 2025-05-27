using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd11.Migrations
{
    /// <inheritdoc />
    public partial class AddPrescriptionTableRenameFkFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientIdPatient",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "PatientIdPatient",
                table: "Prescriptions",
                newName: "IdPatient1");

            migrationBuilder.RenameColumn(
                name: "DoctorIdDoctor",
                table: "Prescriptions",
                newName: "IdDoctor1");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_PatientIdPatient",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdPatient1");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_DoctorIdDoctor",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "PatientIdPatient");

            migrationBuilder.RenameColumn(
                name: "IdDoctor1",
                table: "Prescriptions",
                newName: "DoctorIdDoctor");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_IdPatient1",
                table: "Prescriptions",
                newName: "IX_Prescriptions_PatientIdPatient");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_IdDoctor1",
                table: "Prescriptions",
                newName: "IX_Prescriptions_DoctorIdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                table: "Prescriptions",
                column: "DoctorIdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientIdPatient",
                table: "Prescriptions",
                column: "PatientIdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
