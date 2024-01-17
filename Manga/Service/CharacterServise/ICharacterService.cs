using Manga.DTOs;
using Manga.Models;

namespace Manga.Service.CharacterServise
{
    public interface ICharacterService
    {
        Task<List<CharacterDto>> GetAllCharacters();
        Task<List<CharacterDto>> GetAllOngoingCharacters(bool isOngoing);
        Task<int> AddCharacter(Character character);
        Task<int> DeleteCharacter(int id);
        Task<int> UpdateCharacter(Character character);
    }
}
