using AutoMapper;
using LastBeer.Back.Models;
using LastBeer.Back.Models.Dtos.GameDtos;
using LastBeer.Back.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastBeer.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GamesController(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            var games = _gameRepository.GetGames();
            var gamesDto = _mapper.Map<IEnumerable<GameDto>>(games);
            return Ok(gamesDto);
        }

        [HttpGet("{gameId:int}", Name = "GetGame")]
        public IActionResult GetGame(int gameId)
        {
            var game = _gameRepository.GetGame(gameId);
            if (game == null)
            {
                return NotFound();
            }
            var gameDto = _mapper.Map<GameDto>(game);
            return Ok(gameDto);
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] GameInsertDto gameCreateDto)
        {
            if (gameCreateDto == null)
            {
                return BadRequest(ModelState);
            }

            var game = _mapper.Map<Game>(gameCreateDto);

            if (!_gameRepository.AddGame(game))
            {
                ModelState.AddModelError("", "Something went wrong while saving the record");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetGame", new { gameId = game.Id }, gameCreateDto);
        }

        [HttpPut("{gameId:int}")]
        public IActionResult UpdateGame(int gameId, [FromBody] GameDto gameUpdateDto)
        {
            if (gameUpdateDto == null || gameUpdateDto.Id != gameId)
            {
                return BadRequest(ModelState);
            }

            var game = _mapper.Map<Game>(gameUpdateDto);

            if (!_gameRepository.UpdateGame(game))
            {
                ModelState.AddModelError("", "Something went wrong while updating the record");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{gameId:int}")]
        public IActionResult DeleteGame(int gameId)
        {
            if (!_gameRepository.DeleteGame(gameId))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the record");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
