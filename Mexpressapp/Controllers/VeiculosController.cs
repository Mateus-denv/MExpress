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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Indica que este método responde a requisições POST
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public IActionResult Create (Veiculo veiculo) // Recebe o objeto do formulário
        {
            if (ModelState.IsValid) // Valida
            {
                _context.Veiculos.Add(veiculo); // Adiciona ao contexto
                _context.SaveChanges(); // Salva no banco
                return RedirectToAction(nameof(Index)); // Redireciona para a lista
            }

            return View(veiculo); // Se inválido, retorna à view com o modelo
        }
    }
}
