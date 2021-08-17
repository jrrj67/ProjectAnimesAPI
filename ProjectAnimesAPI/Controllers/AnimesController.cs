using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAnimesAPI.Data;
using ProjectAnimesAPI.Data.Exceptions;
using ProjectAnimesAPI.Data.Interfaces;
using ProjectAnimesAPI.Data.Mappings;
using ProjectAnimesAPI.Models;

namespace ProjectAnimesAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AnimesController : ControllerBase
    {
        private readonly IAnimesRepository _repository;

        public AnimesController(IAnimesRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animes = await _repository.GetAll();
            return Ok(new AnimeMapping(animes).Collect());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AnimeDTO anime)
        {
            var animeInstance = new Anime()
            {
                Name = anime.Name,
            };

            try
            {
                var createdAnime = await _repository.Create(animeInstance);
                return Ok(new AnimeMapping(createdAnime));
            }
            catch (Exception e)
            {
                return BadRequest(new ExceptionResponse(e.Message, e.Data["Errors"]));
            }
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(AnimeDTO anime, int id)
        {
            var animeInstance = new Anime()
            {
                Name = anime.Name,
            };

            try
            {
                var updatedAnime = await _repository.Update(animeInstance, id);
                return Ok(new AnimeMapping(updatedAnime));
            }
            catch (NotFoundException e)
            {
                return NotFound(new ExceptionResponse(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(new ExceptionResponse(e.Message, e.Data["Errors"]));
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedAnime = await _repository.Delete(id);
                return Ok(new AnimeMapping(deletedAnime));
            }
            catch (NotFoundException e)
            {
                return NotFound(new ExceptionResponse(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(new ExceptionResponse(e.Message, e.Data["Errors"]));
            }
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var anime = await _repository.GetById(id);
                return Ok(new AnimeMapping(anime));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(new ExceptionResponse(e.Message, e.Data["Errors"]));
            }
        }
    }
}