using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLFirstPLApp.Data.Migrations
{
    public partial class Reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "ProductId", "Review", "Title" },
                values: new object[,]
                {
                    { -1, -2, "First released almost 30 years ago, the Titan 26078 is a classic work boot. It’s also one of Timberland’s all time best sellers.", "Crossed the Himalayas" },
                    { -2, -2, "One of the most comfortable hiking boots available, each pair comes complete with the Power Fit Comfort System, designed to offer maximum support at key areas of your feet.", "Comfortable" },
                    { -3, -3, "The Better Backpack is made from 100% recycled plastic but looks and feels like canvas. We were sent the grey bag with the tan leather accents and silver zippers. I’ve personally always liked tan leather paired with the color grey and appreciate the feel of the leather pull tabs and handles at the top of the bag. Additionally the inside is navy blue with a diagonal stitch pattern which gives it an air of sophistication.", "Feels like canvas" },
                    { -4, -5, @"So this is my 1st ever kayak and my 1st experience paddling a kayak. I struggled with whether I should spend more money to buy a ""Fishing"" kayak, or even a ""higher end"" kayak because my fear was paddling around a bathtub on the lake. I have to say, I love this kayak for me. It doesn't have a lot of the bells and whistles that some of the pricier kayaks have but, I'm not disappointed.

                It's pretty bare bones aside from some dry storage areas and some bungees. It does have a bungee to hold your paddle on the side. I feel it paddles very easy. It goes exactly where I want it to, I didn't struggle to keep it on course. A stiff wind can knock you off track but it was very sturdy and I feel like it would take a lot to tip it over. I stayed fairly dry aside from the dripping off the paddle but its a sit on top so thats to be expected.", "So this is my 1st ever..." },
                    { -5, -5, "I am a fit 5'7 woman 140lbs and I take my 30# dog along with no troubles. I have fished with it by using a bucket strapped in the back with my bungee cords. It holds my rods and small tackle tray, bug spray etc so I can get to it all easily. I can even get it up on the roof of my jeep alone. ", "Great for all genders" },
                    { -6, -5, "Very happy with my purchase and I recommend this to anyone who doesn't want to spend over 600$ on a kayak but also doesn't want a cheap ole hunk of plastic. ", "Happy" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -6,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 20, 34, 47, 680, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -5,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 20, 34, 47, 680, DateTimeKind.Unspecified).AddTicks(1702), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 20, 34, 47, 680, DateTimeKind.Unspecified).AddTicks(1682), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 20, 34, 47, 680, DateTimeKind.Unspecified).AddTicks(1676), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 20, 34, 47, 680, DateTimeKind.Unspecified).AddTicks(1641), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 20, 34, 47, 677, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -6,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -5,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2512), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -4,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2479), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2469), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 785, DateTimeKind.Unspecified).AddTicks(2407), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                column: "IntroducedAt",
                value: new DateTimeOffset(new DateTime(2019, 11, 26, 19, 45, 42, 780, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
