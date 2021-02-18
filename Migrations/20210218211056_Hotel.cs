using Microsoft.EntityFrameworkCore.Migrations;

namespace RK_Hotels.Migrations
{
    public partial class Hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price_Per_Night = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availablity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Opening_Hours = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_DetailId = table.Column<int>(type: "int", nullable: false),
                    Hotel_DetailId = table.Column<int>(type: "int", nullable: false),
                    Room_DetailId = table.Column<int>(type: "int", nullable: false),
                    Service_DetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Detail_Customer_Detail_Customer_DetailId",
                        column: x => x.Customer_DetailId,
                        principalTable: "Customer_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Detail_Hotel_Detail_Hotel_DetailId",
                        column: x => x.Hotel_DetailId,
                        principalTable: "Hotel_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Detail_Room_Detail_Room_DetailId",
                        column: x => x.Room_DetailId,
                        principalTable: "Room_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Detail_Service_Detail_Service_DetailId",
                        column: x => x.Service_DetailId,
                        principalTable: "Service_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Detail_Customer_DetailId",
                table: "Booking_Detail",
                column: "Customer_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Detail_Hotel_DetailId",
                table: "Booking_Detail",
                column: "Hotel_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Detail_Room_DetailId",
                table: "Booking_Detail",
                column: "Room_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Detail_Service_DetailId",
                table: "Booking_Detail",
                column: "Service_DetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Detail");

            migrationBuilder.DropTable(
                name: "Customer_Detail");

            migrationBuilder.DropTable(
                name: "Hotel_Detail");

            migrationBuilder.DropTable(
                name: "Room_Detail");

            migrationBuilder.DropTable(
                name: "Service_Detail");
        }
    }
}
