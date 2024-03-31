using System.ComponentModel.DataAnnotations;

namespace academiadospeixinhoscloud.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data{ get; set; }
        public int Preco { get; set; }
        public string? Professor { get; set; }
        public int Index { get; set; }

        public List<string?> NomesSalas { get; set; }
        public ICollection<Sala> Salas { get; } = new List<Sala>();
    }
}
