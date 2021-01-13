using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoProgrammingTest.Models
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "user",
                    Email = "abc@xyz.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Test@12345").Result;
                
                if (result.Succeeded)
                {
                    Debug.WriteLine("create user succeeded");
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
              

            }
        }
    }
}
