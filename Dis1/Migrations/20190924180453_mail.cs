using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dis1.Migrations
{
    public partial class mail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Cc = table.Column<decimal>(type: "numeric(6, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    company_login = table.Column<string>(maxLength: 50, nullable: false),
                    company_pas = table.Column<string>(maxLength: 50, nullable: false),
                    Company_name = table.Column<string>(maxLength: 50, nullable: false),
                    Company_inn = table.Column<string>(maxLength: 50, nullable: true),
                    Family = table.Column<string>(maxLength: 50, nullable: true),
                    Firstname = table.Column<string>(maxLength: 50, nullable: true),
                    lasttname = table.Column<string>(maxLength: 50, nullable: true),
                    company_adress = table.Column<string>(maxLength: 50, nullable: true),
                    company_phone = table.Column<string>(maxLength: 50, nullable: true),
                    company_description = table.Column<string>(maxLength: 250, nullable: true),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Cc);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    cf = table.Column<decimal>(type: "numeric(6, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    friend_one = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    friend_two = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    stat = table.Column<decimal>(type: "decimal(1, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.cf);
                    table.ForeignKey(
                        name: "FK__Friends__friend___36B12243",
                        column: x => x.friend_one,
                        principalTable: "Company",
                        principalColumn: "Cc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Friends__friend___37A5467C",
                        column: x => x.friend_two,
                        principalTable: "Company",
                        principalColumn: "Cc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    cr = table.Column<decimal>(type: "numeric(6, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    report_date = table.Column<DateTime>(type: "date", nullable: false),
                    report_way = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    report_customer = table.Column<string>(maxLength: 50, nullable: false),
                    report_status = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    cc = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    report_name = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.cr);
                    table.ForeignKey(
                        name: "FK__Report__cc__2C3393D0",
                        column: x => x.cc,
                        principalTable: "Company",
                        principalColumn: "Cc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shablon",
                columns: table => new
                {
                    Cs = table.Column<decimal>(type: "numeric(6, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Shablon_name = table.Column<string>(maxLength: 50, nullable: false),
                    Shablon_position = table.Column<string>(maxLength: 50, nullable: false),
                    shablon_order = table.Column<string>(maxLength: 50, nullable: true),
                    shablon_agent = table.Column<string>(maxLength: 50, nullable: true),
                    cc = table.Column<decimal>(type: "numeric(6, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shablon", x => x.Cs);
                    table.ForeignKey(
                        name: "FK__Shablon__cc__29572725",
                        column: x => x.cc,
                        principalTable: "Company",
                        principalColumn: "Cc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_friend_one",
                table: "Friends",
                column: "friend_one");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_friend_two",
                table: "Friends",
                column: "friend_two");

            migrationBuilder.CreateIndex(
                name: "IX_Report_cc",
                table: "Report",
                column: "cc");

            migrationBuilder.CreateIndex(
                name: "IX_Shablon_cc",
                table: "Shablon",
                column: "cc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Shablon");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
