using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IT_department.Web.Pages.Employee.Cartridge
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            cartridges = _db.Cartridges
                .Include(e => e.Cartridge_state)
                .Include(j => j.Printer)
                .ToList();
        }
        private readonly ITDbContext _db;
        public IndexModel(ITDbContext db)
        {
            _db = db;
        }
        public List<Cartridges> cartridges { get; set; }
    }
}
