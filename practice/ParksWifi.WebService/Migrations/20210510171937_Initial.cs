using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksWifi.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WifiHotspots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FunctionFlag = table.Column<string>(type: "TEXT", nullable: true),
                    WiFiName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ParkName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WifiHotspots", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WifiHotspots",
                columns: new[] { "Id", "FunctionFlag", "Name", "ParkName", "WiFiName" },
                values: new object[] { 1L, null, "Moscow_WiFi_Free", "Государственное автономное учреждение культуры города Москвы «Парк культуры и отдыха «Сокольники»", null });

            migrationBuilder.InsertData(
                table: "WifiHotspots",
                columns: new[] { "Id", "FunctionFlag", "Name", "ParkName", "WiFiName" },
                values: new object[] { 2L, null, "Moscow_WiFi_Free", "Государственное автономное учреждение культуры города Москвы «Музейно-парковый комплекс «Северное Тушино», парк «Северное Тушино»  ", null });

            migrationBuilder.InsertData(
                table: "WifiHotspots",
                columns: new[] { "Id", "FunctionFlag", "Name", "ParkName", "WiFiName" },
                values: new object[] { 3L, null, "Moscow_WiFi_Free", "Государственное бюджетное учреждение культуры города Москвы «Государственный Дарвиновский музей», территория около музея", null });

            migrationBuilder.InsertData(
                table: "WifiHotspots",
                columns: new[] { "Id", "FunctionFlag", "Name", "ParkName", "WiFiName" },
                values: new object[] { 4L, null, "Moscow_WiFi_Free", "Государственное автономное учреждение культуры города Москвы «Парк культуры и отдыха «Фили», Парк 50-летия Октября", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WifiHotspots");
        }
    }
}
