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
        // GET: Veiculos
        // Lista os viículos disponíveis para aluguel. O método Index é responsável por buscar os veículos no banco de dados e retornar a view correspondente.
        public IActionResult Index()
        {   // var veiculos = _context.Veiculos.Where(v => v.Disponivel).ToList(); <- filtra apenas veículos disponíveis
            var veiculos = _context.Veiculos.ToList(); // Busca todos os veículos no banco de dados
            return View(veiculos);
        }

        // GET: Veiculos/Create
        // Exibe o formulário para criar um novo veículo. O método Create é responsável por retornar a view de criação de veículo.
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
        // GET: Veiculos/Edit/5
        // Exibe o formulário para editar um veículo existente. O método Edit é responsável por buscar o veículo pelo id e retornar a view de edição.
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

        // GET: Veiculos/Delete/5
        // Exibe a confirmação para excluir um veículo. O método Delete é responsável por buscar o veículo pelo id e retornar a view de confirmação de exclusão.
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
