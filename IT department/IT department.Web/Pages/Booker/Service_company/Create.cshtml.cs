using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;

namespace IT_department.Web.Pages.Booker.Service_company
{
    public class CreateModel : PageModel
    {
        private readonly ITDbContext _db;
        public CreateModel(ITDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public AddCompany Input { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            //данные в модель
            if (ModelState.IsValid)
            {
                var companies = new Service_companies
                {
                    company_name = Input.company_name,
                    legal_addres = Input.legal_addres,
                    company_email = Input.company_email,
                    telephone_number = Input.telephone_number,
                };
                await _db.Service_companies.AddAsync(companies);
                await _db.SaveChangesAsync();
                //Input.company_name = string.Empty;
                ViewData["Message"] = "Новая компания успешно добавлена!";
                //return Page();
            }
            else ViewData["erMessage"] = "Ошибка! Не все обязательные поля были заполнены верно!";
            return Page();
        }
    }
}