using AutoMapper;
using Manga.DTOs;
using Manga.Models;
using Manga.Repository.CharacterRepository;

namespace Manga.Service.CharacterServise
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _autoMapper;
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(IMapper autoMapper, ICharacterRepository characterRepository)
        {
            _autoMapper = autoMapper;
            _characterRepository = characterRepository;
        }
        public async Task<int> AddCharacter(Character character)
        {
            var addedCharacterId = await _characterRepository.AddCharacter(character);
            return addedCharacterId != 0 ? addedCharacterId : 0;
        }

        public async Task<int> DeleteCharacter(int id)
        {
            return await _characterRepository.DeleteCharacter(id);
        }

        public async Task<List<CharacterDto>> GetAllCharacters()
        {
            var result = await _characterRepository.GetAllCharacters();
            return _autoMapper.Map<List<CharacterDto>>(result);
        }

        public async Task<List<CharacterDto>> GetAllOngoingCharacters(bool isOngoing)
        {
            var result = await _characterRepository.GetAllOngoingCharacters(isOngoing);
            return _autoMapper.Map<List<CharacterDto>>(result);
        }

        public async Task<int> UpdateCharacter(Character character)
        {
            return await _characterRepository.UpdateCharacter(character);
        }
    }
}
