namespace MySuperFilm.ViewModels.Surface
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class CreateCommentModel
    {
        [Required]
        public string Comment { get; set; }

        [HiddenInput]
        public int FilmNodeId { get; set; }

        [HiddenInput]
        public int MemberId { get; set; }
    }
}