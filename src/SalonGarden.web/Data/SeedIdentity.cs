using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonGarden.Web.Data
{
    public class SeedIdentity
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SeedIdentity(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public void SeedUsers(UserManager<IdentityUser> userManager)
        {
            //educators
            if (userManager.FindByNameAsync("mkrabappel").Result == null)
            {
                var mkrabappel = new IdentityUser("mkrabappel") { Email = "mkrabappel@thesimpsons.com" };
                userManager.CreateAsync(mkrabappel, "P@ssw0rd!").Wait();
                userManager.AddToRoleAsync(mkrabappel, "Educator").Wait();
            }

            if (userManager.FindByNameAsync("mgarrison").Result == null)
            {
                var mgarrison = new IdentityUser("mgarrison") { Email = "mgarrison@southpark.com" };
                userManager.CreateAsync(mgarrison, "P@ssw0rd!").Wait();
                userManager.AddToRoleAsync(mgarrison, "Educator").Wait();
            }

            //students
            if (userManager.FindByNameAsync("dfunnie").Result == null)
            {
                var dfunnie = new IdentityUser("dfunnie") { Email = "dfunnie@doug.com" };
                userManager.CreateAsync(dfunnie, "P@ssw0rd!").Wait();
                userManager.AddToRoleAsync(dfunnie, "Student").Wait();
            }

            if (userManager.FindByNameAsync("pmayonaise").Result == null)
            {
                var pmayonaise = new IdentityUser("pmayonaise") { Email = "pmayonaise@doug.com" };
                userManager.CreateAsync(pmayonaise, "P@ssw0rd!").Wait();
                userManager.AddToRoleAsync(pmayonaise, "Student").Wait();
            }

            if (userManager.FindByNameAsync("svalentine").Result == null)
            {
                var svalentine = new IdentityUser("svalentine") { Email = "svalentine@doug.com" };
                userManager.CreateAsync(svalentine, "P@ssw0rd!").Wait();
                userManager.AddToRoleAsync(svalentine, "Student").Wait();
            }

            if (userManager.FindByNameAsync("jfunnie").Result == null)
            {
                var jfunnie = new IdentityUser("jfunnie") { Email = "jfunnie@doug.com" };
                userManager.CreateAsync(jfunnie, "P@ssw0rd!").Wait();
                userManager.AddToRoleAsync(jfunnie, "Student").Wait();
            }
        }

        public void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Educator").Result)
            {
                var educatorRole = new IdentityRole("Educator");
                roleManager.CreateAsync(educatorRole).Wait();
            }

            if (!roleManager.RoleExistsAsync("Student").Result)
            {
                var studentRole = new IdentityRole("Student");
                roleManager.CreateAsync(studentRole).Wait();
            }

        }
    }
}
