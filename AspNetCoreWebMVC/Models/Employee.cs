using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AspNetCoreWebMVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Address")]
        public string Address { get; set; }
    }
}
