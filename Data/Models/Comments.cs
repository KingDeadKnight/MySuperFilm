using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySuperFilm.Data.Models
{
    [Table("Comment", Schema = "mySuperFilms")]
    public class Comments
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int FilmNodeId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
