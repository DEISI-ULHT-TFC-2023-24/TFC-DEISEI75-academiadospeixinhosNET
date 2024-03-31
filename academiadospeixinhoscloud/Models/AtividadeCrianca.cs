using Azure;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace academiadospeixinhoscloud.Models
{
    public class AtividadeCrianca
    {   
        public int AtividadesId { get; set; }

        public int CriancasId { get; set; }
        public Atividade Atividade { get; set; } = null!;
        public Crianca Crianca { get; set; } = null!;
    }
}
