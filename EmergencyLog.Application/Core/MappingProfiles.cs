using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmergencyLog.Domain;

namespace EmergencyLog.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // will come back here once DTO's are done
            CreateMap<Address, Address>().ReverseMap();
            //CreateMap<Domain.Attendance, Domain.Attendance>().ReverseMap();
            CreateMap<Client, Client>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContact>().ReverseMap();
        }
    }
}
