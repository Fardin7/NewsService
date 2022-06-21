using AutoMapper;
using NewsService.Dtos;
using NewsService.Model;

namespace NewsService.Mapper
{
    public class NewsMapper:Profile
    {
        public NewsMapper()
        {
            CreateMap<News, NewsRead>().ForMember(q => q.CategoryName, p => p.MapFrom(src => src.NewsCategory.Name));
            CreateMap<NewsCreate, News>();
            CreateMap<NewsCategoryCreate, NewsCategory>();
            CreateMap<NewsCategoryCreate, NewsCategoryRead>();

        }
    }
}
