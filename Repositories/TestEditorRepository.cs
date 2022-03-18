namespace MySuperFilm.Repositories
{
    using System.Collections;
    using System.Collections.Generic;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class TestEditorRepository
    {
        private readonly DataContext _context;

        public TestEditorRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TestEditor> GetAll()
            => this._context.TestEditors.AsNoTracking();

    }
}