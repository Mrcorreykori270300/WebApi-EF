namespace EmployeeManagment.Models
{
    public class Address : BaseEntity
    {
        public int Id { get; set; }

        public string FirstLine { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int Pincode { get; set; }


    }
}
