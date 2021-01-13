using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoProgrammingTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(ILogger<IndexModel> logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public string ErrorMessage { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
                var username = Request.Form["Username"].ToString();
                var password = Request.Form["Password"].ToString();

                Debug.WriteLine(username);
                Debug.WriteLine(password);
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                        var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();

                        Debug.WriteLine($"Role is : {role}");
                        await _signInManager.SignInAsync(user, false);
                        return new RedirectToPageResult("/User/UserMainPage");
                    }
                    else
                    {
                        ErrorMessage = "Wrong password";
                    }

                }
                else
                {
                    ErrorMessage = "User does not exist";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return Page();
        }
    }
}
