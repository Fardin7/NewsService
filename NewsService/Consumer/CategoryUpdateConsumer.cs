using System.Threading.Tasks;
using AutoMapper;
using Contract.Messages;
using MassTransit;
using NewsService.Data;


namespace NewsService.Consumer
{
    public class CategoryUpdateConsumer : IConsumer<NewsCategoryUpdate>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly IMapper _mapper;

        public CategoryUpdateConsumer(INewsCategoryRepository newsCategoryRepository, IMapper mapper)
        {
            _newsCategoryRepository = newsCategoryRepository;
            _mapper = mapper;
        }


        public async Task Consume(ConsumeContext<NewsCategoryUpdate> context)
        {
            var message = context.Message;

            var item = await _newsCategoryRepository.GetById(message.Id);

            if (item == null)
            {
                await _newsCategoryRepository.Add(_mapper.Map<NewsCategoryCreate>(context));
            }
            else
            {
                await _newsCategoryRepository.Update(message);
            }
        }
    }
}