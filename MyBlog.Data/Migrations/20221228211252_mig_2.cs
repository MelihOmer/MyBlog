using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("41646b7a-8c51-4a7a-86f7-c834a2ff5881"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 12, 51, 796, DateTimeKind.Local).AddTicks(5265));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e4705572-b7b0-4775-b02b-74f513d0cc89"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 12, 51, 796, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("10b7cda0-ed06-431e-a3ec-c88a69db8a92"),
                column: "ConcurrencyStamp",
                value: "af695388-44c8-48ea-aed7-98abbd3b7fc3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bdd590d1-0c43-4a68-8e57-edf67f70941c"),
                column: "ConcurrencyStamp",
                value: "23131c4b-2fa2-4210-95fd-a4c2b9ea07d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3e6fb00-d801-49f4-9c9a-b69e0f7a0e68"),
                column: "ConcurrencyStamp",
                value: "1a1c8399-386e-4a46-8252-d4a3b79d820c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0f21285-8b81-4c46-bc74-3e1db74290fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d96a40f7-2ef0-4f6a-8a34-183173bc9051", "AQAAAAEAACcQAAAAEM8lkzPHhst/s/EYBLCmhf01Dq2Z+DqR1rdJEIZXU//J/fiqaWzaediZhRwWM7Arnw==", "b21b90e5-15c6-4a28-9c9a-b44f937ae47f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d617ef9e-6c36-4099-8220-6372aaf5b196"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d6dd77e-6564-4dcc-8e1b-df8edfdbeddb", "AQAAAAEAACcQAAAAEEME1AffNcB26gMtKix0/5k7Qj4uJXVXlotMz0c34uU16IfWdQPTmO6rTk4cP9jRSw==", "a0e1d42f-91cc-4f3f-9911-afd02f8f10d1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78f5f289-ffb9-4588-b3c9-888407ccf129"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 12, 51, 796, DateTimeKind.Local).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f71c92-e8c9-4d75-b3ec-c00c9240fe8b"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 12, 51, 796, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("58f06691-f7ba-4794-9da4-bb4895bf8426"),
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2022, 12, 29, 0, 12, 51, 802, DateTimeKind.Local).AddTicks(8796), new Guid("d617ef9e-6c36-4099-8220-6372aaf5b196") });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b61018f1-65c1-4ab1-98aa-bce223156590"),
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2022, 12, 29, 0, 12, 51, 802, DateTimeKind.Local).AddTicks(8789), new Guid("b0f21285-8b81-4c46-bc74-3e1db74290fb") });

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("41646b7a-8c51-4a7a-86f7-c834a2ff5881"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 1, 26, 658, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e4705572-b7b0-4775-b02b-74f513d0cc89"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 1, 26, 657, DateTimeKind.Local).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("10b7cda0-ed06-431e-a3ec-c88a69db8a92"),
                column: "ConcurrencyStamp",
                value: "189de129-defd-4879-82d7-c78c33ba7f19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bdd590d1-0c43-4a68-8e57-edf67f70941c"),
                column: "ConcurrencyStamp",
                value: "42172658-ce1a-417f-bc39-1160fedd6d8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3e6fb00-d801-49f4-9c9a-b69e0f7a0e68"),
                column: "ConcurrencyStamp",
                value: "60ffe655-408e-46c4-a544-e14ba54d431c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0f21285-8b81-4c46-bc74-3e1db74290fb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74a56d5e-8317-4e17-a925-bcc3151bc17f", "AQAAAAEAACcQAAAAENvakhHNdvjNxRAsABtf494kD6f2EtZEcQsfaX6J/djPDfaZ+RPeFpOdzD2Wph/5Dg==", "ed1f2905-775b-4b7d-a8a6-9936da4d2ac6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d617ef9e-6c36-4099-8220-6372aaf5b196"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f27eaa5b-3d1b-4329-89ed-6aee5308639e", "AQAAAAEAACcQAAAAEBhAH1iNudoFefSdTvGPYL3AEHiTfB9TmJ7WA4gH7a1FMQIFq7ukX7uWOelXysBGxw==", "996b8e37-509f-4c5d-ae5e-787fa3c8bba2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78f5f289-ffb9-4588-b3c9-888407ccf129"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 1, 26, 658, DateTimeKind.Local).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0f71c92-e8c9-4d75-b3ec-c00c9240fe8b"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 1, 26, 658, DateTimeKind.Local).AddTicks(134));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("58f06691-f7ba-4794-9da4-bb4895bf8426"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 1, 26, 662, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b61018f1-65c1-4ab1-98aa-bce223156590"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 0, 1, 26, 662, DateTimeKind.Local).AddTicks(2));
        }
    }
}
