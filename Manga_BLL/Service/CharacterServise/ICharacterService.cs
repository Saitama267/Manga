using Manga_BLL.DTOs;
using Manga_BLL.Entities;

namespace Manga_BLL.Service.CharacterServise
{
    public interface ICharacterService
    {
        Task<List<CharacterDto>> GetAllCharacters(bool? isOngoing);
        Task<int> AddCharacter(Character character);
        Task<int> DeleteCharacter(int id);
        Task<int> UpdateCharacter(Character character);
    }
}
