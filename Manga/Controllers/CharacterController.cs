using AutoMapper;
using Manga.Models;
using Manga.Service.CharacterServise;
using Manga.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IMapper _autoMapper;
        private readonly ICharacterService _characterService;

        public CharacterController(IMapper autoMapper, ICharacterService characterService)
        {
            _autoMapper = autoMapper;
            _characterService = characterService;
        }

        [HttpGet("characters")]
        public async Task<ActionResult<List<CharacterViewModel>>> GetAllCharacters()
        {
            var result = await _characterService.GetAllCharacters();
            return _autoMapper.Map<List<CharacterViewModel>>(result);
        }

        [HttpGet("filtered")]
        public async Task<ActionResult<List<CharacterViewModel>>> GetAllCharacterByOngoing(bool isOngoing)
        {
            var result = await _characterService.GetAllOngoingCharacters(isOngoing);
            return _autoMapper.Map<List<CharacterViewModel>>(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddCharacter([FromForm] AddCharacterViewModel addCharacterViewModel)
        {
            var character = _autoMapper.Map<Character>(addCharacterViewModel);
            var result = await _characterService.AddCharacter(character);
            return Ok($"Character with id({result}) added!");
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteCharacter(int id)
        {
            var characterId = await _characterService.DeleteCharacter(id);
            if (characterId != 0)
            {
                return Ok($"Character with id({characterId}) deleted!");
            }
            return BadRequest();

        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateCharacter([FromForm] EditCharacterViewModel editCharacterViewModel)
        {
            var character = _autoMapper.Map<Character>(editCharacterViewModel);
            var characterId = await _characterService.UpdateCharacter(character);
            if (characterId != 0)
            {
                return Ok($"Character with id({characterId}) deleted!");
            }
            return BadRequest();
        }

    }
}
