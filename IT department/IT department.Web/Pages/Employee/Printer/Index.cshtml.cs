using IT_department.Web.Data;
using IT_department.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace IT_department.Web.Pages.Employee.Printer
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            printers = _db.Printers
                .Include(e => e.Technical_condition)
                .Include(j => j.Service_company)
                .ToList();
        }
        private readonly ITDbContext _db;
        public IndexModel(ITDbContext db)
        {
            _db = db;
        }
        //public List<Technical_conditions> techno { get; set; }
        public List<Printers> printers { get; set; }
    }
}
