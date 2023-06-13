using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PredictionBot_DataManagement_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calculatedparametershistoricaldatamapping");

            migrationBuilder.DropTable(
                name: "calculatedparametershistoricaldata");

            migrationBuilder.DropTable(
                name: "historicaldata");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.DropTable(
                name: "interval");

            migrationBuilder.DropTable(
                name: "symbol");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "exchange");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    currency_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    currency_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    currency_symbol = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.currency_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "exchange",
                columns: table => new
                {
                    exchange_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    exchange_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    timezone = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.exchange_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "interval",
                columns: table => new
                {
                    interval_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    interval_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.interval_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    parameter_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    parameter_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.parameter_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "symbol",
                columns: table => new
                {
                    symbol_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    currency_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    exchange_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    symbol_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.symbol_id);
                    table.ForeignKey(
                        name: "currency_id",
                        column: x => x.currency_id,
                        principalTable: "currency",
                        principalColumn: "currency_id");
                    table.ForeignKey(
                        name: "exchange_id",
                        column: x => x.exchange_id,
                        principalTable: "exchange",
                        principalColumn: "exchange_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "calculatedparametershistoricaldata",
                columns: table => new
                {
                    calculated_parameter_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calculated_value = table.Column<float>(type: "float", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    parameter_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.calculated_parameter_id);
                    table.ForeignKey(
                        name: "parameter_id",
                        column: x => x.parameter_id,
                        principalTable: "parameters",
                        principalColumn: "parameter_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "historicaldata",
                columns: table => new
                {
                    data_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    close_price = table.Column<float>(type: "float", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    high_price = table.Column<float>(type: "float", nullable: false),
                    interval_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    low_price = table.Column<float>(type: "float", nullable: false),
                    open_price = table.Column<float>(type: "float", nullable: false),
                    symbol_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    volume = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.data_id);
                    table.ForeignKey(
                        name: "interval_id",
                        column: x => x.interval_id,
                        principalTable: "interval",
                        principalColumn: "interval_id");
                    table.ForeignKey(
                        name: "symbol_id",
                        column: x => x.symbol_id,
                        principalTable: "symbol",
                        principalColumn: "symbol_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "calculatedparametershistoricaldatamapping",
                columns: table => new
                {
                    mapping_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calculated_parameter_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_id = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.mapping_id);
                    table.ForeignKey(
                        name: "calculated_parameter_id",
                        column: x => x.calculated_parameter_id,
                        principalTable: "calculatedparametershistoricaldata",
                        principalColumn: "calculated_parameter_id");
                    table.ForeignKey(
                        name: "data_id",
                        column: x => x.data_id,
                        principalTable: "historicaldata",
                        principalColumn: "data_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "parameter_id",
                table: "calculatedparametershistoricaldata",
                column: "parameter_id");

            migrationBuilder.CreateIndex(
                name: "calculated_parameter_id",
                table: "calculatedparametershistoricaldatamapping",
                column: "calculated_parameter_id");

            migrationBuilder.CreateIndex(
                name: "data_id",
                table: "calculatedparametershistoricaldatamapping",
                column: "data_id");

            migrationBuilder.CreateIndex(
                name: "interval_id",
                table: "historicaldata",
                column: "interval_id");

            migrationBuilder.CreateIndex(
                name: "symbol_id",
                table: "historicaldata",
                column: "symbol_id");

            migrationBuilder.CreateIndex(
                name: "currency_id",
                table: "symbol",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "exchange_id",
                table: "symbol",
                column: "exchange_id");
        }
    }
}