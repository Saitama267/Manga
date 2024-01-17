using Manga.Models;

namespace Manga.Repository.CharacterRepository
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
