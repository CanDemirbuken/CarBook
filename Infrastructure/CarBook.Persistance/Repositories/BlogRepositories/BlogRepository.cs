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

        public async Task<List<Blog>> GetBlogByAuthorIdAsync(int id)
        {
            var blog = await _context.Blogs.Include(x => x.Author).Where(y => y.BlogID == id).ToListAsync();
            return blog;
        }

        public async Task<List<Blog>> GetBlogsWithAuthorAsync()
        {
            var blogs = await _context.Blogs.Include(x => x.Author).ToListAsync();
            return blogs;
        }

        public async Task<List<Blog>> GetLastThreeBlogWithAuthorAsync()
        {
            var blogs = await _context.Blogs.Include(x => x.Author).Take(3).OrderByDescending(x => x.BlogID).ToListAsync();
            return blogs;
        }
    }
}
