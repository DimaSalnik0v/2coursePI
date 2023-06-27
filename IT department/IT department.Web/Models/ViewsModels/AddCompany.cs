using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.ViewsModels
{
    public class AddCompany
    {
        [BindProperty]
        [Required(ErrorMessage = "The name field cannot be null!")]
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
