using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmergencyLog.Application.Core;
using EmergencyLog.Application.DTOs.AttendanceDtos;
using EmergencyLog.Application.DTOs.ClientDtos;
using EmergencyLog.Application.DTOs.EmergencyContactDtos;
using EmergencyLog.Application.DTOs.FireExtinguisherDtos;
using EmergencyLog.Application.DTOs.FireHoseDtos;
using EmergencyLog.Application.DTOs.OrganisationDtos;
using EmergencyLog.Application.DTOs.PropertyDtos;
using EmergencyLog.Application.DTOs.SmokeAlarmDtos;
using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;

namespace EmergencyLog.Application.DTOs
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Attendance, Domain.Entities.Attendance>().ReverseMap();
            CreateMap<Domain.Entities.Attendance, AttendanceAddDto>().ReverseMap();
            CreateMap<Domain.Entities.Attendance, AttendanceEditDto>().ReverseMap();
            CreateMap<Domain.Entities.Attendance, AttendanceResultDto>().ReverseMap();

            CreateMap<Client, Client>().ReverseMap();
            CreateMap<Client, ClientAddDto>().ReverseMap();
            CreateMap<Client, ClientEditDto>().ReverseMap();
            CreateMap<Client, ClientResultDto>().ReverseMap();

            CreateMap<EmergencyContact, EmergencyContact>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactAddDto>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactEditDto>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactResultDto>().ReverseMap();

            CreateMap<FireExtinguisher, FireExtinguisher>().ReverseMap();
            CreateMap<FireExtinguisher, FireExtinguisherAddDto>().ReverseMap();
            CreateMap<FireExtinguisher, FireExtinguisherEditDto>().ReverseMap();
            CreateMap<FireExtinguisher, FireExtinguisherResultDto>().ReverseMap();

            CreateMap<FireHose, FireHose>().ReverseMap();
            CreateMap<FireHose, FireHoseAddDto>().ReverseMap();
            CreateMap<FireHose, FireHoseEditDto>().ReverseMap();
            CreateMap<FireHose, FireHoseResultDto>().ReverseMap();

            CreateMap<Organisation, Organisation>().ReverseMap();
            CreateMap<Organisation, OrganisationAddDto>().ReverseMap();
            CreateMap<Organisation, OrganisationEditDto>().ReverseMap();
            CreateMap<Organisation, OrganisationResultDto>().ReverseMap();

            CreateMap<Domain.Entities.Property, Domain.Entities.Property>().ReverseMap();
            CreateMap<Domain.Entities.Property, PropertyAddDto>().ReverseMap();
            CreateMap<Domain.Entities.Property, PropertyEditDto>().ReverseMap();
            CreateMap<Domain.Entities.Property, PropertyResultDto>().ReverseMap();

            CreateMap<SmokeAlarm, SmokeAlarm>().ReverseMap();
            CreateMap<SmokeAlarm, SmokeAlarmAddDto>().ReverseMap();
            CreateMap<SmokeAlarm, SmokeAlarmEditDto>().ReverseMap();
            CreateMap<SmokeAlarm, SmokeAlarmResultDto>().ReverseMap();
        }
    }
}
