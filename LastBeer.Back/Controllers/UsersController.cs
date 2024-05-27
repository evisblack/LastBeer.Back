using AutoMapper;
using LastBeer.Back.Models;
using LastBeer.Back.Models.Dtos.UserDtos;
using LastBeer.Back.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Net;

namespace LastBeer.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        protected APIResponse _apiResponse;
        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            this._apiResponse = new();
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
            if (user == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpGet("userfavouritesbars/{userId:int}", Name = "GetUserFavourites")]
        public IActionResult GetUserFavourites(int userId)
        {
            var user = _userRepository.GetUserWithFavouriteBars(userId);
            if(user == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpGet("uservisitedbars/{userId:int}", Name = "GetUserVisited")]
        public IActionResult GetUserVisited(int userId)
        {
            var user = _userRepository.GetUserWithVisitedBars(userId);
            if (user == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpGet("userscores/{userId:int}", Name = "GetUserScores")]
        public IActionResult GetUserScores(int userId)
        {
            var user = _userRepository.GetUserWithScores(userId);
            if (user == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpGet("useralldata/{userId:int}", Name = "GetUserAllData")]
        public IActionResult GetUserAllData(int userId)
        {
            var user = _userRepository.GetUserWithAllData(userId);
            if (user == null)
            {
                return NotFound();
            }
            var mapped = _mapper.Map<UserDto>(user);
            return Ok(mapped);
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] UserInsertDto userInsertDto)
        {
            bool userExists = _userRepository.UserExists(userInsertDto.UserName);
            if(userExists)
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("El nombre de usuario ya existe");
                return BadRequest();
            }

            var  user = await _userRepository.Registration(userInsertDto);
            if (user == null)
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Error en el registro");
                return BadRequest();
            }

            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;

            return Ok(_apiResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var responseLogin = await _userRepository.Login(userLoginDto);

            if (responseLogin.User == null || string.IsNullOrEmpty(responseLogin.Token))
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("El nombre de usuario / password son incorrectos");
                return BadRequest();
            }

            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = responseLogin;

            return Ok(_apiResponse);
        }

        [HttpPut("{userId:int}")]
        public IActionResult UpdateUser(int userId, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (userUpdateDto == null || userId != userUpdateDto.Id)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(userUpdateDto);

            if (!_userRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", "Algo salió mal al actualizar el usuario");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{userId:int}")]
        public IActionResult DeleteUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }

            if (!_userRepository.DeleteUser(user))
            {
                ModelState.AddModelError("", "Algo salió mal al eliminar el usuario");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
