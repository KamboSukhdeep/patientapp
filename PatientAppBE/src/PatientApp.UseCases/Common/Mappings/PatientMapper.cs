using AutoMapper;
using PatientApp.DTO;
using PatientApp.Domain.Entities;
using PatientApp.UseCases.Patient.Commands.CreatePatientCommand;
using PatientApp.UseCases.Patient.Commands.UpdatePatientCommand;

namespace PatientApp.UseCases.Common.Mappings
{
    public class PatientMapper : Profile
    {
        public PatientMapper()
        {
            CreateMap<Domain.Entities.Patient, PatientDto>().ReverseMap();
            CreateMap<Domain.Entities.Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Domain.Entities.Patient, UpdatePatientCommand>().ReverseMap();
        }
    }
}
