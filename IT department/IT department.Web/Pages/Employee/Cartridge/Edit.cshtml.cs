using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Employee.Cartridge
{
    public class EditModel : PageModel
    {
        private readonly ITDbContext _db;
        public EditModel(ITDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public EditCartridge Input { get; set; }
        [BindProperty]
        public List<Cartridge_states> techno { get; set; }
        [BindProperty]
        public List<Printers> print { get; set; }
        public async Task OnGet(int Id)
        {
            techno = await _db.Cartridge_states.ToListAsync();
            print = await _db.Printers.ToListAsync();
            var cartridges = _db.Cartridges.Find(Id);
            if (cartridges != null)
            {
                //convert
                Input = new EditCartridge()
                {
                    Id = cartridges.Id,
                    name = cartridges.name,
                    price = cartridges.price,
                    repair_cost = cartridges.repair_cost,
                    refueling_price = cartridges.refueling_price,
                    printer_id = cartridges.printer_id,
                    state = cartridges.state
                };
            }
        }
        public async Task<IActionResult> OnPostAsync(int Id)
        {
            techno = await _db.Cartridge_states.ToListAsync();
            print = await _db.Printers.ToListAsync();
            if (ModelState.IsValid)
            {
                if (Input != null)
                {
                    var exuser = await _db.Cartridges.FindAsync(Input.Id);
                    if (exuser != null)
                    {
                        exuser.name = Input.name;
                        exuser.price = Input.price;
                        exuser.repair_cost = Input.repair_cost;
                        exuser.refueling_price= Input.refueling_price;
                        exuser.printer_id = Input.printer_id;
                        exuser.state = Input.state;

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
