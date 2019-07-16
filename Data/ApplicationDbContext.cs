using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrudRestaurante.Models;

namespace CrudRestaurante.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CrudRestaurante.Models.Cargo> Cargo { get; set; }
        public DbSet<CrudRestaurante.Models.Empleado> Empleado { get; set; }
        public DbSet<CrudRestaurante.Models.Cliente> Cliente { get; set; }
        public DbSet<CrudRestaurante.Models.Mesa> Mesa { get; set; }
        public DbSet<CrudRestaurante.Models.Pedido> Pedido { get; set; }
        public DbSet<CrudRestaurante.Models.Plato> Plato { get; set; }
        public DbSet<CrudRestaurante.Models.Pago> Pago { get; set; }
        public DbSet<CrudRestaurante.Models.DetallePedido> DetallePedido { get; set; }
    }
}
