using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using City.Api.Models.DTOs;
using City.Api.Models.Entities;
using City.Api.Services.EmailServices;
using City.Api.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace City.Api.Controllers
{
    [Route("api/town/{townId}/sights")]
    [ApiController]
    public class SightController : ControllerBase
    {
        public ISightRepository Repository { get; }
        public ILogger<SightController> Logger { get; }
        public IMailService MailService { get; }

        public SightController(ISightRepository repository, ILogger<SightController> logger, IMailService mailService)
        {
            Repository = repository;
            Logger = logger;
            MailService = mailService;
        }
        // GET api/values
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<SightDto>>> Get(Guid townId)
        {
            if (townId == null) return BadRequest();
            var sights = await Repository.GetSightsAsync(townId);
            if (sights == null) return NotFound();
            var sightsDto = Mapper.Map<IEnumerable<SightDto>>(sights);
            return Ok(sightsDto);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSight")]
        public async Task<ActionResult<SightDto>> Get(Guid townId, Guid id)
        {
            if (townId == null || id == null)
                return BadRequest();

            var sight = await Repository.GetSightAsync(townId, id);

            if (sight == null)
                return NotFound();

            var sightDto = Mapper.Map<SightDto>(sight);

            return Ok(sightDto);
        }

        // POST api/values
        [HttpPost()]
        public async Task<ActionResult> Post(Guid townId, [FromBody] SightCreateDto sightCreateDto)
        {
            if (townId == null || sightCreateDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sight = Mapper.Map<Sight>(sightCreateDto);

            await Repository.CreateSightAsync(townId, sight);

            await MailService.SendEmailAsync("Sight Created!", $"Sight {sight.Name} with id {sight.Id} was created");

            var sightDto = Mapper.Map<SightDto>(sight);

            return CreatedAtRoute("GetSight", new { townId, id = sightDto.Id }, sightDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid townId, Guid id, [FromBody] SightUpdateDto sightUpdateDto)
        {
            // null check
            if (townId == null || id == null || sightUpdateDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            // retrieve the sight
            var sight = await Repository.GetSightAsync(townId, id);

            if (sight == null)
                return NotFound();

            Mapper.Map(sightUpdateDto, sight);

            // call the repository
            await Repository.UpdateSightAsync(sight);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
