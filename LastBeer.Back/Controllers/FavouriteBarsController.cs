using AutoMapper;
using LastBeer.Back.Models;
using LastBeer.Back.Models.Dtos.BarDtos;
using LastBeer.Back.Models.Dtos.FavouriteBarDtos;
using LastBeer.Back.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastBeer.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteBarsController : ControllerBase
    {
        private readonly IFavouriteBarRepository _favouriteBarRepository;
        private readonly IMapper _mapper;

        public FavouriteBarsController(IMapper mapper, IFavouriteBarRepository favouriteBarRepository)
        {
            _mapper = mapper;
            _favouriteBarRepository = favouriteBarRepository;
        }

        [HttpPost("addFavouriteBar")]
        public IActionResult AddFavouriteBar([FromBody] BarFavouriteInsertDto barDto)
        {
            var bar = _mapper.Map<Bar>(barDto);
            bool result = _favouriteBarRepository.AddFavouriteBar(barDto.UserId, bar);

            if (result)
            {
                return Ok(new { message = "Bar added to favourites successfully." });
            }
            else
            {
                return BadRequest(new { message = "Bar is already in favourites." });
            }
        }

        [HttpDelete("removeFavouriteBar")]
        public IActionResult RemoveFavouriteBar(int userId, int barId)
        {
            bool result = _favouriteBarRepository.RemoveFavouriteBar(userId, barId);

            if (result)
            {
                return Ok(new { message = "Bar removed from favourites successfully." });
            }
            else
            {
                return NotFound(new { message = "Favourite bar not found." });
            }
        }

        [HttpGet("getFavouriteBarsByUserId")]
        public IActionResult GetFavouriteBarsByUserId(int userId)
        {
            var favourites = _favouriteBarRepository.GetFavouriteBarsByUserId(userId);
            var mappedFavourites = _mapper.Map<IEnumerable<FavouriteBarDto>>(favourites);
            return Ok(mappedFavourites);
        }
    }


}
