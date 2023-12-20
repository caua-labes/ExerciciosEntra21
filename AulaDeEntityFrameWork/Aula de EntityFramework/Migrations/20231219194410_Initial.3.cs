using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula_de_EntityFramework.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Compromisso",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Compromisso",
                newName: "Nome");
        }
    }
}
