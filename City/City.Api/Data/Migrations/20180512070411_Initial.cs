using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace City.Api.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    TownId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sights_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("213b70c1-24f8-4279-b36c-cbfd732f9f3b"), "The one with that big park.", "New York City" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("f9598a2e-2b3a-4dda-b7d9-c103144f510f"), "The one with the cathedral that was never really finished.", "Antwerp" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("404659b6-39d1-49be-bf29-c7df4501d7ee"), "The one with that big tower.", "Paris" });

            migrationBuilder.InsertData(
                table: "Sights",
                columns: new[] { "Id", "Description", "Name", "TownId" },
                values: new object[,]
                {
                    { new Guid("e6a4ed1d-a17c-4bd8-994f-c6679157e464"), "The most visited urban park in the world!", "Central Park", new Guid("213b70c1-24f8-4279-b36c-cbfd732f9f3b") },
                    { new Guid("0691f43f-5388-4b68-a946-f2f9816c868c"), "A 102-story skyscrapper located in Midtown Manhatan.", "Empire State Building", new Guid("213b70c1-24f8-4279-b36c-cbfd732f9f3b") },
                    { new Guid("dca44c14-9615-407e-8f98-ab0e9b24bda6"), "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.", "Cathedral of Our Lady", new Guid("f9598a2e-2b3a-4dda-b7d9-c103144f510f") },
                    { new Guid("a9c30a4a-30c0-458e-871e-8ee1741b54f2"), "The finest example of railway architecture in Belgium.", "Antwerp Central Station", new Guid("f9598a2e-2b3a-4dda-b7d9-c103144f510f") },
                    { new Guid("787ec76e-f3d0-4aa3-84e0-d8b13b844286"), "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel.", "Eiffel Tower", new Guid("404659b6-39d1-49be-bf29-c7df4501d7ee") },
                    { new Guid("e35de2a6-9e7f-4567-a84a-49239d9680ef"), "The world's largest museum.", "The Louvra", new Guid("404659b6-39d1-49be-bf29-c7df4501d7ee") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sights_TownId",
                table: "Sights",
                column: "TownId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sights");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
