using Mexpressapp.Models;
using Microsoft.AspNetCore.Mvc;
using Mexpressapp.Data;
using Microsoft.AspNetCore.Authorization;


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
        {   // var veiculos = _context.Veiculos.Where(v => v.Disponivel).ToList(); <- filtra apenas veículos disponíveis
            var veiculos = _context.Veiculos.ToList(); // Busca todos os veículos no banco de dados
            return View(veiculos);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Indica que este método responde a requisições POST
        [ValidateAntiForgeryToken] // Protege contra CSRF
        public IActionResult Create(Veiculo veiculo) // Recebe o objeto do formulário
        {
            if (ModelState.IsValid) // Valida
            {
                _context.Veiculos.Add(veiculo); // Adiciona ao contexto
                _context.SaveChanges(); // Salva no banco
                return RedirectToAction(nameof(Index)); // Redireciona para a lista
            }

            return View(veiculo); // Se inválido, retorna à view com o modelo
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id) // Recebe o id do veículo a ser editado
        {
            var veiculo = _context.Veiculos.Find(id); // Busca o veículo no banco

            if (veiculo == null)
            {
                return NotFound(); // Retorna 404 se não encontrado
            }

            return View(veiculo); // Retorna a view de edição com o veículo
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Veiculo veiculo) // Recebe o id e o objeto editado
        {
            if (id != veiculo.Id)
            {
                return NotFound(); // Retorna 404 se o id não corresponder
                // return BadRequest(); // Retorna 400 se o id não corresponder
            }
            if (ModelState.IsValid)
            {
                _context.Update(veiculo); // Atualiza o veículo no contexto
                _context.SaveChanges();  // Salva as mudanças no banco
                return RedirectToAction(nameof(Index)); // Redireciona para a lista
            }
            return View(veiculo);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var veiculo = _context.Veiculos.Find(id);

            if (veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);
        }

        [HttpPost, ActionName("Delete")] // Especifica que este método é a ação POST para Delete
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            var veiculo = _context.Veiculos.Find(Id);

            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
