using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Booker.User
{
    public class CreateModel : PageModel
    {
        private readonly ITDbContext _db;
        public CreateModel(ITDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public AddUser Input { get; set; }
        [BindProperty] //����� ��� ������
        public List<JobTitles> techno { get; set; }
        public async Task OnGet()
        {
            techno = await _db.JobTitles.ToListAsync();
            //return Page();
        }
        //[HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            techno = await _db.JobTitles.ToListAsync();
            //������ � ������
            if (ModelState.IsValid)
            {
                var userss = new Users
                {
                    login = Input.login,
                    pass = Input.pass,
                    name = Input.name,
                    surname = Input.surname,
                    code_job_title = Input.code_job_title
                };
                await _db.Users.AddAsync(userss);
                await _db.SaveChangesAsync();
                ViewData["Message"] = "����� ������������ ������� ��������!";
                //return RedirectToPage("/Booker/User/create");
            }
            else ViewData["erMessage"] = "������! �� ��� ������������ ���� ���� ��������� �����!";
            return Page();
        }
    }
}
