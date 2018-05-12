using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using City.Api.Models.DTOs;
using City.Api.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace City.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : ControllerBase
    {
        public ITownRepository Repository { get; }

        public TownController(ITownRepository repository)
        {
            Repository = repository;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TownNoSightsDto>>> Get()
        {
            var towns = await Repository.GetTownsAsync();
            var townNoSightsDto = Mapper.Map<IEnumerable<TownNoSightsDto>>(towns);
            return Ok(townNoSightsDto);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TownDto>> Get(Guid id, bool includeSights)
        {
            if (id == null) return BadRequest();

            var town = await Repository.GetTownAsync(id, includeSights);

            if (town == null) return NotFound();

            if (includeSights)
            {
                var townDto = Mapper.Map<TownDto>(town);
                return Ok(townDto);
            }

            var townNoSightDto = Mapper.Map<TownNoSightsDto>(town);

            return Ok(townNoSightDto);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
