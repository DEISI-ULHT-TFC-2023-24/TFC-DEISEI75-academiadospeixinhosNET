using System.ComponentModel.DataAnnotations;

namespace academiadospeixinhoscloud.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int VagasPreenchidas { get; set; }
        public int VagasTotal { get; set; }
        public string? Educadora { get; set; }
        public string? Auxiliar1 { get; set; }
        public string? Auxiliar2 { get; set; }
        public string? Auxiliar3 { get; set; }

        public List<string?> NomesSubscricoes { get; set; }
        public ICollection<Subscricao> Subscricoes { get; } = new List<Subscricao>();

    }
}
