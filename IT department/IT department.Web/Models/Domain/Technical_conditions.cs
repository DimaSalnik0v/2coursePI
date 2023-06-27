using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.Domain
{
    public class Technical_conditions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string condition_name { get; set; }
    }
}
