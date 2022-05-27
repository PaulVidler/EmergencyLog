using AutoMapper;
using EmergencyLog.Application.Attendance;
using EmergencyLog.Application.Clients;
using EmergencyLog.Application.EmergencyContacts;
using EmergencyLog.Application.FireExtinguishers;
using EmergencyLog.Application.FireHoses;
using EmergencyLog.Application.Organisations;
using EmergencyLog.Application.Property;
using EmergencyLog.Application.SmokeAlarms;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<Domain.Entities.Attendance, AttendanceAddDto>().ReverseMap();
            //CreateMap<Client, ClientAddDto>().ReverseMap();
            //CreateMap<EmergencyContact, EmergencyContactAddDto>().ReverseMap();
            //CreateMap<FireExtinguisher, FireExtinguisherAddDto>().ReverseMap();
            //CreateMap<FireHose, FireHoseAddDto>().ReverseMap();
            //CreateMap<Organisation, OrganisationAddDto>().ReverseMap();
            //CreateMap<Domain.Entities.Property, PropertyAddDto>().ReverseMap();
            //CreateMap<SmokeAlarm, SmokeAlarmAddDto>().ReverseMap();
        }
    }
}
