using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_department.Web.Models.Domain
{
    public class Service_companies
    {
        [Key]
        public int Id_company { get; set; }
        [Required(ErrorMessage ="The name field cannot be null!")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Error! The length must be less than 200 characters!")]
        public string company_name { get; set; }
        [StringLength(200, ErrorMessage = "Error! The length  must be less than 200 characters!")]
        public string? legal_addres { get; set; }
        [StringLength(50, ErrorMessage = "Error! The length must be less than 50 characters!")]
        public string? company_email { get; set; }
        [StringLength(30, ErrorMessage = "Error! The length must be less than 30 characters!")]
        public string? telephone_number { get; set; }
    }
}