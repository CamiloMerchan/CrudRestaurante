using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudRestaurante.Data.Migrations
{
    public partial class AgregandoPlato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    PagoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoID = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaFin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.PagoID);
                    table.ForeignKey(
                        name: "FK_Pago_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plato",
                columns: table => new
                {
                    PlatoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombrePlato = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plato", x => x.PlatoID);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    DetallePedidoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlatoID = table.Column<int>(nullable: false),
                    PedidoID = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.DetallePedidoID);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "Pedido",
                        principalColumn: "PedidoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Plato_PlatoID",
                        column: x => x.PlatoID,
                        principalTable: "Plato",
                        principalColumn: "PlatoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PedidoID",
                table: "DetallePedido",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PlatoID",
                table: "DetallePedido",
                column: "PlatoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_EmpleadoID",
                table: "Pago",
                column: "EmpleadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Plato");
        }
    }
}
