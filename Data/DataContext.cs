namespace MySuperFilm.Data
{
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Data.Models.Comment> Comments { get; set; }
    }
}