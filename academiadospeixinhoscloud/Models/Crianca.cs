using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace academiadospeixinhoscloud.Models
{
    public class Crianca
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string? NIS { get; set; }

        public string? NumeroUtente { get; set; }

        public string? SeguroSaude { get; set; }
        public string? Apolice { get; set; }
        public string? Seguradora { get; set; }
        public string? MoradaFiscal { get; set; }
        public string? Nacionalidade { get; set; }
        public int? QuantidadeAgregado { get; set; }
        public string? Autorizados { get; set; }
        public string? Doencas { get; set; }
        public string? NBI { get; set; }

        [DataType(DataType.Date)]
        public DateTime ValidadeBI { get; set; }

        // Navigation property for many-to-many relationship

        public List<string?> NomesAtividades { get; set; }
        public ICollection<Atividade> Atividades { get; } = new List<Atividade>();

        public List<string?> NomesPais { get; set; }
        public ICollection<Pai> Pais { get; } = new List<Pai>();

        public List<string?> NomesSubscricao { get; set; }
        public ICollection<Subscricao> Subscricaoes { get; } = new List<Subscricao>();

        public List<string?> NomesProduto { get; set; }
        public ICollection<Produto> Produtos { get; } = new List<Produto>();
    }
}
