using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _130926_Kuharica_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamePredmetNazivToNaziv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PredmetNaziv",
                table: "Predmeti",
                newName: "Naziv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Predmeti",
                newName: "PredmetNaziv");
        }
    }
}
