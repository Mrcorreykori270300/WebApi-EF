using EmployeeManagment.Models;

namespace EmployeeManagment.DTO
{
    public class EmployeeDto :  BaseEntity
    {


        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public string PhoneNo { get; set; }

        public DateTime DOB { get; set; }


    }
}
