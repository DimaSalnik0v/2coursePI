using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_department.Web.Pages.Booker.Service_company
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditCompany EditCompany { get; set; }
        private readonly ITDbContext _db;
        public EditModel(ITDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(int Id_company)
        {
            var companies = _db.Service_companies.Find(Id_company);
            if (companies != null) 
            {
                //convert
                EditCompany = new EditCompany()
                {
                    Id_company = companies.Id_company,
                    company_name = companies.company_name,
                    legal_addres = companies.legal_addres,
                    company_email = companies.company_email,
                    telephone_number = companies.telephone_number,
                };
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (EditCompany != null)
                {
                    var exCompany = _db.Service_companies.Find(EditCompany.Id_company);
                    if (exCompany != null)
                    {
                        exCompany.company_name = EditCompany.company_name;
                        exCompany.legal_addres = EditCompany.legal_addres;
                        exCompany.company_email = EditCompany.company_email;
                        exCompany.telephone_number = EditCompany.telephone_number;

                        _db.SaveChanges();
                        ViewData["Message"] = "Информация об обслуживающей компании успешно обновлена!";
                    }
                }
            }
            else ViewData["erMessage"] = "Ошибка! Не все обязательные поля были заполнены верно!";
            return Page();
        }
    }
}
