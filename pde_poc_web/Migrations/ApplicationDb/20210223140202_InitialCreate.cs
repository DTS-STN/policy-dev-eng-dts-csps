using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pde_poc_web.Migrations.ApplicationDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumWeeks = table.Column<int>(nullable: false),
                    Percentage = table.Column<double>(nullable: false),
                    MaxWeeklyAmount = table.Column<decimal>(nullable: false),
                    IsBase = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnemploymentRegions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnemploymentRate = table.Column<double>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    BestWeeks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnemploymentRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BaseCaseId = table.Column<Guid>(nullable: false),
                    VariantCaseId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Simulations_Cases_BaseCaseId",
                        column: x => x.BaseCaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Simulations_Cases_VariantCaseId",
                        column: x => x.VariantCaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UnemploymentRegionId = table.Column<Guid>(nullable: false),
                    Flsah = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_UnemploymentRegions_UnemploymentRegionId",
                        column: x => x.UnemploymentRegionId,
                        principalTable: "UnemploymentRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimulationResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SimulationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimulationResults_Simulations_SimulationId",
                        column: x => x.SimulationId,
                        principalTable: "Simulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyIncome",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyIncome_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    SimulationResultId = table.Column<Guid>(nullable: false),
                    BaseAmount = table.Column<decimal>(nullable: false),
                    VariantAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonResults_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonResults_SimulationResults_SimulationResultId",
                        column: x => x.SimulationResultId,
                        principalTable: "SimulationResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonResults_PersonId",
                table: "PersonResults",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonResults_SimulationResultId",
                table: "PersonResults",
                column: "SimulationResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UnemploymentRegionId",
                table: "Persons",
                column: "UnemploymentRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SimulationResults_SimulationId",
                table: "SimulationResults",
                column: "SimulationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Simulations_BaseCaseId",
                table: "Simulations",
                column: "BaseCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulations_VariantCaseId",
                table: "Simulations",
                column: "VariantCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyIncome_PersonId",
                table: "WeeklyIncome",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonResults");

            migrationBuilder.DropTable(
                name: "WeeklyIncome");

            migrationBuilder.DropTable(
                name: "SimulationResults");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Simulations");

            migrationBuilder.DropTable(
                name: "UnemploymentRegions");

            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
