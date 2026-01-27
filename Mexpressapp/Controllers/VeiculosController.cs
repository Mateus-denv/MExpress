using Mexpressapp.Models;
using Microsoft.AspNetCore.Mvc;
using Mexpressapp.Data;

namespace Mexpressapp.Controllers
{
    public class VeiculosController : Controller
    {

        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var veiculos = _context.Veiculos.Where(v => v.Disponivel).ToList();
            return View(veiculos);
        }
    }
}
