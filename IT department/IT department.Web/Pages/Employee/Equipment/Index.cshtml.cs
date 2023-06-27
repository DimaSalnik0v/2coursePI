using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Employee.Equipment
{
    public class IndexModel : PageModel
    {
        public async Task OnGet()
        {
            equipments = await _db.Equipments
                .Include(e => e.Technical_condition)
                .Include(j => j.Service_company)
                .ToListAsync();
        }
        private readonly ITDbContext _db;
        public IndexModel(ITDbContext db)
        {
            _db = db;
        }
        public List<Equipments> equipments { get; set;}
    }
}
