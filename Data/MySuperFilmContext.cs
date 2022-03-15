using System.Data.Entity;

namespace MySuperFilm.Data
{
    public class MySuperFilmContext : DbContext
    {
        public MySuperFilmContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<Data.Models.Comments> Comments { get; set; }
    }
}
