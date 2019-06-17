using ApplicationDomianEntity.ApplicationDbContext;
using ApplicationDomianEntity.Models;
using Microsoft.AspNetCore.Identity;
using R2H.Models;
using System;
using System.Threading.Tasks;

namespace ApplicationDomianEntity.IdentityModels
{
    public class InitializeUser
    {
      
       
        public static async Task Initialize(R2HDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,string UserName,string Password)
        {
        
            context.Database.EnsureCreated();
            string adminId1 = "";
      
            
            string AdminRole = "Admin";
            string AdminDescription = "This is administrator role ";

            string MemberRole = "Member";
            string MemberDescription = "This is members role ";
            string password = Password;
            if (await roleManager.FindByNameAsync(AdminRole) == null)

            {

                await roleManager.CreateAsync(new ApplicationRole(AdminRole, AdminDescription, DateTime.Now));

            }

            if (await roleManager.FindByNameAsync(MemberRole) == null)

            {

                await roleManager.CreateAsync(new ApplicationRole(MemberRole, MemberDescription, DateTime.Now));

            }



            if (await userManager.FindByNameAsync(UserName) == null)

            {

                var user = new ApplicationUser

                {

                    UserName = UserName,

                    Email = UserName,

                    FirstName = "Rashed",

                    LastName = "Radaideh",

                    Street = "Fake St",

                    City = "Vancouver",


                    Country = "Canada",

                    PhoneNumber = "6902341234"

                };



                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)

                {

                    await userManager.AddPasswordAsync(user, password);

                    await userManager.AddToRoleAsync(user, AdminRole);

                }

                adminId1 = user.Id;

            }




        }

    }

}