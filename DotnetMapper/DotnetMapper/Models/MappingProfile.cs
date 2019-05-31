using AutoMapper;

namespace DotnetMapper.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<Book, BookViewModel>();
        }
    }
}
