using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLastThreeBlogWithAuthorAsync();
        Task<List<Blog>> GetBlogsWithAuthorAsync();
        Task<List<Blog>> GetBlogByAuthorIdAsync(int id);
    }
}
