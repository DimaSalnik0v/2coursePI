using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.ViewsModels
{
    public class EditUser
    {
        [Key]
        public int Id { get; set; }
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
