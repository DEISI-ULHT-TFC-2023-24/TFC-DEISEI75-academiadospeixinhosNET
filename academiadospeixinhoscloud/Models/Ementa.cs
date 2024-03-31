using System.ComponentModel.DataAnnotations;

namespace academiadospeixinhoscloud.Models
{
    public class Ementa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Valida { get; set; }
        public List<string?> NomesSalas { get; set; }
        public ICollection<Sala> Salas { get; } = new List<Sala>();

    }
}
