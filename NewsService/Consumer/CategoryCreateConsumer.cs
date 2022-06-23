using AutoMapper;
using MassTransit;
using NewsService.Data;
using NewsService.Dtos;
using Contract.Messages;

namespace NewsService.Consumer
{
    public class CategoryCreateConsumer : IConsumer<NewsCategoryCreate>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly IMapper _mapper;

        public CategoryCreateConsumer(INewsCategoryRepository newsCategoryRepository,IMapper mapper)
        {
            _newsCategoryRepository = newsCategoryRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<NewsCategoryCreate> context)
        {

            var message = context.Message;

            var item = await _newsCategoryRepository.GetById(message.Id);

            if (item != null)
            {
                return;
            }
           await _newsCategoryRepository.Add(message);
        }
    }
}
