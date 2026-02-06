using Microsoft.AspNetCore.Authorization; // Necessário para o atributo [Authorize]
using Microsoft.AspNetCore.Mvc;
using Mexpressapp.Data;
using System.Linq; // Necessário para o método ToList()

namespace Mexpressapp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context; // Injeção do DbContext

        public DashboardController(AppDbContext context) // Construtor
        {
            _context = context; // Inicializa o contexto
        }

        public IActionResult Index()
        {
            var totalVeiculos = _context.Veiculos.Count(); // Conta o total de veículos
            var disponiveis = _context.Veiculos.Count(v => v.Disponivel); // Conta os veículos disponíveis
            var indisponiveis = totalVeiculos - disponiveis; // Calcula os indisponíveis

            ViewBag.TotalVeiculos = totalVeiculos; // Passa o total para a ViewBag
            ViewBag.Disponiveis = disponiveis;
            ViewBag.Indisponiveis = indisponiveis;

            return View();
        }
    }
}
