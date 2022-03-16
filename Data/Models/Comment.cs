namespace MySuperFilm.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comment", Schema = "mySuperFilm")]
    public class Comment
    {
        public int Id { get; set; }

        public int FilmNodeId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}