using Manga_BLL.DTOs;
using Manga_BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga_BLL.Service.FeatureService
{
    public interface IFeatureService
    {
        Task<List<FeatureDto>> GetAllFeatures(bool? dateAppearSorting);
        Task<FeatureDto> GetFeatureByCharacterId(int characterId);
        Task<int> AddFeatureForCharacter(int characterId,Feature feature);
        Task<bool> UdpateDisappearDate(int featureId, DateTime disappearDate);
    }
}
