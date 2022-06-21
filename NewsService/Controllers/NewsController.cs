using Microsoft.AspNetCore.Mvc;
using NewsService.Data;
using NewsService.Dtos;

namespace NewsService.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly IRepository _repository;

        public NewsController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewsCategory(NewsCategoryCreate newsCategoryCreate)
        {
         var newscategory=await _repository.AddNewsCategory(newsCategoryCreate);

           return  Ok(newscategory);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Get());
        }
    }
}
