using System;
using aspcore.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace aspcore.Models
{

    public class Initializer
    {

        public static Task CreateRoles(ServiceProvider serviceProvider)
        {
            return new Initializer()._CreateRoles(serviceProvider);

        }
    
        private async Task _CreateRoles(IServiceProvider serviceProvider)
        {
            //adding custom roles
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            FieldInfo[] fields = typeof(UserType).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                // use f.Name and f.GetValue(null) here
                if (field.FieldType == typeof(string))
                {
                    string roleName = (string)field.GetValue(null)!;
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

            }



            User powerUser = new User
            {
                UserName = "Admin",
                IsActive = true,
            };

            const string userPassword = "visa2020";
            IdentityUser user = await userManager.FindByNameAsync("Admin");

            if (user == null)
            {
                IdentityResult createPowerUser = await userManager.CreateAsync(powerUser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerUser, UserType.Admin);
                }
            }

        }
    }
}
