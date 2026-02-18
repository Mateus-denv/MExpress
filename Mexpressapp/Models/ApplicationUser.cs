using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Mexpressapp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string NameCompleto { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime? DataNascimento { get; set; }
        [Required]
        public string Endereco { get; set; }

        [Required]
        public string CEP { get; set; }
        public bool Ativo { get; set; } = true;   // Controle de acesso
        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.Now; // Registro de data de cadastro

        [Required]
        public string CodigoValidacaoCNH { get; set; } // Codigo de validação da CNH (Carteira Nacional de Habilitação)

    }
}
