using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoultryVersion.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roles = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUser_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblPoultryFarm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NoOfHens = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPoultryFarm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPoultryFarm_tblUser",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblDisease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EffectiveNumber = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NoOfDead = table.Column<int>(type: "int", nullable: true),
                    PoultryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDisease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDisease_tblPoultryFarm",
                        column: x => x.PoultryId,
                        principalTable: "tblPoultryFarm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblProduction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EggType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    PoultryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProduction_tblPoultryFarm",
                        column: x => x.PoultryId,
                        principalTable: "tblPoultryFarm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblVaccine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PoultryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVaccine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblVaccine_tblPoultryFarm",
                        column: x => x.PoultryId,
                        principalTable: "tblPoultryFarm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblTreatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Medicine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DiseaseId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTreatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTreatment_tblDisease",
                        column: x => x.DiseaseId,
                        principalTable: "tblDisease",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDisease_PoultryId",
                table: "tblDisease",
                column: "PoultryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPoultryFarm_UserId",
                table: "tblPoultryFarm",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduction_PoultryId",
                table: "tblProduction",
                column: "PoultryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTreatment_DiseaseId",
                table: "tblTreatment",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_RoleId",
                table: "tblUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVaccine_PoultryId",
                table: "tblVaccine",
                column: "PoultryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProduction");

            migrationBuilder.DropTable(
                name: "tblTreatment");

            migrationBuilder.DropTable(
                name: "tblVaccine");

            migrationBuilder.DropTable(
                name: "tblDisease");

            migrationBuilder.DropTable(
                name: "tblPoultryFarm");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
