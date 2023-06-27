using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.Domain
{
    public class Equipments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string type_of_equipment { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public decimal repair_cost { get; set; }
        public int state { get; set; }
        public int id_service_company { get; set; }
        [ForeignKey("Id")] //ключевой у главной
        public Technical_conditions Technical_condition { get; set; }
        [ForeignKey("Id")]
        public Service_companies Service_company { get; set; }
    }
}
