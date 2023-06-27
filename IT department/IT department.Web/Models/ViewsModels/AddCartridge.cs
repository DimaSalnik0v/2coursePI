using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.ViewsModels
{
    public class AddCartridge
    {
        [Required(ErrorMessage = "The name field cannot be null!")]
        [StringLength(200, MinimumLength = 1)]
        public string name { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal price { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal repair_cost { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal refueling_price { get; set; }
        public int printer_id { get; set; }
        public int state { get; set; }
    }
}
