using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjCineWeb.Data;
using ProjCineWeb.Model;

namespace ProjCineWeb.Controllers
{
    public class IngressoesController : Controller
    {
        private readonly ProjCineWebContext _context;

        public IngressoesController(ProjCineWebContext context)
        {
            _context = context;
        }

        // GET: Ingressoes
        public async Task<IActionResult> Index()
        {
            var cli = await _context.Ingresso.Include(c => c.Cliente).ToListAsync();
            var film = await _context.Ingresso.Include(f => f.Filme).ToListAsync();

            //return View(await _context.Ingresso.ToListAsync());
            return View(cli);
        }

        // GET: Ingressoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // GET: Ingressoes/Create
        public IActionResult Create()
        {
            var i = new Ingresso();
            var clientes = _context.Cliente.ToList();
            var filmes = _context.Filme.ToList();

            i.Clientes = new List<SelectListItem>();
            i.Filmes = new List<SelectListItem>();

            foreach (var cli in clientes)
            {
                i.Clientes.Add(new SelectListItem { Text = cli.NomeCliente, Value = cli.Id.ToString() });
            }

            foreach (var film in filmes)
            {
                i.Filmes.Add(new SelectListItem { Text = film.NomeFilme, Value = film.Id.ToString() });
            }

            return View(i);
        }

        // POST: Ingressoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,DataHora")] Ingresso ingresso)
        {
            int _clienteId = int.Parse(Request.Form["Cliente"].ToString());
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == _clienteId);
            ingresso.Cliente = cliente;

            int _filmeId = int.Parse(Request.Form["Filme"].ToString());
            var filme = _context.Filme.FirstOrDefault(f => f.Id == _filmeId);
            ingresso.Filme = filme;

            if (ModelState.IsValid)
            {
                _context.Add(ingresso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingresso);
        }

        // GET: Ingressoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = _context.Ingresso.Include(c => c.Cliente).First(i => i.Id == id);

            var clientes = _context.Cliente.ToList();

            ingresso.Clientes = new List<SelectListItem>();

            foreach (var cli in clientes)
            {
                ingresso.Clientes.Add(new SelectListItem { Text = cli.NomeCliente, Value = cli.Id.ToString() });
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            
            ingresso = _context.Ingresso.Include(f => f.Filme).First(i => i.Id == id);

            var filmes = _context.Filme.ToList();

            ingresso.Filmes = new List<SelectListItem>();

            foreach (var film in filmes)
            {
                ingresso.Filmes.Add(new SelectListItem { Text = film.NomeFilme, Value = film.Id.ToString() });
            }

            if (ingresso == null)
            {
                return NotFound();
            }
            return View(ingresso);
        }

        // POST: Ingressoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,DataHora")] Ingresso ingresso)
        {
            if (id != ingresso.Id)
            {
                return NotFound();
            }

            int _clienteId = int.Parse(Request.Form["Cliente"].ToString());
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == _clienteId);
            ingresso.Cliente = cliente;

            int _filmeId = int.Parse(Request.Form["Filme"].ToString());
            var filme = _context.Filme.FirstOrDefault(f => f.Id == _filmeId);
            ingresso.Filme = filme;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingresso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngressoExists(ingresso.Id))
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
            return View(ingresso);
        }

        // GET: Ingressoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // POST: Ingressoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingresso = await _context.Ingresso.FindAsync(id);
            _context.Ingresso.Remove(ingresso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngressoExists(int id)
        {
            return _context.Ingresso.Any(e => e.Id == id);
        }
    }
}
