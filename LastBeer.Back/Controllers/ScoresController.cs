using AutoMapper;
using LastBeer.Back.Models.Dtos.ScoreDtos;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastBeer.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly IMapper _mapper;

        public ScoresController(IScoreRepository scoreRepository, IMapper mapper)
        {
            _scoreRepository = scoreRepository;
            _mapper = mapper;
        }

        [HttpGet("byUser/{userId:int}")]
        public IActionResult GetScoresByUserId(int userId)
        {
            var scores = _scoreRepository.GetScoresByUserId(userId);
            if (scores == null)
            {
                return NotFound();
            }
            var scoresDto = _mapper.Map<IEnumerable<ScoreDto>>(scores);
            return Ok(scoresDto);
        }

        [HttpGet("byUserAndGame/{userId:int}/{gameId:int}")]
        public IActionResult GetScoresByUserIdAndGameId(int userId, int gameId)
        {
            var scores = _scoreRepository.GetScoresByUserIdAndGameId(userId, gameId);
            if (scores == null)
            {
                return NotFound();
            }
            var scoresDto = _mapper.Map<IEnumerable<ScoreDto>>(scores);
            return Ok(scoresDto);
        }

        [HttpPost]
        public IActionResult AddScore([FromBody] ScoreInsertDto scoreCreateDto)
        {
            if (scoreCreateDto == null)
            {
                return BadRequest(ModelState);
            }

            var score = _mapper.Map<Score>(scoreCreateDto);

            if (!_scoreRepository.AddScore(score))
            {
                ModelState.AddModelError("", "Algo salió mal al añadir la puntuación");
                return StatusCode(500, ModelState);
            }

            return Ok(scoreCreateDto);
        }
    }
}
