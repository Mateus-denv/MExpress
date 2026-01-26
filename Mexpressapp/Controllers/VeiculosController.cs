using Mexpressapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mexpressapp.Controllers
{
    public class VeiculosController : Controller
    {
        public IActionResult Index()
        {
            var veiculos = new List<Veiculo>
            {
                new Veiculo
                {
                    Id = "1",
                    Marca = "Toyota",
                    Modelo = "Corolla",
                    Cinlidrada = 1800,
                    Cavalos = 140,
                    Capacidadelitros = 13.2,
                    Kmrodados = 50000,
                    Disponivel = true,
                    Preçodia = 150.00m,
                    Placa = "ABC-1234"
                },
                new Veiculo
                {
                    Id = "2",
                    Marca = "Honda",
                    Modelo = "Civic",
                    Cinlidrada = 2000,
                    Cavalos = 158,
                    Capacidadelitros = 12.4,
                    Kmrodados = 30000,
                    Disponivel = false,
                    Preçodia = 170.00m,
                    Placa = "DEF-5678"
                }
            };
            return View(veiculos);
        }
    }
}
