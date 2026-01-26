using System.ComponentModel.DataAnnotations;

namespace Mexpressapp.Models
{
    public class Veiculo
    {
        public string Id { get; set; }
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Cinlidrada { get; set; }

        [Required]
        public int Cavalos { get; set; }

        [Required]
        public double Capacidadelitros { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public double Kmrodados { get; set; }

        public bool Disponivel { get; set; } = true;

        [Required]
        [Display(Name = "Preço por dia")]
        public decimal Preçodia { get; set; }
        
        [Required]
        public string Placa { get; set; }
    }
}
