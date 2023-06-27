using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Employee.Equipment
{
    public class CreateModel : PageModel
    {
        private readonly ITDbContext _db;
        public CreateModel(ITDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public AddEquipment Input { get; set; }
        [BindProperty]
        public List<Technical_conditions> techno { get; set; }
        [BindProperty]
        public List<Service_companies> compa { get; set; }
        public async Task OnGet()
        {
            techno = await _db.Technical_conditions.ToListAsync();
            compa = await _db.Service_companies.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            techno = await _db.Technical_conditions.ToListAsync();
            compa = await _db.Service_companies.ToListAsync();
            //данные в модель
            if (ModelState.IsValid)
            {
                var equipments = new Equipments
                {
                    type_of_equipment = Input.type_of_equipment,
                    price = Input.price,
                    repair_cost = Input.repair_cost,
                    state = Input.state,
                    id_service_company = Input.id_service_company,
                };
                await _db.Equipments.AddAsync(equipments);
                await _db.SaveChangesAsync();
                ViewData["Message"] = "Новое оборудование успешно добавлено!";
            }
            else ViewData["erMessage"] = "Ошибка! Не все обязательные поля были заполнены верно!";
            return Page();
        }
    }
}
