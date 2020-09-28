using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class newmigr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brandPhones",
                columns: table => new
                {
                    BrandPhoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brandPhones", x => x.BrandPhoneId);
                });

            migrationBuilder.CreateTable(
                name: "crashes",
                columns: table => new
                {
                    CrashId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crashes", x => x.CrashId);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DateRegister = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "modelPhones",
                columns: table => new
                {
                    ModelPhoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BrandPhoneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelPhones", x => x.ModelPhoneId);
                    table.ForeignKey(
                        name: "FK_modelPhones_brandPhones_BrandPhoneId",
                        column: x => x.BrandPhoneId,
                        principalTable: "brandPhones",
                        principalColumn: "BrandPhoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    BrandPhoneId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_comments_brandPhones_BrandPhoneId",
                        column: x => x.BrandPhoneId,
                        principalTable: "brandPhones",
                        principalColumn: "BrandPhoneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Active = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    ModelPhoneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_modelPhones_ModelPhoneId",
                        column: x => x.ModelPhoneId,
                        principalTable: "modelPhones",
                        principalColumn: "ModelPhoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    PriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrashId = table.Column<int>(nullable: false),
                    ModelPhoneId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_prices_crashes_CrashId",
                        column: x => x.CrashId,
                        principalTable: "crashes",
                        principalColumn: "CrashId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prices_modelPhones_ModelPhoneId",
                        column: x => x.ModelPhoneId,
                        principalTable: "modelPhones",
                        principalColumn: "ModelPhoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderCrushes",
                columns: table => new
                {
                    OrderCrushId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: true),
                    CrashId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderCrushes", x => x.OrderCrushId);
                    table.ForeignKey(
                        name: "FK_orderCrushes_crashes_CrashId",
                        column: x => x.CrashId,
                        principalTable: "crashes",
                        principalColumn: "CrashId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orderCrushes_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderPrices",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    PriceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderPrices", x => new { x.OrderId, x.PriceId });
                    table.ForeignKey(
                        name: "FK_orderPrices_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderPrices_prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_BrandPhoneId",
                table: "comments",
                column: "BrandPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_CustomerId",
                table: "comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_modelPhones_BrandPhoneId",
                table: "modelPhones",
                column: "BrandPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_orderCrushes_CrashId",
                table: "orderCrushes",
                column: "CrashId");

            migrationBuilder.CreateIndex(
                name: "IX_orderCrushes_OrderId",
                table: "orderCrushes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderPrices_PriceId",
                table: "orderPrices",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ModelPhoneId",
                table: "orders",
                column: "ModelPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_prices_CrashId",
                table: "prices",
                column: "CrashId");

            migrationBuilder.CreateIndex(
                name: "IX_prices_ModelPhoneId",
                table: "prices",
                column: "ModelPhoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "orderCrushes");

            migrationBuilder.DropTable(
                name: "orderPrices");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "crashes");

            migrationBuilder.DropTable(
                name: "modelPhones");

            migrationBuilder.DropTable(
                name: "brandPhones");
        }
    }
}
