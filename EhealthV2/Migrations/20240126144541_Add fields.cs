using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EhealthV2.Migrations
{
    /// <inheritdoc />
    public partial class Addfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "SuperId",
                keyColumnType: "INTEGER",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "SuperId",
                keyColumnType: "INTEGER",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SuperId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "superDoc",
                table: "Doctors",
                newName: "Speciality");

            migrationBuilder.AlterColumn<int>(
                name: "DocId",
                table: "Doctors",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Inami",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Organisation",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "DocId");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DocId", "Address", "City", "Email", "FirstName", "Inami", "LastName", "Organisation", "PostCode", "Speciality" },
                values: new object[,]
                {
                    { 1, "Rue de la fusée", "Bruxelles", "lody@hotmail.com", "LoDY", "12345678910", "La fusée", "Sans", "1000", "Cardiologue" },
                    { 2, "Rue de la tortilla", "Bruxelles", "toto@gmail.com", "Toto", "12345678911", "La Grippe", "Sans", "1050", "Généraliste" },
                    { 3, "Rue Bara", "Bruxelles", "muharen@hotmail.com", "Muharem", "12345678912", "Le Hacker", "Sans", "1000", "kinésithérapie" },
                    { 4, "Rue Lente", "Laeken", "jp@hotmail.com", "JP", "12345678913", "La Tortue", "Sans", "1020", "Dentiste" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DocId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Inami",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Organisation",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Speciality",
                table: "Doctors",
                newName: "superDoc");

            migrationBuilder.AlterColumn<int>(
                name: "DocId",
                table: "Doctors",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "SuperId",
                table: "Doctors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "SuperId");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "SuperId", "DocId", "Email", "FirstName", "LastName", "superDoc" },
                values: new object[,]
                {
                    { 1, 1, "email lody", "LoDY", "rue de lody", "yes" },
                    { 2, 2, "email lloyd", "Lloyd", "rue de lloyd", "yes" }
                });
        }
    }
}
