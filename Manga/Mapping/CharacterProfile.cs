using AutoMapper;
using Manga_BLL.DTOs;
using Manga_BLL.Entities;
using Manga_PL.ViewModels.Character;

namespace Manga_PL.Mapping
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, CharacterViewModel>();
            CreateMap<AddCharacterViewModel, Character>();
            CreateMap<EditCharacterViewModel, Character>();
        }
        
    }
}
