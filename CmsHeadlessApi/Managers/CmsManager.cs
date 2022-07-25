/*using CmsHeadless.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace CmsHeadlessApi.Managers
{
    public static class CmsManager
    {
        private static SignInManager<User> userManager;
        public static void SetUserManager(IServiceProvider serviceProvider)
        {
            userManager = (SignInManager<User>)serviceProvider.GetService(typeof(SignInManager<User>));
        }
        public static SignInManager<User> GetUserManager()
        {
            return userManager;
        }
        public static bool SignInCheck(string mail, string password) {

            var userManager = CmsManager.GetUserManager();
            var login = userManager.PasswordSignInAsync(mail, password, false, false);
            
            if (login.Result.Succeeded)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}*/