using AutoMapper;
using Manga_BLL.DTOs;
using Manga_BLL.Entities;
using Manga_BLL.Repositories;

namespace Manga_BLL.Service.FeatureService
{
    public class FeatureService : IFeatureService
    {
        private readonly IMapper _autoMapper;
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IMapper autoMapper, IFeatureRepository featureRepository)
        {
            _autoMapper = autoMapper;
            _featureRepository = featureRepository;
        }
        public async Task<int> AddFeatureForCharacter(int characterId, Feature feature)
        {
            var result = await _featureRepository.AddFeatureForCharacter(characterId,feature);
            return result;
        }

        public async Task<List<FeatureDto>> GetAllFeatures(bool? dateAppearSorting)
        {
            var result = await _featureRepository.GetAllFeatures(dateAppearSorting);
            return _autoMapper.Map<List<FeatureDto>>(result);
        }

        public async Task<FeatureDto> GetFeatureByCharacterId(int characterId)
        {
            var result = await _featureRepository.GetFeatureByCharacterId(characterId);
            return _autoMapper.Map<FeatureDto>(result);
        }

        public async Task<bool> UdpateDisappearDate(int featureId, DateTime dissapearDate)
        {
            var result = await _featureRepository.UdpateDisappearDate(featureId, dissapearDate);
            return result;
        }
    }
}
