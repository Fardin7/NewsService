using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsService.Dtos;
using NewsService.Model;

namespace NewsService.Data
{
    public class NewsRepository : IRepository
    {
        private readonly AppDBContext  _appDBContext;
        private readonly IMapper _mapper;

        public NewsRepository(AppDBContext appDBContext,IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }
        public Task<NewsRead> Add(NewsCreate newsCategoryCreate, int categoryid)
        {
            throw new NotImplementedException();
        }

        public async Task<NewsCategoryRead> AddNewsCategory(NewsCategoryCreate newsCategoryCreate)
        {
           await _appDBContext.NewsCategories.AddAsync(_mapper.Map<NewsCategory>(newsCategoryCreate));
           await _appDBContext.SaveChangesAsync();
            return _mapper.Map<NewsCategoryRead>(newsCategoryCreate);
        }
        
        public async Task<IEnumerable<NewsRead>> Get()
        {
            var news = await _appDBContext.News.ToListAsync();

            var result = new List<NewsRead>();
            news.ForEach(q =>
            {
                result.Add(_mapper.Map<NewsRead>(q));
            });

            return result;
        }

        public Task<NewsRead> GetByNewsId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NewsRead>> GetByNewsIdAndCategoryId(int newsid, int categoryid)
        {
            throw new NotImplementedException();
        }
    }
}
