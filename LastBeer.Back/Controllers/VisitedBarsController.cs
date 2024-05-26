using AutoMapper;
using LastBeer.Back.Models.Dtos.BarDtos;
using LastBeer.Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LastBeer.Back.Models.Dtos.VisitedBarDtos;
using LastBeer.Back.Repository.IRepository;

namespace LastBeer.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitedBarsController : ControllerBase
    {
        private readonly IVisitedBarRepository _visitedBarRepository;
        private readonly IMapper _mapper;

        public VisitedBarsController(IMapper mapper, IVisitedBarRepository visitedBarRepository)
        {
            _mapper = mapper;
            _visitedBarRepository = visitedBarRepository;
        }

        [HttpPost("addOrUpdateVisitedBar")]
        public IActionResult AddOrUpdateVisitedBar(int userId, BarDto barDto)
        {
            var bar = _mapper.Map<Bar>(barDto);
            bool result = _visitedBarRepository.AddOrUpdateVisitedBar(userId, bar);

            if (result)
            {
                return Ok(new { message = "Bar visited or updated successfully." });
            }
            else
            {
                return BadRequest(new { message = "Error adding or updating visited bar." });
            }
        }

        [HttpDelete("removeVisitedBar")]
        public IActionResult RemoveVisitedBar(int userId, int barId)
        {
            bool result = _visitedBarRepository.RemoveVisitedBar(userId, barId);

            if (result)
            {
                return Ok(new { message = "Bar removed from visited successfully." });
            }
            else
            {
                return NotFound(new { message = "Visited bar not found." });
            }
        }

        [HttpGet("getVisitedBarsByUserId")]
        public IActionResult GetVisitedBarsByUserId(int userId)
        {
            var visitedBars = _visitedBarRepository.GetVisitedBarsByUserId(userId);
            var mappedVisitedBars = _mapper.Map<IEnumerable<VisitedBarDto>>(visitedBars);
            return Ok(mappedVisitedBars);
        }
    }

}
