using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OrderApiApp2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:btree_gin", ",,")
                .Annotation("Npgsql:PostgresExtension:btree_gist", ",,")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .Annotation("Npgsql:PostgresExtension:cube", ",,")
                .Annotation("Npgsql:PostgresExtension:dblink", ",,")
                .Annotation("Npgsql:PostgresExtension:dict_int", ",,")
                .Annotation("Npgsql:PostgresExtension:dict_xsyn", ",,")
                .Annotation("Npgsql:PostgresExtension:earthdistance", ",,")
                .Annotation("Npgsql:PostgresExtension:fuzzystrmatch", ",,")
                .Annotation("Npgsql:PostgresExtension:hstore", ",,")
                .Annotation("Npgsql:PostgresExtension:intarray", ",,")
                .Annotation("Npgsql:PostgresExtension:ltree", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrowlocks", ",,")
                .Annotation("Npgsql:PostgresExtension:pgstattuple", ",,")
                .Annotation("Npgsql:PostgresExtension:tablefunc", ",,")
                .Annotation("Npgsql:PostgresExtension:unaccent", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .Annotation("Npgsql:PostgresExtension:xml2", ",,");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    client_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("client_pkey", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id_product = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    product_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    articul = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cost = table.Column<double>(type: "double precision", nullable: false),
                    prod_pic = table.Column<string>(type: "character varying(900)", maxLength: 900, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_pkey", x => x.id_product);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id_order = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_client = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orders_pkey", x => x.id_order);
                    table.ForeignKey(
                        name: "orders_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "client",
                        principalColumn: "id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    id_factura = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_product = table.Column<int>(type: "integer", nullable: true),
                    id_order = table.Column<int>(type: "integer", nullable: true),
                    product_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    articul = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    qantity = table.Column<int>(type: "integer", nullable: false),
                    id_client = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("factura_pkey", x => x.id_factura);
                    table.ForeignKey(
                        name: "factura_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "client",
                        principalColumn: "id_client",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "factura_id_order_fkey",
                        column: x => x.id_order,
                        principalTable: "orders",
                        principalColumn: "id_order",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "factura_id_product_fkey",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_factura_id_client",
                table: "factura",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_factura_id_order",
                table: "factura",
                column: "id_order");

            migrationBuilder.CreateIndex(
                name: "IX_factura_id_product",
                table: "factura",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_orders_id_client",
                table: "orders",
                column: "id_client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
