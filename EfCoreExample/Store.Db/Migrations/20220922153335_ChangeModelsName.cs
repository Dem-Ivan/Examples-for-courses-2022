using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Db.Migrations
{
    public partial class ChangeModelsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_customer_customer_id",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "customers");

            migrationBuilder.RenameIndex(
                name: "IX_order_customer_id",
                table: "orders",
                newName: "IX_orders_customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_customer_id",
                table: "orders",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_customer_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "customer");

            migrationBuilder.RenameIndex(
                name: "IX_orders_customer_id",
                table: "order",
                newName: "IX_order_customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer_customer_id",
                table: "order",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
