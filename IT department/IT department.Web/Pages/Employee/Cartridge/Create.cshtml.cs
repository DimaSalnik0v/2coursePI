using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Employee.Cartridge
{
    public class CreateModel : PageModel
    {
        private readonly ITDbContext _db;
        public CreateModel(ITDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public AddCartridge Input { get; set; }
        [BindProperty]
        public List<Cartridge_states> techno { get; set; }
        [BindProperty]
        public List<Printers> print { get; set; }
        public async Task OnGet()
        {
            techno = await _db.Cartridge_states.ToListAsync();
            print = await _db.Printers.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            techno = await _db.Cartridge_states.ToListAsync();
            print = await _db.Printers.ToListAsync();
            //данные в модель
            if (ModelState.IsValid)
            {
                var cartridges = new Cartridges
                {
                    name = Input.name,
                    price = Input.price,
                    repair_cost = Input.repair_cost,
                    refueling_price = Input.refueling_price,
                    printer_id = Input.printer_id,
                    state = Input.state,
                };
                await _db.Cartridges.AddAsync(cartridges);
                await _db.SaveChangesAsync();
                ViewData["Message"] = "Новый картридж успешно добавлен!";
                //return RedirectToPage("/employee/printer/create");
            }
            else ViewData["erMessage"] = "Ошибка! Не все обязательные поля были заполнены верно!";
            return Page();
        }
    }
}
