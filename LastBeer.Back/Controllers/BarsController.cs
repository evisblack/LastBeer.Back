using AutoMapper;
using LastBeer.Back.Models.Dtos.BarDtos;
using LastBeer.Back.Models;
using LastBeer.Back.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastBeer.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarsController : ControllerBase
    {
        private readonly IBarRepository _barRepository;
        private readonly IMapper _mapper;

        public BarsController(IMapper mapper, IBarRepository barRepository)
        {
            _mapper = mapper;
            _barRepository = barRepository;
        }

        [HttpGet]
        public IActionResult GetBars()
        {
            var bars = _barRepository.GetBars();
            var mappedBars = _mapper.Map<IEnumerable<BarDto>>(bars);
            return Ok(mappedBars);
        }

        [HttpGet("{id:int}", Name = "GetBarById")]
        public IActionResult GetBarById(int id)
        {
            var bar = _barRepository.GetById(id);
            if (bar == null)
            {
                return NotFound();
            }
            var mappedBar = _mapper.Map<BarDto>(bar);
            return Ok(mappedBar);
        }

        [HttpPost]
        public IActionResult AddBar([FromBody] BarInsertDto barDto)
        {
            if (barDto == null)
            {
                return BadRequest(ModelState);
            }

            var bar = _mapper.Map<Bar>(barDto);
            if (!_barRepository.AddBar(bar))
            {
                ModelState.AddModelError("", "Something went wrong while adding the bar");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetBarById", new { id = bar.Id }, bar);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBar(int id, [FromBody] BarDto barDto)
        {
            if (barDto == null || barDto.Id != id)
            {
                return BadRequest(ModelState);
            }

            var bar = _mapper.Map<Bar>(barDto);
            if (!_barRepository.UpdateBar(bar))
            {
                ModelState.AddModelError("", "Something went wrong while updating the bar");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBar(int id)
        {
            if (!_barRepository.DeleteBar(id))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the bar");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }

}
