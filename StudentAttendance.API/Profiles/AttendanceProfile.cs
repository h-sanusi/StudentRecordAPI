using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendance.API.Profiles
{
    public class AttendanceProfile : Profile 
    {
        public AttendanceProfile()
        {
            CreateMap<Entities.Attendance, Models.AttendanceDto>().ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<Models.AttendanceCreationDto, Entities.Attendance>();
        }
    }
}
