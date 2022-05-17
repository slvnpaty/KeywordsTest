using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeywordsTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartamentByCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentByCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_List_ListId",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamByCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamByCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamByCard_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DepartamentByCard",
                columns: new[] { "Id", "CardId", "DepartmentId" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CardId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Financeiro" },
                    { 2, null, "UX" },
                    { 3, null, "UI" },
                    { 4, null, "Desenvolvimento" }
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Outros" },
                    { 4, "Finalizado" },
                    { 1, "Aguardando" },
                    { 2, "Em Andamento" },
                    { 3, "Pendência" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Company" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Abbreviation", "CardId", "Name" },
                values: new object[,]
                {
                    { 3, "ASP", null, "Active Server Pages" },
                    { 1, "TF", null, "Financial Team" },
                    { 2, "PHP", null, "Hypertext Preprocessor" },
                    { 4, "WD", null, "Web designer" }
                });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "Date", "Description", "ListId", "Name", "Position", "ProjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 17, 9, 18, 41, 503, DateTimeKind.Local).AddTicks(5618), "Usar a branch Master,fazer pull, após isso...", 1, "Criar Migration", 1, 1 },
                    { 2, new DateTime(2022, 5, 17, 9, 18, 41, 504, DateTimeKind.Local).AddTicks(9430), "Colunas utilizadas: Código, Nome, Descrição", 1, "Listagem Clientes", 2, 1 },
                    { 3, new DateTime(2022, 5, 17, 9, 18, 41, 504, DateTimeKind.Local).AddTicks(9453), "Selecionar notas fiscais, Lançar no ERP", 1, "Lançar Notas", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "TeamByCard",
                columns: new[] { "Id", "CardId", "TeamId" },
                values: new object[,]
                {
                    { 5, 3, 1 },
                    { 1, 1, 2 },
                    { 4, 2, 2 },
                    { 2, 1, 3 },
                    { 3, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_ListId",
                table: "Card",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_ProjectId",
                table: "Card",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_CardId",
                table: "Department",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamByCard_TeamId",
                table: "TeamByCard",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CardId",
                table: "Teams",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentByCard");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "TeamByCard");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
