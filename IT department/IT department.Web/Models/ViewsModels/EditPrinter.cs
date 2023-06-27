using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.ViewsModels
{
    public class EditPrinter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public decimal repair_cost { get; set; }
        public int user_id { get; set; }
        public int state { get; set; }
        public int id_service_company { get; set; }
    }
}
