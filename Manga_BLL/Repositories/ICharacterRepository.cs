using Manga_BLL.Entities;

namespace Manga_BLL.Repository.CharacterRepository
{
    public interface ICharacterRepository
    {
        Task<List<Character>> GetAllCharacters();
        Task<List<Character>> GetAllOngoingCharacters(bool isOngoing);
        Task<int> AddCharacter(Character character);
        Task<int> DeleteCharacter(int id);
        Task<int> UpdateCharacter(Character character);
    }
}
