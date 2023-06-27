using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace IT_department.Web.Pages.Booker.User
{
    public class IndexModel : PageModel
    {
        public async Task OnGet()
        {
            users = await _db.Users.Include(e => e.JobTitle).ToListAsync();
        }
        private readonly ITDbContext _db;
        public IndexModel(ITDbContext db)
        {
            _db = db;
        }
        public List<Users> users { get; set; }
    }
}
