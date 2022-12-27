using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class migdataseedImage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("41646b7a-8c51-4a7a-86f7-c834a2ff5881"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 37, 48, 744, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e4705572-b7b0-4775-b02b-74f513d0cc89"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 37, 48, 744, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78f5f289-ffb9-4588-b3c9-888407ccf129"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 37, 48, 744, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f71c92-e8c9-4d75-b3ec-c00c9240fe8b"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 37, 48, 744, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b61018f1-65c1-4ab1-98aa-bce223156590"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 37, 48, 744, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ArticleId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDated", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { new Guid("58f06691-f7ba-4794-9da4-bb4895bf8426"), new Guid("41646b7a-8c51-4a7a-86f7-c834a2ff5881"), "Admin Test", new DateTime(2022, 12, 25, 23, 37, 48, 744, DateTimeKind.Local).AddTicks(2024), null, null, "images/vs2022images", "JPEG", false, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("58f06691-f7ba-4794-9da4-bb4895bf8426"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("41646b7a-8c51-4a7a-86f7-c834a2ff5881"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 35, 41, 395, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e4705572-b7b0-4775-b02b-74f513d0cc89"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 35, 41, 395, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78f5f289-ffb9-4588-b3c9-888407ccf129"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 35, 41, 395, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f71c92-e8c9-4d75-b3ec-c00c9240fe8b"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 35, 41, 395, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b61018f1-65c1-4ab1-98aa-bce223156590"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 25, 23, 35, 41, 395, DateTimeKind.Local).AddTicks(5091));
        }
    }
}
