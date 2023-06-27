using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Booker.Service_company
{
    public class IndexModel : PageModel
    {
        public async Task OnGet()
        {
            companies = await _db.Service_companies.ToListAsync();
        }
        private readonly ITDbContext _db;
        public IndexModel(ITDbContext db)
        {
            _db = db;
        }
        public List<Service_companies> companies { get; set; }
    }
}
