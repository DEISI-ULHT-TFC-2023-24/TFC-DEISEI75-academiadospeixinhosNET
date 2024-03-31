using Azure;
using Microsoft.Extensions.Hosting;

namespace academiadospeixinhoscloud.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int Preco { get; set; }
        public Boolean Valida { get; set; }
        public string? Professor { get; set; }
        public string? Auxiliar { get; set; }
        public ICollection<Crianca> Criancas { get; } = new List<Crianca>();
    }
}
