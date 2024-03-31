using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace academiadospeixinhoscloud.Models
{
    public class Pai
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string? NIS { get; set; }

        public string? NumeroUtente { get; set; }
        public string? MoradaFiscal { get; set; }
        public string? NBI { get; set; }

        [DataType(DataType.Date)]
        public DateTime ValidadeBI { get; set; }

        public string? Email { get; set; }

        public string? Telefone1 { get; set; }

        public string? Telefone2 { get; set; }

        // Navigation property for many-to-many relationship

        public List<string?> NomesCriancas { get; set; }
        public ICollection<Crianca> Criancas { get; } = new List<Crianca>();

        public static implicit operator Pai(SelectList v)
        {
            throw new NotImplementedException();
        }
    }
}
