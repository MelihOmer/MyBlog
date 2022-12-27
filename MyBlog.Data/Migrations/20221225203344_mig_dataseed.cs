using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class migdataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDated", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("78f5f289-ffb9-4588-b3c9-888407ccf129"), "Admin Test", new DateTime(2022, 12, 25, 23, 33, 44, 202, DateTimeKind.Local).AddTicks(5213), null, null, false, null, null, "ASP.NET Core" },
                    { new Guid("c0f71c92-e8c9-4d75-b3ec-c00c9240fe8b"), "Admin Test", new DateTime(2022, 12, 25, 23, 33, 44, 202, DateTimeKind.Local).AddTicks(5215), null, null, false, null, null, "Visual Studio 2022" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDated", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("41646b7a-8c51-4a7a-86f7-c834a2ff5881"), new Guid("c0f71c92-e8c9-4d75-b3ec-c00c9240fe8b"), "Visual Studio Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.", "Admin Test", new DateTime(2022, 12, 25, 23, 33, 44, 202, DateTimeKind.Local).AddTicks(5055), null, null, false, null, null, "Visual Studio Deneme Makalesi 1", 10 },
                    { new Guid("e4705572-b7b0-4775-b02b-74f513d0cc89"), new Guid("78f5f289-ffb9-4588-b3c9-888407ccf129"), "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.", "Admin Test", new DateTime(2022, 12, 25, 23, 33, 44, 202, DateTimeKind.Local).AddTicks(5052), null, null, false, null, null, "Asp.Net Core Deneme Makalesi 1", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("41646b7a-8c51-4a7a-86f7-c834a2ff5881"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e4705572-b7b0-4775-b02b-74f513d0cc89"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78f5f289-ffb9-4588-b3c9-888407ccf129"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f71c92-e8c9-4d75-b3ec-c00c9240fe8b"));
        }
    }
}
