using AutoMapper;
using fitness_tracker_serverside.Entities;
using fitness_tracker_serverside.Dtos;

namespace fitness_tracker_serverside.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Exercises, opt => opt.MapFrom(src => src.Exercises))
                .ForMember(dest => dest.Measurements, opt => opt.MapFrom(src => src.Measurements));

            CreateMap<Exercise, ExerciseDto>();
            CreateMap<Measurement, MeasurementDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignore Id when mapping back from DTO to entity

            CreateMap<ExerciseDto, Exercise>();
            CreateMap<UserDto, User>();
        }
    }
}
