using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCourse.Spyshop.Web.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Cameras" },
                    { 2L, "Communication" },
                    { 3L, "Distraction" },
                    { 4L, "General" },
                    { 5L, "Navigation" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PhotoUrl", "Price", "SortNumber" },
                values: new object[,]
                {
                    { 1L, 1L, "The built-in camera in this watch transmits a secured videofeed to a nearby monitor.", "Spywatch", "watch.jpg", 39.95m, 1 },
                    { 23L, 5L, "Tracks your accurate altitude and position in every landscape.", "Offroad GPS", "gps.jpg", 15.95m, 2 },
                    { 22L, 5L, "Analyses signals sent to satellites. ", "Satellite Monitor", null, 25.95m, 1 },
                    { 21L, 4L, "This card game targets a specific person and lets him to win or lose. Comes with a mobile app.", "Card game", null, 70.95m, null },
                    { 20L, 4L, "A must-have when mingling with wealthy, evil geniuses.", "Bulletproof tuxedo", null, 133.95m, null },
                    { 19L, 4L, "Put a bandage on a wound and wait 10 to 30 minutes. Your injury will be fully healed.", "Quick Bandages", null, 12.95m, null },
                    { 18L, 4L, "The lenses allow to you to zoom up to 5 km.", "Zooming contactlenses", "lenses.jpg", 73.95m, null },
                    { 17L, 3L, "Place mentos in cola bottle. Point at target to distract.", "Cola and mentos", null, 1.95m, 5 },
                    { 16L, 3L, "Place banknotes in this wallet. Place this in the fridge overnight to have them turn into the local currency.", "Exchange wallet", "wallet.jpg", 29.95m, 4 },
                    { 15L, 3L, "When an enemy approaches you, simply switch on this device to confuse him. He will identify you as friendly.", "Identity Scrambler", "idscramble.jpg", 145.95m, 3 },
                    { 14L, 3L, "One small drip of this liquid on the nose of your victim and he will tell you no more lies. Works best on long noses.", "Correction liquid", "corrliq.jpg", 129.95m, 2 },
                    { 24L, 5L, "Tracks your accurate altitude and position using the Galileo satellites.", "Galileo tracer", null, 25.95m, 3 },
                    { 13L, 3L, "A small button underneath activates a hologram where you were previously seated.", "Holographic cushion", "cushion.jpg", 69.95m, 1 },
                    { 11L, 2L, "Put this robotic fish-shaped device in your ear and understand any language.", "Babelfish", null, 123.95m, null },
                    { 10L, 2L, "Hang these low profile ear rings and translate every word to a preset language whispered in your ear.", "Earring Translator", "earrings.jpg", 93.95m, 5 },
                    { 9L, 2L, "Advanced voice-technology ensures this moustasche translates every word you say in the language of choice.", "Mustasch Translator", "stash.jpg", 73.95m, 4 },
                    { 8L, 2L, "Evil geniuses have cats. Distract them with this laser pointer. Disperses catnip as a last resort.", "Cigar laserpointer", "cigar.jpg", 13.95m, 3 },
                    { 7L, 2L, "Point this pen at your discussion partner to convince him of your point of view. Writes in blue ink.", "Point of view pen", "pen.jpg", 9.95m, 2 },
                    { 6L, 2L, "A small transmitter shaped as a pencil. Speak in the tip and listen at the other end. Also writes.", "Communication pencil", "pencil.jpg", 6.95m, 1 },
                    { 5L, 1L, "Easy to hide and mount IR camera.", "Infrared camera", null, 15.95m, 5 },
                    { 4L, 1L, "When reaching an altitude of 1,5 km, this camera sends a live feed of the environment while parachuting down.", "Rocketchute \"Bird's eye\"", null, 7.95m, 4 },
                    { 3L, 1L, "This camera is waterproof to an astounding 700m, and runs entirely on hydrogen extracted by the environment.", "Underwater camera", null, 111.95m, 3 },
                    { 2L, 1L, "The built-in camera in this watch transmits a secured videofeed to a nearby monitor. Videos can be saved locally on a microchip.", "Spywatch with storage", "watch.jpg", 39.95m, 2 },
                    { 12L, 2L, "A tiny cellphony with tracking capabilities.", "Cellphone with tracking", "tinyphone.jpg", 33.95m, null },
                    { 25L, 5L, "These batteries (available in AA and AAA) send accurate positioning signals to the satellites of your choice.", "Tracer Batteries", "batteries.jpg", 29.95m, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
