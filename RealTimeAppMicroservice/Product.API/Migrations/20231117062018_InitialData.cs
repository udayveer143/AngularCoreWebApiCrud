using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Camera" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "CP PLUS 3MP Full HD Smart Wi-fi CCTV Home Security Camera | 360° View | 2 Way Talk | Cloud Monitor | Motion Detect | Night Vision | Supports SD Card, Alexa & Ok Google | 15 Mtr, White- CP-E31A", "https://m.media-amazon.com/images/I/31jX+aam1nL._SL1000_.jpg", 1999m, "CP PLUS 3MP" },
                    { 2, 1, "TP-Link Tapo 360° 2MP 1080p Full HD Pan/Tilt Home Security Wi-Fi Smart Camera| Alexa Enabled| 2-Way Audio| Night Vision| Motion Detection| Sound and Light Alarm| Indoor CCTV (Tapo C200) White", "https://m.media-amazon.com/images/I/41KuE9NipqL._SL1000_.jpg", 2299m, "Tapo" },
                    { 3, 1, "Fujifilm Instax Mini 12 Instant Camera-Pink", "https://m.media-amazon.com/images/I/61+5Ld-oc1L._SL1500_.jpg", 6999m, "FUJIFILM" },
                    { 4, 1, "ROCKTECH® Action Camera for Vlogging, Mountain Biking,Travelling, Scuba Diving,Motor Vlogging (4K @ 30FPS Action Camera)", "https://m.media-amazon.com/images/I/51Bp3mZIcZL._SX569_.jpg", 2199m, "Travel Camera" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
