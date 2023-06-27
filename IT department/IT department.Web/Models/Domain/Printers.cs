using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_department.Web.Models.Domain
{
    public class Printers
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
        [ForeignKey("Id")] //ключевой у главной
        public Technical_conditions Technical_condition { get; set; }
        [ForeignKey("Id")]
        public Service_companies Service_company { get; set; }
    }
}
