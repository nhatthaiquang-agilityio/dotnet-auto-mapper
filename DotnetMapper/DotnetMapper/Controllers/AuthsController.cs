using AutoMapper;
using DotnetMapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AuthsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("getauthor")]
        public ActionResult<Author> Get()
        {
            var entity = new AuthorDTO
            {
                Address = "Nui Thanh",
                FirstName = "Nhat",
                LastName = "Thai",
                Id = 1
            };

            return Ok(_mapper.Map<Author>(entity));
        }
    }
}
