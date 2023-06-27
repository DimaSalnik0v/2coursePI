using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IT_department.Web.Models.ViewsModels
{
    public class AddEquipment
    {
        [Required(ErrorMessage = "The name field cannot be null!")]
        [StringLength(200, MinimumLength = 1)]
        public string type_of_equipment { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal price { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal repair_cost { get; set; }
        public int state { get; set; }
        public int id_service_company { get; set; }
    }
}
