using System.Threading.Tasks;
using AutoMapper;
using Contract.Messages;
using MassTransit;
using NewsService.Data;

namespace NewsService.Consumer
{
    public class CategoryDeleteConsumer : IConsumer<NewsCategoryDelete>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly IMapper _mapper;

        public CategoryDeleteConsumer(INewsCategoryRepository newsCategoryRepository, IMapper mapper)
        {
            _newsCategoryRepository = newsCategoryRepository;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<NewsCategoryDelete> context)
        {
            var message = context.Message;

            var item = await _newsCategoryRepository.GetById(message.Id);

            if (item == null)
            {
                return;
            }

             _newsCategoryRepository.Remove(message);
        }
    }
}