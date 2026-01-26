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
                    Id = 1,
                    Marca = "Toyota",
                    Modelo = "Corolla",
                    Cilindrada = 1800,
                    Ano = 2020,
                    Cavalos = 140,
                    CapacidadeLitros = 13.2,
                    KmRodados = 50000,
                    Disponivel = true,
                    PrecoDia = 150.00m,
                    Placa = "ABC-1234"
                },
                new Veiculo
                {
                    Id = 2,
                    Marca = "Honda",
                    Modelo = "Civic",
                    Ano = 2019,
                    Cilindrada = 2000,
                    Cavalos = 158,
                    CapacidadeLitros = 12.4,
                    KmRodados = 30000,
                    Disponivel = true,
                    PrecoDia = 170.00m,
                    Placa = "DEF-5678"
                }
            };
            var veiculosDisponiveis = veiculos.Where(v => v.Disponivel).ToList();
            return View(veiculosDisponiveis);
        }
    }
}
