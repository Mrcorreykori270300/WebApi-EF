using EmployeeManagment.Data;
using EmployeeManagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Repository
{
    public class EmployeeRepository
    {

        private readonly ApplicationDbContext _context;

        public EmployeeRepository (ApplicationDbContext context)
        {
            _context = context;
        }


        //To Check if phone number already used or not............
        public Boolean IsPhoneNumberExist(string phoneNumber)
        {
            return _context.EmployeeDetails.Any(e=>e.PhoneNo == phoneNumber);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.EmployeeDetails.ToList();
        }

        public Employee GetEmployeeById (int id)
        {
            return _context.EmployeeDetails.Find(id);
        }

        public void AddEmployee (Employee employee )
        {
            _context.EmployeeDetails.Add ( employee );
            _context.SaveChanges();
        }

       
        public void DeleteEmployee (int id)
        {
            var employee =_context.EmployeeDetails.Find(id);
            if (employee != null)
            {
                _context.EmployeeDetails.Remove(employee);
                _context.SaveChanges();

            }
            
        }

        public void EditEmploye(Employee employee)
        {
            _context.EmployeeDetails.Update(employee);
            _context.SaveChanges ();
        }


    }
}
