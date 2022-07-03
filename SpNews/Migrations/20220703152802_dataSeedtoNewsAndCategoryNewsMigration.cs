using Microsoft.EntityFrameworkCore.Migrations;

namespace SpNews.Migrations
{
    public partial class dataSeedtoNewsAndCategoryNewsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Date", "Description", "Name" },
                values: new object[] { 1, "2022-07-03", "The 37-year-old feels the urge to win even more in the twilight of his career, but is understood to feel that may not be possible at Old Trafford next season. The 2021/22 campaign was the fifth in succession in which United failed to win a trophy.", "Cristiano Ronaldo wants to leave Manchester United this summer" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Date", "Description", "Name" },
                values: new object[] { 2, "2022-07-03", "Chelsea's bid has at this point trumped Arsenal, who had an opening bid rejected but are expected to go back in with an improved offer. Chelsea are also in for Raheem Sterling with Manchester City expecting to field a bid for the England international after Thomas Tuchel engaged Sterling over how he would fit in at Stamford Bridge.", "Chelsea transfer news and rumours: Summer transfer window 2022" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Date", "Description", "Name" },
                values: new object[] { 3, "2022-07-03", "Manchester City are expecting to field an opening offer from Chelsea for Raheem Sterling after Thomas Tuchel engaged the England international over how he'd fit in at Stamford Bridge.The forward heads a shortlist of the manager's attacking targets and enters the final year of his contract with the Premier League champions, who are grateful for his service and will not obstruct his desire for greater minutes and status elsewhere.", "Man City transfer news and rumours: Summer transfer window 2022" });

            migrationBuilder.InsertData(
                table: "CategoryToNews",
                columns: new[] { "NewsId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryToNews",
                keyColumns: new[] { "NewsId", "CategoryId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryToNews",
                keyColumns: new[] { "NewsId", "CategoryId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryToNews",
                keyColumns: new[] { "NewsId", "CategoryId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryToNews",
                keyColumns: new[] { "NewsId", "CategoryId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryToNews",
                keyColumns: new[] { "NewsId", "CategoryId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryToNews",
                keyColumns: new[] { "NewsId", "CategoryId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
