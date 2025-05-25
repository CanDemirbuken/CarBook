using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _context;

        public TagCloudRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogIdAsync(int id)
        {
            var tagClouds = await _context.TagClouds.Where(tc => tc.BlogID == id).ToListAsync();
            return tagClouds;
        }
    }
}
