using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.Domain
{
    public class Cartridges
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public decimal repair_cost { get; set; }
        [Required]
        public decimal refueling_price { get; set; }
        public int printer_id { get; set; }
        public int state { get; set; }
        [ForeignKey("Id")] //ключевой у главной
        public Cartridge_states Cartridge_state { get; set; }
        [ForeignKey("Id")]
        public Printers Printer { get; set; }
    }
}
