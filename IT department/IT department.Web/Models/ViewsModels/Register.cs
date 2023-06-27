using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.ViewsModels
{
    public class Register
    {
        //public int Id { get; set; }
        //[Required]
        public string login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string pass { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
    }
}
