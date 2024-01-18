using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manga_BLL.Entities;
using Manga_BLL.Repositories;
using Manga_DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace Manga_DAL.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly MangaDbContext _dbContext;

        public FeatureRepository(MangaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddFeatureForCharacter(int characterId,Feature feature)
        {
            _dbContext.Features.Add(feature);
            await _dbContext.SaveChangesAsync();
            return feature.Id;
        }

        public async Task<List<Feature>> GetAllFeatures(bool? dateAppearSorting)
        {
            if (dateAppearSorting != null)
            {
                if (dateAppearSorting == true)
                {
                    return await _dbContext.Features.OrderByDescending(f=>f.DateAppear).ToListAsync();
                }
                return await _dbContext.Features.OrderBy(f => f.DateAppear).ToListAsync();
            }
            return await _dbContext.Features.ToListAsync();
        }

        public Task<Feature> GetFeatureByCharacterId(int characterId)
        {
            var feature = _dbContext.Features.FirstOrDefaultAsync(f => f.Character.Id == characterId);
            return feature;
        }

        public async Task<bool> UdpateDisappearDate(int featureId, DateTime disappearDate)
        {
            var feature = await _dbContext.Features.FirstOrDefaultAsync(f=>f.Id == featureId);
            feature.DateDisappear=disappearDate;
            return true;
        }
    }
}
