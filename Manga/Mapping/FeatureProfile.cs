using AutoMapper;
using Manga_BLL.Entities;
using Manga_BLL.DTOs;
using Manga_PL.ViewModels.Feature;

namespace Manga_PL.Mapping
{
    public class FeatureProfile:Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<FeatureDto, FeatureViewModel>();
            CreateMap<AddFeatureViewModel, Feature>();
        }
    }
}
