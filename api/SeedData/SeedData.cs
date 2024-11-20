using api.Data;
using Microsoft.AspNetCore.Identity;

namespace api.SeedData
{
  public class SeedData
  {
    public static async Task EnsurePopulated(IApplicationBuilder app)
    {
      using (var scope = app.ApplicationServices.CreateScope())
      {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
        //seed function
        await SeedUsersAndRoles(userManager, roleManager);
      }
    }

    private static async Task SeedUsersAndRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {

      if (!await roleManager.RoleExistsAsync("User"))
      {
        await roleManager.CreateAsync(new IdentityRole("USER"));
      }
      if (!await roleManager.RoleExistsAsync("Admin"))
      {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
      }

      //Acount admin1
      var Admin1 = new IdentityUser
      {
        UserName = "sa",
        Email = "sa@gmail.com",
        EmailConfirmed = true,
      };
      if (userManager.Users.All(u => u.UserName != Admin1.UserName))
      {
        var result = await userManager.CreateAsync(Admin1, "Abc@123");
        if (result.Succeeded)
        {
          await userManager.AddToRoleAsync(Admin1, "User");
        }
      }

      //Continue...
      //call this method in program.cs
      //ex: await SeedData.EnsurePopulated(app);
    }
  }
}