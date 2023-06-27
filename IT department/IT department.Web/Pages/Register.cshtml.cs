using IT_department.Web.Models.Domain;
using IT_department.Web.Models.ViewsModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_department.Web.Pages
{
    public class RegisterModel : PageModel
    {
        //private UserManager<IdentityUser> userManager;
        //private SignInManager<IdentityUser> signInManager;
        public List<Users> users {  get; set; }
        [BindProperty]
        public Register Model { get; set; }
        //public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) 
        //{ 
        //    //this.userManager = userManager;
        //    this.signInManager = signInManager;
        //}
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if ((Model.login != "Admin" || Model.pass != "1234567") && (Model.login != "Clonn123" || Model.pass != "228"))
                    ViewData["Message"] = "Ошибка! Неверный логин или пароль!";
                else
                {
                    var user = new Users()
                    {
                        login = Model.login,
                        pass = Model.pass,
                    };
                    //var result = await userManager.CreateAsync(user, Model.pass);
                    //if (result.Succeeded)
                    //{
                    //    await signInManager.SignInAsync(user, false);
                    //    return RedirectToPage("Index");
                    //}
                    return RedirectToPage("/Employee/Printer/Index");
                }
            }

            return Page();
        }
    }
}
