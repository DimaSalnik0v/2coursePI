using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.Domain
{
    public class Cartridge_states
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string state_name { get; set; }
    }
}
