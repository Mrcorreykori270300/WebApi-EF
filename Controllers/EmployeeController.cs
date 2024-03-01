
﻿using AutoMapper;
using EmployeeManagment.DTO;
using EmployeeManagment.Models;
using EmployeeManagment.Repository;
using Microsoft.AspNetCore.Mvc;
using EmployeeDto = EmployeeManagment.DTO.EmployeeDto;



namespace EmployeeManagment.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
       private readonly EmployeeRepository _repository;
        private ResponseDto _response;
        private IMapper _mapper;

        public EmployeeController(EmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _response = new ResponseDto();
            _mapper = mapper;
        }



        [HttpGet]

        public ResponseDto GetEmployee()
        {
            try
            {
                IEnumerable<Employee> empList = _repository.GetAllEmployees();
                _response.Result = _mapper.Map<IEnumerable<EmployeeDto>>(empList);
                _response.Message = "Retrive Employee List Sucessfull";
            }
            catch
            {
                _response.Message = "Some error occured";
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto AddEmployee([FromBody] EmployeeDto employeeDto)
        {

            employeeDto.CreatedBy = "Prashant kori";
            employeeDto.CreatedDate = DateTime.Today;
            if (_repository.IsPhoneNumberExist(employeeDto.PhoneNo))
            {
                _response.Message = "Phone Number Already Exist";
                return _response;
            }

            try
            {
                Employee obj = _mapper.Map<Employee>(employeeDto);
                _repository.AddEmployee(obj);
                _response.Result = _mapper.Map<EmployeeDto>(obj);
                _response.Message = "Employee added successfully";

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = "Unsuccesful " + e.Message;
            }
            return _response;
        }

      

       
        [HttpGet("{id}")]
        public ResponseDto GetEmployeeById(int id)
        {

            try
            {
                Employee emp = _repository.GetEmployeeById(id);
                if(emp != null)
                {
                    _response.Result = _mapper.Map<EmployeeDto>(emp);
                    _response.Message = "Employee found";
                    _response.IsSuccess = true;
                }
                _response.IsSuccess = false;
                _response.Message = "The Emp ID does not exist" ;
            }
            catch (Exception e)
            {
               _response.Message = e.Message;
            }
            
            return _response;
        }

        [HttpPut ("{id}")]
        public ResponseDto UpdateEmployee (int id , EmployeeDto employeeDto)
        {
            employeeDto.ModifiedBy = "Prashant kori";
            employeeDto.ModifiedDate = DateTime.Today;
            try
            {
                Employee obj = _mapper.Map<Employee>(employeeDto);
                _repository.EditEmploye(obj);
                _response.Result = _mapper.Map<EmployeeDto>(obj);

            }
            catch(Exception e) 
            {
                _response.IsSuccess =false;
            }
            return _response;
        }

        [HttpDelete ("{id}")]
        public ResponseDto DeleteEmployee(int id)
        {
            try
            {
                _repository.DeleteEmployee(id);
                _response.Message = "Delete Employee successful";
            }
            catch (Exception e)
            {
                _response.IsSuccess=false;
                _response.Message = "Delte Failed" + e.Message;
            }
            return _response;
    }
        
    }
}
