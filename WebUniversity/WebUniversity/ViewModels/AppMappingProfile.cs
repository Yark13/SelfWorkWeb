using AutoMapper;
using WebUniversity.DataLayer.Entity;

namespace WebUniversity.ViewModels
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CourseViewModel, Course>().ReverseMap();
            CreateMap<GroupViewModel, Group>().ReverseMap();
            CreateMap<StudentViewModel, Student>().ReverseMap();
        }
    }
}
