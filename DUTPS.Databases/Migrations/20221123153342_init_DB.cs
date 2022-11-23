using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DUTPS.Databases.Migrations
{
    public partial class init_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "Id of faculty"),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true, comment: "Name of Faculty"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "the time that the record was inserted"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "record's last update time"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "the time that the record was deleted"),
                    del_flag = table.Column<bool>(type: "boolean", nullable: false, comment: "true = deleted; false = available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "primary key of table and auto increase")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false, comment: "username of user (sv id)"),
                    email = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false, comment: "email"),
                    password_hash = table.Column<byte[]>(type: "bytea", nullable: true, comment: "password hash"),
                    password_salt = table.Column<byte[]>(type: "bytea", nullable: true, comment: "password salt"),
                    status = table.Column<int>(type: "integer", nullable: false, comment: "status of account of user"),
                    role = table.Column<int>(type: "integer", nullable: false, comment: "role of account of user"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "the time that the record was inserted"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "record's last update time"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "the time that the record was deleted"),
                    del_flag = table.Column<bool>(type: "boolean", nullable: false, comment: "true = deleted; false = available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "primary key to identity the user"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "name of user"),
                    gender = table.Column<int>(type: "integer", nullable: true, comment: "gender of user"),
                    birthday = table.Column<DateTime>(type: "date", nullable: true, comment: "birthday of user"),
                    phoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "phone number of user"),
                    @class = table.Column<string>(name: "class", type: "character varying(50)", maxLength: 50, nullable: true, comment: "class name of user"),
                    faculty_id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, comment: "Faculty Id Of User"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "the time that the record was inserted"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "record's last update time"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "the time that the record was deleted"),
                    del_flag = table.Column<bool>(type: "boolean", nullable: false, comment: "true = deleted; false = available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_UserInfos_Faculties_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "Faculties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserInfos_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

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
                name: "IX_UserInfos_faculty_id",
                table: "UserInfos",
                column: "faculty_id");

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
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "CheckIns");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Vehicals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
