using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Employee.Printer
{
    public class CreateModel : PageModel
    {
        private readonly ITDbContext _db;
        public CreateModel(ITDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public AddPrinter Input { get; set; }
        [BindProperty]
        public List<Technical_conditions> techno { get; set; }
        [BindProperty]
        public List<Service_companies> compa { get; set; }
        [BindProperty]
        public List<Users> userPr { get; set; }
        public async Task OnGet()
        {
            techno = await _db.Technical_conditions.ToListAsync();
            compa = await _db.Service_companies.ToListAsync();
            userPr = await _db.Users.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            techno = await _db.Technical_conditions.ToListAsync();
            compa = await _db.Service_companies.ToListAsync();
            userPr = await _db.Users.ToListAsync();
            //данные в модель
            if (ModelState.IsValid)
            {
                var printers = new Printers
                {
                    name = Input.name,
                    price = Input.price,
                    repair_cost = Input.repair_cost,
                    user_id = Input.user_id,
                    state = Input.state,
                    id_service_company = Input.id_service_company,
                };
                await _db.Printers.AddAsync(printers);
                await _db.SaveChangesAsync();
                ViewData["Message"] = "Новый принтер успешно добавлен!";
                //return RedirectToPage("/employee/printer/create");
            }
            else ViewData["erMessage"] = "Ошибка! Не все обязательные поля были заполнены верно!";
            return Page();
        }
    }
}
