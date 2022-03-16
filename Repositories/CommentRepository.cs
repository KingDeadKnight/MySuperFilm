namespace MySuperFilm.Repositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using ViewModels.DocumentTypes;
    using ViewModels.Surface;

    public class CommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateCommentModel createCommentModel)
        {
            var dbEntity = new Comment
                           {
                               Text = createCommentModel.Comment,
                               CreatedDate = DateTime.Now,
                               FilmNodeId = createCommentModel.FilmNodeId
                           };

            this._context.Comments.Add(dbEntity);
            await this._context.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetCommentsByFilm(int filmNodeId)
            => this._context.Comments
                   .Where(c => c.FilmNodeId == filmNodeId);
    }
}