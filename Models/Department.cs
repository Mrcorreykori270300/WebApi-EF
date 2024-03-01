using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models
{
    public class Department : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public string HOD { get; set; }
    }
}
