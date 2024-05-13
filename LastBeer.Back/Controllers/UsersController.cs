using AutoMapper;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastBeer.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var list = _userRepository.GetUsers();
            var mapped = _mapper.Map<IEnumerable<UserDto>>(list);
            return Ok(mapped);
        }

    }
}
