using Manga_BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga_BLL.Repositories
{
    public interface IFeatureRepository
    {
        Task<List<Feature>> GetAllFeatures(bool? dateAppearSorting);
        Task<Feature> GetFeatureByCharacterId(int characterId);
        Task<int> AddFeatureForCharacter(int characterId, Feature feature);
        Task<bool> UdpateDisappearDate(int featureId, DateTime disappearDate);
    }
}
