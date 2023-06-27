using IT_department.Web.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IT_department.Web.Models.ViewsModels
{
    public class AddUser
    {
        [Required(ErrorMessage = "The login field cannot be null!")]
        [StringLength(16)]
        public string login { get; set; }
        [Required(ErrorMessage = "The pass field cannot be null!")]
        [StringLength(100)]
        public string pass { get; set; }
        [StringLength(32)]
        public string? name { get; set; }
        [StringLength(32)]
        public string? surname { get; set; }
        public int code_job_title { get; set; }
    }
}
