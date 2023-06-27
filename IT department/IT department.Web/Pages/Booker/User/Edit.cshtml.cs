using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Booker.User
{
    public class EditModel : PageModel
    {
        public List<Users> Users_log { get; set; }
        [BindProperty]
        public EditUser EditUser { get; set; }
        [BindProperty] //связь при выборе
        public List<JobTitles> techno { get; set; }
        private readonly ITDbContext _db;
        public EditModel(ITDbContext db)
        {
            _db = db;
        }
        public async Task OnGet(int Id)
        {
            techno = await _db.JobTitles.ToListAsync();
            var user = await _db.Users.FindAsync(Id);
            if (user != null)
            {
                //convert
                EditUser = new EditUser()
                {
                    Id = user.Id,
                    login = user.login,
                    pass = user.pass,
                    name = user.name,
                    surname = user.surname,
                    code_job_title = user.code_job_title,
                };
            }
        }
        public async Task<IActionResult> OnPostAsync(int Id)
        {
            Users_log = await _db.Users.ToListAsync();
            for (int i=0; i < Users_log.Count; i++)
            {
                if (Users_log[i].login == EditUser.login && Users_log[i].Id != Id)
                {
                    ViewData["erMessage"] = "Error! Login already in use!";
                    techno = await _db.JobTitles.ToListAsync();
                    return Page();
                }
            }
            techno = await _db.JobTitles.ToListAsync();
            if (ModelState.IsValid)
            {
                if (EditUser!= null)
                {
                    var exuser = await _db.Users.FindAsync(EditUser.Id);
                    if (exuser != null)
                    {
                        exuser.login = EditUser.login;
                        exuser.pass = EditUser.pass;
                        exuser.name = EditUser.name;
                        exuser.surname = EditUser.surname;
                        exuser.code_job_title= EditUser.code_job_title;

                        _db.SaveChanges();
                        ViewData["Message"] = "Информация о пользователе обновлена успешно!";
                        return Page();
                    }
                }
            }
            else ViewData["erMessage"] = "Ошибка! Не все обязательные поля были заполнены верно!";
            return Page();
        }
    }
}
