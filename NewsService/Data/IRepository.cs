using NewsService.Dtos;

namespace NewsService.Data
{
    public interface IRepository
    {
        Task<NewsRead> Add(NewsCreate newsCategoryCreate,int categoryid);
        Task<NewsCategoryRead> AddNewsCategory(NewsCategoryCreate newsCategoryCreate);
        Task<NewsRead> GetByNewsId(int id);
        Task<IEnumerable<NewsRead>> GetByNewsIdAndCategoryId(int newsid,int categoryid);
        Task<IEnumerable<NewsRead>> Get();
    }
}
