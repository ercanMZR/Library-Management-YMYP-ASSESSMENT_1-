using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YMYP_ASSESSMENT_1.Models.Repositories.Configurations;

namespace YMYP_ASSESSMENT_1.Models.Repositories.Entities
{
   
   
        public class AppDbContext(DbContextOptions<AppDbContext>options):DbContext(options)
        {
            public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }

    
}
