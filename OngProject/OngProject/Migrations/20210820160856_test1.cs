using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OngProject.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FacebookUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    WelcomeText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AboutUsText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 65535, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 65535, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Content", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Content from activity 1", new DateTime(2021, 8, 20, 13, 8, 55, 384, DateTimeKind.Local).AddTicks(6468), "ImageActivities1.jpg", false, "Activity 1" },
                    { 2, "Content from activity 2", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1182), "ImageActivities2.jpg", false, "Activity 2" },
                    { 3, "Content from activity 3", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1342), "ImageActivities3.jpg", false, "Activity 3" },
                    { 4, "Content from activity 4", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1386), "ImageActivities4.jpg", false, "Activity 4" },
                    { 5, "Content from activity 5", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1426), "ImageActivities5.jpg", false, "Activity 5" },
                    { 6, "Content from activity 6", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1472), "ImageActivities6.jpg", false, "Activity 6" },
                    { 7, "Content from activity 7", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1512), "ImageActivities7.jpg", false, "Activity 7" },
                    { 8, "Content from activity 8", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1550), "ImageActivities8.jpg", false, "Activity 8" },
                    { 9, "Content from activity 9", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1588), "ImageActivities9.jpg", false, "Activity 9" },
                    { 10, "Content from activity 10", new DateTime(2021, 8, 20, 13, 8, 55, 387, DateTimeKind.Local).AddTicks(1648), "ImageActivities10.jpg", false, "Activity 10" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 37, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6227), "Descripcion 37Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories37.jpg", false, "name 37" },
                    { 36, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6179), "Descripcion 36Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories36.jpg", false, "name 36" },
                    { 35, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6055), "Descripcion 35Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories35.jpg", false, "name 35" },
                    { 34, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6016), "Descripcion 34Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories34.jpg", false, "name 34" },
                    { 29, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5823), "Descripcion 29Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories29.jpg", false, "name 29" },
                    { 32, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5937), "Descripcion 32Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories32.jpg", false, "name 32" },
                    { 31, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5899), "Descripcion 31Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories31.jpg", false, "name 31" },
                    { 30, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5861), "Descripcion 30Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories30.jpg", false, "name 30" },
                    { 38, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6266), "Descripcion 38Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories38.jpg", false, "name 38" },
                    { 33, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5975), "Descripcion 33Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories33.jpg", false, "name 33" },
                    { 39, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6304), "Descripcion 39Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories39.jpg", false, "name 39" },
                    { 44, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6495), "Descripcion 44Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories44.jpg", false, "name 44" },
                    { 41, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6380), "Descripcion 41Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories41.jpg", false, "name 41" },
                    { 42, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6419), "Descripcion 42Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories42.jpg", false, "name 42" },
                    { 43, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6457), "Descripcion 43Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories43.jpg", false, "name 43" },
                    { 27, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5681), "Descripcion 27Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories27.jpg", false, "name 27" },
                    { 45, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6533), "Descripcion 45Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories45.jpg", false, "name 45" },
                    { 46, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6621), "Descripcion 46Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories46.jpg", false, "name 46" },
                    { 47, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6662), "Descripcion 47Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories47.jpg", false, "name 47" },
                    { 48, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6702), "Descripcion 48Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories48.jpg", false, "name 48" },
                    { 49, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6741), "Descripcion 49Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories49.jpg", false, "name 49" },
                    { 50, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6780), "Descripcion 50Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories50.jpg", false, "name 50" },
                    { 40, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(6342), "Descripcion 40Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories40.jpg", false, "name 40" },
                    { 26, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5642), "Descripcion 26Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories26.jpg", false, "name 26" },
                    { 28, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5784), "Descripcion 28Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories28.jpg", false, "name 28" },
                    { 24, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5566), "Descripcion 24Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories24.jpg", false, "name 24" },
                    { 1, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4334), "Descripcion 1Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories1.jpg", false, "name 1" },
                    { 2, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4534), "Descripcion 2Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories2.jpg", false, "name 2" },
                    { 3, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4579), "Descripcion 3Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories3.jpg", false, "name 3" },
                    { 4, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4620), "Descripcion 4Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories4.jpg", false, "name 4" },
                    { 5, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4662), "Descripcion 5Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories5.jpg", false, "name 5" },
                    { 25, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5604), "Descripcion 25Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories25.jpg", false, "name 25" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4745), "Descripcion 7Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories7.jpg", false, "name 7" },
                    { 8, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4784), "Descripcion 8Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories8.jpg", false, "name 8" },
                    { 9, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4889), "Descripcion 9Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories9.jpg", false, "name 9" },
                    { 10, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4956), "Descripcion 10Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories10.jpg", false, "name 10" },
                    { 11, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4997), "Descripcion 11Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories11.jpg", false, "name 11" },
                    { 12, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5037), "Descripcion 12Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories12.jpg", false, "name 12" },
                    { 6, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(4705), "Descripcion 6Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories6.jpg", false, "name 6" },
                    { 14, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5115), "Descripcion 14Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories14.jpg", false, "name 14" },
                    { 13, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5076), "Descripcion 13Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories13.jpg", false, "name 13" },
                    { 23, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5525), "Descripcion 23Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories23.jpg", false, "name 23" },
                    { 21, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5446), "Descripcion 21Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories21.jpg", false, "name 21" },
                    { 20, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5407), "Descripcion 20Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories20.jpg", false, "name 20" },
                    { 22, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5485), "Descripcion 22Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories22.jpg", false, "name 22" },
                    { 18, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5323), "Descripcion 18Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories18.jpg", false, "name 18" },
                    { 17, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5231), "Descripcion 17Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories17.jpg", false, "name 17" },
                    { 16, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5193), "Descripcion 16Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories16.jpg", false, "name 16" },
                    { 15, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5154), "Descripcion 15Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories15.jpg", false, "name 15" },
                    { 19, new DateTime(2021, 8, 20, 13, 8, 55, 398, DateTimeKind.Local).AddTicks(5367), "Descripcion 19Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", "imageCategories19.jpg", false, "name 19" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "CreatedAt", "IsDeleted", "User_id", "post_id" },
                values: new object[,]
                {
                    { 22, "body of post_id=8", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4251), false, 8, 8 },
                    { 18, "body of post_id=6", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4105), false, 6, 6 },
                    { 19, "body of post_id=7", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4142), false, 7, 7 },
                    { 20, "body of post_id=7", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4179), false, 7, 7 },
                    { 21, "body of post_id=7", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4215), false, 7, 7 },
                    { 23, "body of post_id=8", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4287), false, 8, 8 },
                    { 29, "body of post_id=10", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4657), false, 10, 10 },
                    { 25, "body of post_id=9", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4464), false, 9, 9 },
                    { 26, "body of post_id=9", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4504), false, 9, 9 },
                    { 27, "body of post_id=9", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4541), false, 9, 9 },
                    { 28, "body of post_id=10", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4606), false, 10, 10 },
                    { 30, "body of post_id=10", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4696), false, 10, 10 },
                    { 17, "body of post_id=6", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4065), false, 6, 6 },
                    { 24, "body of post_id=8", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4372), false, 8, 8 },
                    { 16, "body of post_id=6", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(4029), false, 6, 6 },
                    { 7, "body of post_id=3", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3690), false, 3, 3 },
                    { 14, "body of post_id=5", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3956), false, 5, 5 },
                    { 1, "body of post_id=1", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3179), false, 1, 1 },
                    { 2, "body of post_id=1", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3398), false, 1, 1 },
                    { 3, "body of post_id=1", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3442), false, 1, 1 },
                    { 4, "body of post_id=2", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3481), false, 2, 2 },
                    { 5, "body of post_id=2", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3519), false, 2, 2 },
                    { 6, "body of post_id=2", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3562), false, 2, 2 },
                    { 15, "body of post_id=5", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3992), false, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "CreatedAt", "IsDeleted", "User_id", "post_id" },
                values: new object[,]
                {
                    { 8, "body of post_id=3", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3728), false, 3, 3 },
                    { 9, "body of post_id=3", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3766), false, 3, 3 },
                    { 10, "body of post_id=4", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3807), false, 4, 4 },
                    { 11, "body of post_id=4", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3845), false, 4, 4 },
                    { 12, "body of post_id=4", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3882), false, 4, 4 },
                    { 13, "body of post_id=5", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(3920), false, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Message", "Name", "Phone" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(911), "email10gmail.com", false, "Message Message Message Message10", "Contact 10", 20089999 },
                    { 9, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(746), "email9gmail.com", false, "Message Message Message Message9", "Contact 9", 33724415 },
                    { 8, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(680), "email8gmail.com", false, "Message Message Message Message8", "Contact 8", 30121276 },
                    { 7, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(617), "email7gmail.com", false, "Message Message Message Message7", "Contact 7", 77833794 },
                    { 6, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(553), "email6gmail.com", false, "Message Message Message Message6", "Contact 6", 77263551 },
                    { 5, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(480), "email5gmail.com", false, "Message Message Message Message5", "Contact 5", 60810210 },
                    { 4, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(413), "email4gmail.com", false, "Message Message Message Message4", "Contact 4", 15562153 },
                    { 3, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(347), "email3gmail.com", false, "Message Message Message Message3", "Contact 3", 58154310 },
                    { 2, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(272), "email2gmail.com", false, "Message Message Message Message2", "Contact 2", 86227487 },
                    { 1, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(14), "email1gmail.com", false, "Message Message Message Message1", "Contact 1", 12083941 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedAt", "Description", "FacebookUrl", "Image", "InstagramUrl", "IsDeleted", "LinkedinUrl", "Name" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8800), "Descripcion6Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member6", "imageMembers6.jpg", "https://instagram/member6", false, "https://Linkedin/member6", "name6" },
                    { 9, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8922), "Descripcion9Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member9", "imageMembers9.jpg", "https://instagram/member9", false, "https://Linkedin/member9", "name9" },
                    { 8, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8881), "Descripcion8Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member8", "imageMembers8.jpg", "https://instagram/member8", false, "https://Linkedin/member8", "name8" },
                    { 7, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8841), "Descripcion7Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member7", "imageMembers7.jpg", "https://instagram/member7", false, "https://Linkedin/member7", "name7" },
                    { 10, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(9024), "Descripcion10Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member10", "imageMembers10.jpg", "https://instagram/member10", false, "https://Linkedin/member10", "name10" },
                    { 5, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8752), "Descripcion5Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member5", "imageMembers5.jpg", "https://instagram/member5", false, "https://Linkedin/member5", "name5" },
                    { 3, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8659), "Descripcion3Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member3", "imageMembers3.jpg", "https://instagram/member3", false, "https://Linkedin/member3", "name3" },
                    { 2, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8544), "Descripcion2Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member2", "imageMembers2.jpg", "https://instagram/member2", false, "https://Linkedin/member2", "name2" },
                    { 1, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8336), "Descripcion1Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member1", "imageMembers1.jpg", "https://instagram/member1", false, "https://Linkedin/member1", "name1" },
                    { 4, new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(8710), "Descripcion4Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "https://facebook.com/member4", "imageMembers4.jpg", "https://instagram/member4", false, "https://Linkedin/member4", "name4" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "AboutUsText", "Adress", "CreatedAt", "Email", "FacebookUrl", "Image", "InstagramUrl", "IsDeleted", "LinkedinUrl", "Name", "Phone", "WelcomeText" },
                values: new object[] { 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Catamarca 1585 , CP: 1585", new DateTime(2021, 8, 20, 13, 8, 55, 400, DateTimeKind.Local).AddTicks(2282), "somomasong@gmail.com", "https://facebook.com/organization", "imageOrganization.jpg", null, false, null, "Somos Más", 1128559685, "Bienvenidos a nuestro sitio web" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 20, 13, 8, 55, 388, DateTimeKind.Local).AddTicks(10), "Admin User", false, "Admin" },
                    { 2, new DateTime(2021, 8, 20, 13, 8, 55, 388, DateTimeKind.Local).AddTicks(207), "Standard User", false, "Standard" }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "IsDeleted", "Order", "OrganizationId", "Text" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(8083), "imagenSlides10.jpg", false, 10, "10", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 9, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(8041), "imagenSlides9.jpg", false, 9, "9", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 8, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(8000), "imagenSlides8.jpg", false, 8, "8", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 6, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(7922), "imagenSlides6.jpg", false, 6, "6", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 7, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(7961), "imagenSlides7.jpg", false, 7, "7", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 4, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(7838), "imagenSlides4.jpg", false, 4, "4", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 3, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(7796), "imagenSlides3.jpg", false, 3, "3", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 2, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(7750), "imagenSlides2.jpg", false, 2, "2", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 1, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(7554), "imagenSlides1.jpg", false, 1, "1", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" },
                    { 5, new DateTime(2021, 8, 20, 13, 8, 55, 395, DateTimeKind.Local).AddTicks(7878), "imagenSlides5.jpg", false, 5, "5", "sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium" }
                });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Content", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 9, "Content9Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(483), "imageTestimonials9.jpg", false, "name 9" },
                    { 1, "Content1Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(9899), "imageTestimonials1.jpg", false, "name 1" },
                    { 2, "Content2Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(72), "imageTestimonials2.jpg", false, "name 2" }
                });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Content", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 3, "Content3Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(118), "imageTestimonials3.jpg", false, "name 3" },
                    { 4, "Content4Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(158), "imageTestimonials4.jpg", false, "name 4" },
                    { 5, "Content5Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(197), "imageTestimonials5.jpg", false, "name 5" },
                    { 6, "Content6Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(355), "imageTestimonials6.jpg", false, "name 6" },
                    { 7, "Content7Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(405), "imageTestimonials7.jpg", false, "name 7" },
                    { 8, "Content8Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(444), "imageTestimonials8.jpg", false, "name 8" },
                    { 10, "Content10Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 397, DateTimeKind.Local).AddTicks(525), "imageTestimonials10.jpg", false, "name 10" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "Image", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Content 1 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(3949), "imageNews1.jpg", false, "new's name " },
                    { 10, 10, "Content 10 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4541), "imageNews10.jpg", false, "new's name " },
                    { 9, 9, "Content 9 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4498), "imageNews9.jpg", false, "new's name " },
                    { 7, 7, "Content 7 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4417), "imageNews7.jpg", false, "new's name " },
                    { 6, 6, "Content 6 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4376), "imageNews6.jpg", false, "new's name " },
                    { 5, 5, "Content 5 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4331), "imageNews5.jpg", false, "new's name " },
                    { 4, 4, "Content 4 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4282), "imageNews4.jpg", false, "new's name " },
                    { 8, 8, "Content 8 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4457), "imageNews8.jpg", false, "new's name " },
                    { 15, 2, "Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4696), "imageNews15.jpg", false, "new's name " },
                    { 12, 2, "Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4621), "imageNews12.jpg", false, "new's name " },
                    { 2, 2, "Content 2 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4134), "imageNews2.jpg", false, "new's name " },
                    { 14, 1, "Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4658), "imageNews14.jpg", false, "new's name " },
                    { 11, 1, "Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4582), "imageNews11.jpg", false, "new's name " },
                    { 3, 3, "Content 3 Lorem ipsum dolor sit amet,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2021, 8, 20, 13, 8, 55, 399, DateTimeKind.Local).AddTicks(4182), "imageNews3.jpg", false, "new's name " }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "email", "firstName", "lastName", "password", "photo", "roleId" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(8776), false, "mail11@Mail.com", "User 11", "RegularUser 11", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers11.jpg", 2 },
                    { 18, new DateTime(2021, 8, 20, 13, 8, 55, 394, DateTimeKind.Local).AddTicks(92), false, "mail18@Mail.com", "User 18", "RegularUser 18", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers18.jpg", 2 },
                    { 17, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(9921), false, "mail17@Mail.com", "User 17", "RegularUser 17", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers17.jpg", 2 },
                    { 16, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(9637), false, "mail16@Mail.com", "User 16", "RegularUser 16", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers16.jpg", 2 },
                    { 15, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(9473), false, "mail15@Mail.com", "User 15", "RegularUser 15", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers15.jpg", 2 },
                    { 14, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(9320), false, "mail14@Mail.com", "User 14", "RegularUser 14", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers14.jpg", 2 },
                    { 13, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(9096), false, "mail13@Mail.com", "User 13", "RegularUser 13", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers13.jpg", 2 },
                    { 12, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(8943), false, "mail12@Mail.com", "User 12", "RegularUser 12", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers12.jpg", 2 },
                    { 10, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(8542), false, "mail10@Mail.com", "User 10", "AdminUser 10", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers10.jpg", 1 },
                    { 3, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(7206), false, "mail3@Mail.com", "User 3", "AdminUser 3", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers3.jpg", 1 },
                    { 8, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(8207), false, "mail8@Mail.com", "User 8", "AdminUser 8", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers8.jpg", 1 },
                    { 7, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(8050), false, "mail7@Mail.com", "User 7", "AdminUser 7", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers7.jpg", 1 },
                    { 6, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(7813), false, "mail6@Mail.com", "User 6", "AdminUser 6", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers6.jpg", 1 },
                    { 5, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(7627), false, "mail5@Mail.com", "User 5", "AdminUser 5", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers5.jpg", 1 },
                    { 4, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(7458), false, "mail4@Mail.com", "User 4", "AdminUser 4", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers4.jpg", 1 },
                    { 19, new DateTime(2021, 8, 20, 13, 8, 55, 394, DateTimeKind.Local).AddTicks(263), false, "mail19@Mail.com", "User 19", "RegularUser 19", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers19.jpg", 2 },
                    { 2, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(7012), false, "mail2@Mail.com", "User 2", "AdminUser 2", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers2.jpg", 1 },
                    { 1, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(6100), false, "mail1@Mail.com", "User 1", "AdminUser 1", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers1.jpg", 1 },
                    { 9, new DateTime(2021, 8, 20, 13, 8, 55, 393, DateTimeKind.Local).AddTicks(8377), false, "mail9@Mail.com", "User 9", "AdminUser 9", "3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2", "TestUsers9.jpg", 1 },
                    { 20, new DateTime(2021, 8, 20, 13, 8, 55, 394, DateTimeKind.Local).AddTicks(530), false, "mail20@Mail.com", "User 20", "RegularUser 20", "a61a8adf60038792a2cb88e670b20540a9d6c2ca204ab754fc768950e79e7d36", "TestUsers20.jpg", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
