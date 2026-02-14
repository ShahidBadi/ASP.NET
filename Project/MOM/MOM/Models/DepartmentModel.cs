using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
    public class DepartmentModel
    {
        public int DepartmentID {  get; set; }

        [Required(ErrorMessage = "Department name is required")]
        public string DepartmentName { get; set; }



        public DateTime Created {  get; set; }

        public DateTime Modified { get; set; }
    }
}
