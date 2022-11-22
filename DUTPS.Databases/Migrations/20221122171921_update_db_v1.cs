using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DUTPS.Databases.Migrations
{
    public partial class update_db_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qrcode",
                table: "UserInfos");

            migrationBuilder.AlterColumn<byte[]>(
                name: "password_salt",
                table: "Users",
                type: "bytea",
                nullable: true,
                comment: "password salt",
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldComment: "password salt");

            migrationBuilder.AlterColumn<byte[]>(
                name: "password_hash",
                table: "Users",
                type: "bytea",
                nullable: true,
                comment: "password hash",
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldComment: "password hash");

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "role of account of user");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "UserInfos",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                comment: "name of user",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "name of user");

            migrationBuilder.AlterColumn<string>(
                name: "faculty_id",
                table: "UserInfos",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                comment: "Faculty Id Of User",
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "Faculty Id Of User");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Faculties",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                comment: "Id of faculty",
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3,
                oldComment: "Id of faculty");

            migrationBuilder.CreateTable(
                name: "Vehicals",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "primary key of table and auto increase")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LicensePlate = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "the time that the record was inserted"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "record's last update time"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "the time that the record was deleted"),
                    del_flag = table.Column<bool>(type: "boolean", nullable: false, comment: "true = deleted; false = available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vehicals_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CheckIns",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "primary key of table and auto increase")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfCheckIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCheckOut = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    VehicalId = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "the time that the record was inserted"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "record's last update time"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "the time that the record was deleted"),
                    del_flag = table.Column<bool>(type: "boolean", nullable: false, comment: "true = deleted; false = available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIns", x => x.id);
                    table.ForeignKey(
                        name: "FK_CheckIns_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CheckIns_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CheckIns_Vehicals_VehicalId",
                        column: x => x.VehicalId,
                        principalTable: "Vehicals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CheckOuts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "primary key of table and auto increase")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfCheckOut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    CheckInId = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "the time that the record was inserted"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "record's last update time"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "the time that the record was deleted"),
                    del_flag = table.Column<bool>(type: "boolean", nullable: false, comment: "true = deleted; false = available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOuts", x => x.id);
                    table.ForeignKey(
                        name: "FK_CheckOuts_CheckIns_CheckInId",
                        column: x => x.CheckInId,
                        principalTable: "CheckIns",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CheckOuts_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_CustomerId",
                table: "CheckIns",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_StaffId",
                table: "CheckIns",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_VehicalId",
                table: "CheckIns",
                column: "VehicalId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_CheckInId",
                table: "CheckOuts",
                column: "CheckInId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_StaffId",
                table: "CheckOuts",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicals_CustomerId",
                table: "Vehicals",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckOuts");

            migrationBuilder.DropTable(
                name: "CheckIns");

            migrationBuilder.DropTable(
                name: "Vehicals");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");

            migrationBuilder.AlterColumn<byte>(
                name: "password_salt",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "password salt",
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true,
                oldComment: "password salt");

            migrationBuilder.AlterColumn<byte>(
                name: "password_hash",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "password hash",
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true,
                oldComment: "password hash");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "UserInfos",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "name of user",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "name of user");

            migrationBuilder.AlterColumn<string>(
                name: "faculty_id",
                table: "UserInfos",
                type: "character varying(3)",
                maxLength: 3,
                nullable: true,
                comment: "Faculty Id Of User",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "Faculty Id Of User");

            migrationBuilder.AddColumn<string>(
                name: "qrcode",
                table: "UserInfos",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Link to QR Code Of User");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Faculties",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                comment: "Id of faculty",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldComment: "Id of faculty");
        }
    }
}
