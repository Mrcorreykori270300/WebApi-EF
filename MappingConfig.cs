using AutoMapper;
using EmployeeManagment.DTO;
using EmployeeManagment.Models;
using EmployeeDto = EmployeeManagment.DTO.EmployeeDto;

namespace EmployeeManagment
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            {
                var MappingConfig = new MapperConfiguration(Config =>
                {
                    Config.CreateMap<EmployeeDto, Employee>();
                    Config.CreateMap<Employee, EmployeeDto>();
                });
                return MappingConfig;
            }
        }
    }
}
