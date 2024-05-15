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

        [HttpGet("userbyid/{userId:int}", Name = "GetUserById")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userRepository.GetById(userId);
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpGet("userfavourites/{userId:int}", Name = "GetUserFavourites")]
        public IActionResult GetUserFavourites(int userId)
        {
            var user = _userRepository.GetUserWithFavouriteBars(userId);
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpGet("uservisited/{userId:int}", Name = "GetUserVisited")]
        public IActionResult GetUserVisited(int userId)
        {
            var user = _userRepository.GetUserWithVisitedBars(userId);
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpGet("userscores/{userId:int}", Name = "GetUserScores")]
        public IActionResult GetUserScores(int userId)
        {
            var user = _userRepository.GetUserWithScores(userId);
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpGet("useralldata/{userId:int}", Name = "GetUserAllData")]
        public IActionResult GetUserAllData(int userId)
        {
            var user = _userRepository.GetUserWithAllData(userId);
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }





    }
}
