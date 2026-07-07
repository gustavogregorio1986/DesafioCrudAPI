using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioCrudAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionarIdadeDatanascimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Contato",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Contato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Contato");
        }
    }
}
