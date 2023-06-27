using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_department.Web.Models.Domain
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field cannot be null!")]
        [StringLength(16)]
        public string login { get; set; }
        [Required(ErrorMessage = "The name field cannot be null!")]
        [StringLength(100)]
        public string pass { get; set; }
        [StringLength(32)]
        public string? name { get; set; }
        [StringLength(32)]
        public string? surname { get; set; }
        [Required(ErrorMessage = "Error! Select a user!")]
        public int code_job_title { get; set; }
        [ForeignKey("code_job_title")]
        //[Required(ErrorMessage = "Error! Select a user!")]
        public JobTitles JobTitle { get; set; }
    }
}
