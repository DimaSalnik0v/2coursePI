using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Employee.Printer
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public List<Technical_conditions> techno { get; set; }
        [BindProperty]
        public List<Service_companies> compa { get; set; }
        [BindProperty]
        public List<Users> userPr { get; set; }
        [BindProperty]
        public EditPrinter Input { get; set; }
        private readonly ITDbContext _db;
        public EditModel(ITDbContext db)
        {
            _db = db;
        }
        public async Task OnGet(int Id)
        {
            techno = await _db.Technical_conditions.ToListAsync();
            compa = await _db.Service_companies.ToListAsync();
            userPr = await _db.Users.ToListAsync();
            var printers = _db.Printers.Find(Id);
            if (printers != null)
            {
                //convert
                Input = new EditPrinter()
                {
                    Id = printers.Id,
                    name = printers.name,
                    price = printers.price,
                    repair_cost = printers.repair_cost,
                    user_id = printers.user_id,
                    state = printers.state,
                    id_service_company =printers.id_service_company
                };
            }
        }
        public async Task<IActionResult> OnPostAsync(int Id)
        {
            techno = await _db.Technical_conditions.ToListAsync();
            compa = await _db.Service_companies.ToListAsync();
            userPr = await _db.Users.ToListAsync();
            if (ModelState.IsValid)
            {
                if (Input != null)
                {
                    var exuser = await _db.Printers.FindAsync(Input.Id);
                    if (exuser != null)
                    {
                        exuser.name = Input.name;
                        exuser.price = Input.price;
                        exuser.repair_cost = Input.repair_cost;
                        exuser.user_id = Input.user_id;
                        exuser.state = Input.state;
                        exuser.id_service_company = Input.id_service_company;

                        _db.SaveChanges();
                        ViewData["Message"] = "Информация о принтере успешно обновлена!";
                        return Page();
                    }
                }
            }
            else ViewData["erMessage"] = "Ошибка! Не все обязательные поля были заполнены верно!";
            return Page();
        }
    }
}
