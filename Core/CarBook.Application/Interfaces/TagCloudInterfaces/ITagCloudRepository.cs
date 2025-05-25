using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRepository
    {
        Task<List<TagCloud>> GetTagCloudsByBlogIdAsync(int id);
    }
}
