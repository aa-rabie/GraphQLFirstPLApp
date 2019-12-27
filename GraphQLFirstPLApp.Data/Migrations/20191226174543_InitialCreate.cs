﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLFirstPLApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    IntroducedAt = table.Column<DateTimeOffset>(nullable: false),
                    PhotoFileName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IntroducedAt", "Name", "PhotoFileName", "Price", "Rating", "Stock", "Type" },
                values: new object[,]
                {
                    { -1, "Use these sturdy shoes to pass any mountain range with ease.", new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 780, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, 2, 0, 0, 0)), "Mountain Walkers", "shutterstock_66842440.jpg", 219.5m, 4, 12, 0 },
                    { -2, "For your everyday marches in the army.", new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2407), new TimeSpan(0, 2, 0, 0, 0)), "Army Slippers", "shutterstock_222721876.jpg", 125.9m, 3, 56, 0 },
                    { -3, "This backpack can survive any tornado.", new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2469), new TimeSpan(0, 2, 0, 0, 0)), "Backpack Deluxe", "shutterstock_6170527.jpg", 199.99m, 5, 66, 1 },
                    { -4, "Anything you need to climb the mount Everest.", new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 2, 0, 0, 0)), "Climbing Kit", "shutterstock_48040747.jpg", 299.5m, 5, 3, 1 },
                    { -5, "Simply the fastest kayak on earth and beyond for 2 persons.", new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2512), new TimeSpan(0, 2, 0, 0, 0)), "Blue Racer", "shutterstock_441989509.jpg", 350m, 5, 8, 2 },
                    { -6, "One person kayak with hyper boost button.", new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 2, 0, 0, 0)), "Orange Demon", "shutterstock_495259978.jpg", 450m, 2, 1, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
