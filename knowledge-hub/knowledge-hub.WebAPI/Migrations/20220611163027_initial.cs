﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace knowledge_hub.WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePhysical = table.Column<double>(type: "float", nullable: false),
                    PriceDigital = table.Column<double>(type: "float", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardInfoId);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Whishlist",
                columns: table => new
                {
                    BookUserWishlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whishlist", x => x.BookUserWishlistId);
                    table.ForeignKey(
                        name: "FK_Whishlist_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Whishlist_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CardInfoId = table.Column<int>(type: "int", nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Cards_CardInfoId",
                        column: x => x.CardInfoId,
                        principalTable: "Cards",
                        principalColumn: "CardInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Art & Photography" },
                    { 2, "Biography" },
                    { 3, "Children's Books" },
                    { 4, "Crafts & Hobbies" },
                    { 5, "Crime & Thriller" },
                    { 6, "Fantasy" },
                    { 7, "Ficition" },
                    { 8, "Food & Drinks" },
                    { 9, "Graphics Novels" },
                    { 10, "History" },
                    { 11, "Horror" },
                    { 12, "Manga" },
                    { 13, "Mind, Body & Spirit" },
                    { 14, "Science Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Deutsch" },
                    { 3, "Español" },
                    { 4, "Français" },
                    { 5, "官話/官话 " },
                    { 6, "日本語 " }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Delivery" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CategoryId", "Description", "ImagePath", "LanguageId", "Name", "PriceDigital", "PricePhysical", "Score" },
                values: new object[,]
                {
                    { 1, "J. R. R. Tolkien", 6, "Continuing the story begun in The Hobbit, this is the first part of Tolkien's epic masterpiece, The Lord of the Rings, featuring a striking black cover based on Tolkien's own design, the definitive text, and a detailed map of Middle-earth. Sauron, the Dark Lord, has gathered to him all the Rings of Power - the means by which he intends to rule Middle-earth. All he lacks in his plans for dominion is the One Ring - the ring that rules them all - which has fallen into the hands of the hobbit, Bilbo Baggins. In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as his elderly cousin Bilbo entrusts the Ring to his care. Frodo must leave his home and make a perilous journey across Middle-earth to the Cracks of Doom, there to destroy the Ring and foil the Dark Lord in his evil purpose. Now published again in B format, J.R.R. Tolkien's great work of imaginative fiction has been labelled both a heroic romance and a classic fantasy fiction. By turns comic and homely, epic and diabolic, the narrative moves through countless changes of scene and character in an imaginary world which is totally convincing in its detail.", "", 1, "The Fellowship of the Ring : The Lord of the Rings, Part 1", 8.9900000000000002, 14.5, 4.3799999999999999 },
                    { 2, "J. R. R. Tolkien", 6, "Building on the story begun in The Hobbit, this is the second part of Tolkien's epic masterpiece, The Lord of the Rings, featuring a striking black cover based on Tolkien's own design, the definitive text, and a detailed map of Middle-earth.", "", 1, "The Two Towers", 7.9900000000000002, 13.5, 4.46 },
                    { 3, "J. R. R. Tolkien", 6, "Concluding the story begun in The Hobbit, this is the final part of Tolkien's epic masterpiece, The Lord of the Rings. Featuring a striking black cover based on Tolkien's own design, the definitive text, and a detailed map of Middle-earth.", "", 1, "The Return of the King", 7.9900000000000002, 14.5, 4.5499999999999998 },
                    { 4, "J. R. R. Tolkien", 6, "Bilbo Baggins is a hobbit who enjoys a comfortable, unambitious life, rarely travelling further than the pantry of his hobbit-hole in Bag End. But his contentment is disturbed when the wizard, Gandalf, and a company of thirteen dwarves arrive on his doorstep one day to whisk him away on an unexpected journey 'there and back again'. They have a plot to raid the treasure hoard of Smaug the Magnificent, a large and very dangerous dragon...", "", 1, "The Hobbit", 6.9900000000000002, 11.5, 4.2800000000000002 },
                    { 5, " Hajime Isayama ", 12, "Several hundred years ago, humans were nearly exterminated by giants. Giants are typically several stories tall, seem to have no intelligence and who devour human beings. A small percentage of humanity survied barricading themselves in a city protected by walls even taller than the biggest of giants. Flash forward to the present and the city has not seen a giant in over 100 years - before teenager Eren and his foster sister Mikasa witness something horrific as the city walls are destroyed by a super-giant that appears from nowhere.", "", 1, "Attack On Titan 1", 5.9900000000000002, 12.0, 4.4699999999999998 },
                    { 6, "Chip Zdarsky, Mark Bagley", 9, "In 1962's Amazing Fantasy #15, fifteen-year-old Peter Parker was bitten by a radioactive spider and became the Amazing Spider-Man! 57 years have passed in the real world since that event - so what would have happened if the same amount of time passed for Peter as well? To celebrate Marvel's 80th anniversary, Chip Zdarsky and Spider-Man legend Mark Bagley unite to spin a unique Spidey tale - telling an entire history of Spider-Man from beginning to end, set against the key events of the decades through which he lived!", "", 1, "Spider-man: Life Story", 12.99, 24.5, 4.21 },
                    { 7, "Louise Pickford", 8, "Fresh, tasty and bursting with nutritious ingredients and lively aromas, delicious one-bowl, Asian-inspired noodle dishes have never been more popular. Their variety and versatility, speedy cooking time and ability to soak up the bold flavours they're prepared with, make noodle dishes an exotic yet accessible dish and, with The Noodle Bowl, you'll be able to celebrate this wonderful food and feast on the results. ", "", 1, "The Noodle Bowl : Over 70 Recipes for Asian-Inspired Noodle Dishes", 11.99, 21.5, 4.5 },
                    { 8, "Louise Pickford", 8, "These hearty one-pot meals, flavoured with fragrant spices, are cooked and served from an elegant, specially designed cooking vessel, also called a tagine. In Ghillie Basan's collection of deliciously authentic recipes you will find some of the best-loved classics of the Moroccan kitchen.", "", 1, "The Modern Tagine Cookbook : Delicious Recipes for Moroccan One-Pot Meals", 12.6, 23.5, 3.75 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CardInfoId",
                table: "Transactions",
                column: "CardInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderId",
                table: "Transactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Whishlist_BookId",
                table: "Whishlist",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Whishlist_UserId",
                table: "Whishlist",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Whishlist");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
