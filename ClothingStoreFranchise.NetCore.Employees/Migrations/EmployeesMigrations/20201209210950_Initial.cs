using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothingStoreFranchise.NetCore.Employees.Migrations.EmployeesMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empoyees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    SSecurityNumber = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ShopId = table.Column<long>(nullable: true),
                    WarehouseId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empoyees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empoyees_Buildings_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empoyees_Buildings_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empoyees_ShopId",
                table: "Empoyees",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Empoyees_WarehouseId",
                table: "Empoyees",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empoyees");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
