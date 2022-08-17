using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clMortgageDAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HuseNo = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PinNo = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanModels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Source = table.Column<int>(type: "INTEGER", nullable: true),
                    LoanPurpose = table.Column<int>(type: "INTEGER", nullable: true),
                    SalariedRecived = table.Column<int>(type: "INTEGER", nullable: true),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: true),
                    WorkingCompany = table.Column<string>(type: "TEXT", nullable: true),
                    GrossSalary = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedON = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedON = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PropertyLocationid = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanModels", x => x.id);
                    table.ForeignKey(
                        name: "FK_LoanModels_Locations_PropertyLocationid",
                        column: x => x.PropertyLocationid,
                        principalTable: "Locations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_LoanModels_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanModels_User_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanModels_CreatedById",
                table: "LoanModels",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoanModels_ModifiedById",
                table: "LoanModels",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoanModels_PropertyLocationid",
                table: "LoanModels",
                column: "PropertyLocationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanModels");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
