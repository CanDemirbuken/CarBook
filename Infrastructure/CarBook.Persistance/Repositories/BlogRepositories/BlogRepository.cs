using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public Task<List<Blog>> GetLastThreeBlogWithAuthorAsync()
        {
            var blogs = _context.Blogs.Include(x => x.Author).Take(3).OrderByDescending(x => x.BlogID).ToListAsync();
            return blogs;
        }
    }
}
