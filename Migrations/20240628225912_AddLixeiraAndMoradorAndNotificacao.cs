using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Residuos.Migrations
{
    /// <inheritdoc />
    public partial class AddLixeiraAndMoradorAndNotificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_LIXEIRA",
                columns: table => new
                {
                    LixeiraId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    capacidadeFull = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LIXEIRA", x => x.LixeiraId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_NOTIFICACAO",
                columns: table => new
                {
                    NotificacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NotificacaoDescricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DataNotificacao = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_NOTIFICACAO", x => x.NotificacaoId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MORADOR",
                columns: table => new
                {
                    MoradorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MoradorName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdLixeira = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MORADOR", x => x.MoradorId);
                    table.ForeignKey(
                        name: "FK_TBL_MORADOR_TBL_LIXEIRA_IdLixeira",
                        column: x => x.IdLixeira,
                        principalTable: "TBL_LIXEIRA",
                        principalColumn: "LixeiraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_MORADOR_IdLixeira",
                table: "TBL_MORADOR",
                column: "IdLixeira");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_MORADOR");

            migrationBuilder.DropTable(
                name: "TBL_NOTIFICACAO");

            migrationBuilder.DropTable(
                name: "TBL_LIXEIRA");
        }
    }
}
