using System.ComponentModel.DataAnnotations;

namespace academiadospeixinhoscloud.Models
{
    public class Subscricao
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Preco { get; set; }
        public Boolean Valida { get; set; }
        public string? Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicio{ get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        public List<string?> NomesCriancas { get; set; }
        public ICollection<Crianca> Criancas { get; } = new List<Crianca>();

        public List<string?> NomesSalas { get; set; }
        public ICollection<Sala> Salas { get; } = new List<Sala>();

    }
}
