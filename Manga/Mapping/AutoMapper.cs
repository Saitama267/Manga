using AutoMapper;
using Manga.DTOs;
using Manga.Models;
using Manga.ViewModels;

namespace Manga.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, CharacterViewModel>();
            CreateMap<AddCharacterViewModel, Character>();
            CreateMap<EditCharacterViewModel, Character>();
        }
        
    }
}
