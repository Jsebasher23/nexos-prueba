using Microsoft.EntityFrameworkCore.Migrations;

namespace nexos_test.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaDate = table.Column<string>(nullable: true),
                    CitaPacienteID = table.Column<string>(nullable: true),
                    CitaDoctorID = table.Column<int>(nullable: false),
                    CitaTOTAL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaID);
                    table.ForeignKey(
                            name: "FK_CitaPacienteID",
                            column: x => x.CitaPacienteID,
                            principalTable: "Pacientes",
                            principalColumn: "PacienteID",
                            onDelete: ReferentialAction.Cascade
                        ); 
                    table.ForeignKey(
                            name: "FK_CitaDoctorID",
                            column: x => x.CitaDoctorID,
                            principalTable: "Doctores",
                            principalColumn: "DoctorID",
                            onDelete: ReferentialAction.Cascade
                        );
                });

            migrationBuilder.CreateTable(
                name: "Doctores",
                columns: table => new
                {
                    DoctorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorNumCred = table.Column<int>(nullable: false),
                    DoctorHopital = table.Column<string>(nullable: true),
                    DoctorNombre = table.Column<string>(nullable: true),
                    DoctorApellido = table.Column<string>(nullable: true),
                    DoctorEspecialidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctores", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteNombres = table.Column<string>(nullable: true),
                    PacienteApellidos = table.Column<string>(nullable: true),
                    PacienteSegSocial = table.Column<int>(nullable: false),
                    PacienteCodPostal = table.Column<string>(nullable: true),
                    PacienteTel = table.Column<string>(nullable: true),
                    PacienteEdad = table.Column<string>(nullable: true),
                    PacienteEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Doctores");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
