namespace ColourApi.Models
{
    using Microsoft.EntityFrameworkCore;
    
    public class ColourContext : DbContext
    {
        public ColourContext()
        {
        }

        public ColourContext(DbContextOptions<ColourContext> options) : base(options)
        {
        }

        public virtual DbSet<Colour> ColourItems {get; set;}
    }
}