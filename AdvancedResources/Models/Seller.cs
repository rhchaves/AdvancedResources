using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AdvancedResources.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O Nome deve possuir no mínimo {2} e no máximo {1} letras")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Entre com E-mail válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O Salário é obrigatório")]
        [Display(Name = "Salário")]
        [Range(100.0, 50000.0, ErrorMessage = "O salário deve ser entre {1} e {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        [Display(Name = "Departamento")]
        public Department Department { get; set; }

        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

    }
}
