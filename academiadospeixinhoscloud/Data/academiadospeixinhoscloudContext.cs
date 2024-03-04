using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using academiadospeixinhoscloud.Models;

namespace academiadospeixinhoscloud.Data
{
    public class academiadospeixinhoscloudContext : DbContext
    {
        public academiadospeixinhoscloudContext (DbContextOptions<academiadospeixinhoscloudContext> options)
            : base(options)
        {
        }

        public DbSet<academiadospeixinhoscloud.Models.Movie> Movie { get; set; } = default!;
    }
}
