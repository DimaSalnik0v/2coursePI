using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Employee.Equipment
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public List<Technical_conditions> techno { get; set; }
        [BindProperty]
        public List<Service_companies> compa { get; set; }
        [BindProperty]
        public EditEquipment Input { get; set; }
        private readonly ITDbContext _db;
        public EditModel(ITDbContext db)
        {
            _db = db;
        }
        public async Task OnGet(int Id)
        {
            techno = await _db.Technical_conditions.ToListAsync();
            compa = await _db.Service_companies.ToListAsync();
            var equipments = _db.Equipments.Find(Id);
            if (equipments != null)
            {
                //convert
                Input = new EditEquipment()
                {
                    Id = equipments.Id,
                    type_of_equipment = equipments.type_of_equipment,
                    price = equipments.price,
                    repair_cost = equipments.repair_cost,
                    state = equipments.state,
                    id_service_company = equipments.id_service_company
                };
            }
        }
        public async Task<IActionResult> OnPostAsync(int Id)
        {
            techno = await _db.Technical_conditions.ToListAsync();
            compa = await _db.Service_companies.ToListAsync();
            if (ModelState.IsValid)
            {
                if (Input != null)
                {
                    var exuser = await _db.Equipments.FindAsync(Input.Id);
                    if (exuser != null)
                    {
                        exuser.type_of_equipment = Input.type_of_equipment;
                        exuser.price = Input.price;
                        exuser.repair_cost = Input.repair_cost;
                        exuser.state = Input.state;
                        exuser.id_service_company = Input.id_service_company;

                        _db.SaveChanges();
                        ViewData["Message"] = "Информация о картридже успешно обновлена!";
                        return Page();
                    }
                }
            }
            else ViewData["erMessage"] = "Ошибка! Не все обязательные поля были заполнены верно!";
            return Page();
        }
    }
}
