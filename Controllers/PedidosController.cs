using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudRestaurante.Data;
using CrudRestaurante.Models;

namespace CrudRestaurante.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var lista = _context.Pedido.Include(c => c.Cliente).Include(e => e.Empleado).Include(m => m.Mesa);
            return View(await lista.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(c => c.Cliente)
                .Include(e => e.Empleado)
                .Include(m => m.Mesa)
                .FirstOrDefaultAsync(m => m.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Nombre");
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre");
            ViewData["MesaID"] = new SelectList(_context.Mesa, "MesaID", "NumeroPersonas");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoID,ClienteID,EmpleadoID,MesaID,Fecha,Domicilio")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Nombre", pedido.ClienteID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", pedido.EmpleadoID);
            ViewData["MesaID"] = new SelectList(_context.Mesa, "MesaID", "NumeroPersonas", pedido.MesaID);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Nombre", pedido.ClienteID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", pedido.EmpleadoID);
            ViewData["MesaID"] = new SelectList(_context.Mesa, "MesaID", "NumeroPersonas", pedido.MesaID);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoID,ClienteID,EmpleadoID,MesaID,Fecha,Domicilio")] Pedido pedido)
        {
            if (id != pedido.PedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteID", pedido.ClienteID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "EmpleadoID", pedido.EmpleadoID);
            ViewData["MesaID"] = new SelectList(_context.Mesa, "MesaID", "MesaID", pedido.MesaID);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Include(p => p.Mesa)
                .FirstOrDefaultAsync(m => m.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.PedidoID == id);
        }
    }
}
