using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JMBG = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfBooksRented = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            SeedInitialData(migrationBuilder);
        }

        private void SeedInitialData(MigrationBuilder migrationBuilder)
        {
            var random = new Random();

            var names = new List<string> { "Milos", "Petar", "Marko", "Djordje", "Jovan", "Stanko", "Jelena", "Nevena", "Milica", "Anastasija" };
            var surnames = new List<string> { "Gravara", "Petrovic", "Markovic", "Djordjevic", "Jovanovic", "Stankovic", "Nikolic", "Miskovic", "Milanovic", "Stanic" };

            var users = Enumerable.Range(1, 10).Select(i => new
            {
                Id = Guid.NewGuid(),
                FirstName = names[random.Next(1, 10)],
                LastName = surnames[random.Next(1, 10)],
                JMBG = $"12345{i.ToString().PadLeft(6, '0')}",
                NumberOfBooksRented = 0,
                AddressId = Guid.NewGuid(),
            }).ToArray();

            var addresses = users.Select(u => new
            {
                Id = u.AddressId,
                City = $"City{random.Next(1, 10)}",
                Country = $"Country{random.Next(1, 10)}",
                Street = $"Street{random.Next(1, 100)}",
                Number = random.Next(1, 100).ToString()
            }).ToArray();
            
            foreach (var a in addresses )
            {
                migrationBuilder.InsertData(
                    table: "Addresses",
                    columns: new[] { "Id", "City", "Country", "Street", "Number" },
                    values: new object[] { a.Id, a.City, a.Country, a.Street, a.Number }
                );
            }

            foreach (var u in users)
            {
                migrationBuilder.InsertData(
                   table: "Users",
                   columns: new[] { "Id", "FirstName", "LastName", "JMBG", "NumberOfBooksRented", "AddressId" },
                   values: new object[] { u.Id, u.FirstName, u.LastName, u.JMBG, u.NumberOfBooksRented, u.AddressId }
               );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
