using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models
{
    public class Employee : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string PhoneNo { get; set; }


        public DateTime DOB { get; set; }

       




    }
}
