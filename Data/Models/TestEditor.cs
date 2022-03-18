namespace MySuperFilm.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TestEditor", Schema = "dbo")]
    public class TestEditor
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }
}