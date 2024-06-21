using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using academiadospeixinhoscloud.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace academiadospeixinhoscloud.Data
{
    public class academiadospeixinhoscloudContext : IdentityDbContext<IdentityUser>
    {
        public academiadospeixinhoscloudContext(DbContextOptions<academiadospeixinhoscloudContext> options)
            : base(options)
        {
        }

        public DbSet<academiadospeixinhoscloud.Models.Atividade> Atividade { get; set; } = default!;
        public DbSet<academiadospeixinhoscloud.Models.Crianca> Crianca { get; set; } = default!;
        public DbSet<academiadospeixinhoscloud.Models.Pai> Pai { get; set; } = default!;
        public DbSet<academiadospeixinhoscloud.Models.Subscricao> Subscricao { get; set; } = default!;
        public DbSet<academiadospeixinhoscloud.Models.Produto> Produto { get; set; } = default!;
        public DbSet<academiadospeixinhoscloud.Models.Sala> Sala { get; set; } = default!;
        public DbSet<academiadospeixinhoscloud.Models.Evento> Evento { get; set; } = default!;
        public DbSet<academiadospeixinhoscloud.Models.Ementa> Ementa { get; set; } = default!;




    }
}
