
using Manga.Models;
using Microsoft.EntityFrameworkCore;

namespace Manga.Repository.CharacterRepository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly MangaDbContext _dbContext;

        public CharacterRepository(MangaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddCharacter(Character character)
        {
            _dbContext.Characters.Add(character);
            await _dbContext.SaveChangesAsync();
            return character.Id;
        }

        public async Task<int> DeleteCharacter(int id)
        {
            var product = await _dbContext.Characters.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (product != null)
            {
                _dbContext.Characters.Remove(product);
                await _dbContext.SaveChangesAsync();
                return product.Id;
            }
            return 0;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return await _dbContext.Characters.ToListAsync();
        }

        public async Task<List<Character>> GetAllOngoingCharacters(bool isOngoing)
        {
            return await _dbContext.Characters.Where(c => c.IsOngoing == isOngoing).ToListAsync();
        }

        public async Task<int> UpdateCharacter(Character character)
        {
            var updateCharacter = await _dbContext.Characters.Where(c => c.Id == character.Id).FirstAsync();

            foreach (var toCharacter in typeof(Character).GetProperties())
            {
                var fromCharacter = typeof(Character).GetProperty(toCharacter.Name);
                var value = fromCharacter.GetValue(character, null);
                if (value != null)
                {
                    toCharacter.SetValue(updateCharacter, value, null);
                }

            }

            await _dbContext.SaveChangesAsync();
            return character.Id;
        }
    }
}
