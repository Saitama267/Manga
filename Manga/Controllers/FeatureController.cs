using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Manga_BLL.Service.FeatureService;
using Manga_PL.ViewModels.Feature;
using Manga_BLL.Entities;

namespace Manga_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMapper _autoMapper;
        private readonly IFeatureService _featureService;

        public FeatureController(IMapper autoMapper, IFeatureService featureService)
        {
            _autoMapper = autoMapper;
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FeatureViewModel>>> GetAllFeatures(bool? dateAppearSorting) 
        {
            var result = await _featureService.GetAllFeatures(dateAppearSorting);
            return Ok(_autoMapper.Map<List<FeatureViewModel>>(result));
        }

        [HttpGet("{characterId}")]
        public async Task<ActionResult<FeatureViewModel>> GetFeatureForCharacter(int characterId)
        {
            var result = await _featureService.GetFeatureByCharacterId(characterId);
            return Ok(_autoMapper.Map<FeatureViewModel>(result));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<FeatureViewModel>> UpdateFeatureDateDisappear(int id,DateTime disappearDate )
        {
            var result = await _featureService.UdpateDisappearDate(id, disappearDate);
            return Ok(_autoMapper.Map<FeatureViewModel>(result));
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddFeatureForCharacter([FromForm] AddFeatureViewModel addFeature)
        {
            var feature = _autoMapper.Map<Feature>(addFeature);
            var result = await _featureService.AddFeatureForCharacter(addFeature.CharacterId, feature);
            return Ok($"Feature with id({result}) was added!");
        }
    }
}
