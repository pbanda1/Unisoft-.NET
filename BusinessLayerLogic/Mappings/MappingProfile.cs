using BusinessLayerLogic.DTOs;
using AutoMapper;
using Domain.Entities;

namespace BusinessLayerLogic.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentWithPredmetiDto>()
                .ForMember(d => d.Predmeti, o => o.MapFrom(s=>s.StudentPredmeti!.Select(s=>s.Predmet)));

            //pretvara kolekciju poveznica StudentPredmet u kolekciju objekata predmet
            /*
            Oznaka	Značenje
            d	Destination – odredišni objekt (DTO)
            o	Options – opcije mapiranja
            s	Source – izvorni objekt (Student)*/
            CreateMap<Predmet, PredmetWithStudentiDto>()
                .ForMember(d => d.Students, o => o.MapFrom(s => s.StudentPredmeti!.Select(s => s.Student)));
            CreateMap<Predmet, PredmetDto>().ReverseMap();
            CreateMap<PredmetUpdateDto, Predmet>();
            CreateMap<PredmetCreateDto, Predmet>(); 

            CreateMap<StudentPredmet, StudentPredmetDto>();
            CreateMap<StudentPredmetCreateDto, StudentPredmet>();

        }
    }
}
