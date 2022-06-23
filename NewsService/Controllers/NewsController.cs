using Microsoft.AspNetCore.Mvc;
using NewsService.Data;
using NewsService.Dtos;
using Contract.Messages;

namespace NewsService.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly IRepository _repository;
        public static int RequestCount { get; set; }

        public NewsController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Add(NewsCreate newsCreate)
        {

           var news= await _repository.Add(newsCreate);

            return Ok(news);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Get());
        }
    }
}
