using AutoMapper;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // will come back here once DTO's are done
            CreateMap<Address, Address>().ReverseMap();
            CreateMap<Domain.Entities.Attendance, Domain.Entities.Attendance>().ReverseMap();
            CreateMap<Client, Client>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContact>().ReverseMap();
            CreateMap<FireExtinguisher, FireExtinguisher>().ReverseMap();
            CreateMap<FireHose, FireHose>().ReverseMap();
            CreateMap<Organisation, Organisation>().ReverseMap();
            CreateMap<Domain.Entities.Property, Domain.Entities.Property>().ReverseMap();
            CreateMap<SmokeAlarm, SmokeAlarm>().ReverseMap();
        }
    }
}
