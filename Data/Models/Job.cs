using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class Job
    {
        [Key]
        public int Job_Id { get; set; }
        public string? Descripyion { get; set; }
        public int Work_Hourse { get; set; }
        public double Salary { get; set; }
        public string Statue { get; set; }
        public int EmployeeNum { get; set; }


        public ICollection<User> Users { get; }= new List<User>();
    }
}
