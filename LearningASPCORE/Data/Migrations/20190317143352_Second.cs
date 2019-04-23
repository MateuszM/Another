using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningASPCORE.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Diary",
                columns: new[] { "Id", "ContentPage", "IsChanged", "PageTitle", "Registration" },
                values: new object[,]
                {
                    { 1, "Coś Się kończy coś się zaczyna", false, "My Diary", new DateTime(2008, 3, 9, 16, 5, 7, 123, DateTimeKind.Unspecified) },
                    { 2, "A moze nie ma tragedii?", false, "Rozdzial Pierwszy", new DateTime(2009, 3, 9, 16, 5, 7, 123, DateTimeKind.Unspecified) },
                    { 3, "Coś Jednak jest na rzeczy", false, "     ", new DateTime(2010, 3, 9, 16, 5, 7, 123, DateTimeKind.Unspecified) },
                    { 4, "Koniec nie ma juz nic", false, "....", new DateTime(2012, 3, 9, 16, 5, 7, 123, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diary",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diary",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diary",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diary",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
