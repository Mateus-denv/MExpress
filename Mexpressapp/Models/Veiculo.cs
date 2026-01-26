using System.ComponentModel.DataAnnotations;

namespace Mexpressapp.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Cilindrada { get; set; }

        [Required]
        public int Cavalos { get; set; }

        [Required]
        public double CapacidadeLitros { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int KmRodados { get; set; }

        public bool Disponivel { get; set; } = true;

        [Required]
        [Display(Name = "Preço por dia")]
        public decimal PrecoDia { get; set; }
        
        [Required]
        public string Placa { get; set; }
    }
}
