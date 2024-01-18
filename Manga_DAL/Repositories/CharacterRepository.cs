using Manga_BLL.Entities;
using Manga_BLL.Repository;
using Manga_DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace Manga_DAL.Repositories
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
            var product = await _dbContext.Characters.FirstOrDefaultAsync(c => c.Id == id);
            if (product != null)
            {
                _dbContext.Characters.Remove(product);
                await _dbContext.SaveChangesAsync();
                return product.Id;
            }
            return 0;
        }

        public async Task<List<Character>> GetAllCharacters(bool? isOngoing)
        {
            if (isOngoing!=null)
            {
                return await _dbContext.Characters.Where(c => c.IsOngoing == isOngoing).ToListAsync();
            }
            return await _dbContext.Characters.ToListAsync();
        }


        public async Task<int> UpdateCharacter(Character character)
        {
            if (character is null )
            {
                throw new ArgumentNullException();
            }
            var updateCharacter = await _dbContext.Characters.SingleAsync(c => c.Id == character.Id);

            updateCharacter.IsOngoing = character.IsOngoing; 
            updateCharacter.MangaGenre = character.MangaGenre;
            updateCharacter.Name = character.Name;  
            updateCharacter.Author = character.Author;
            updateCharacter.Feature = character.Feature;

            await _dbContext.SaveChangesAsync();
            return character.Id;
        }
    }
}
