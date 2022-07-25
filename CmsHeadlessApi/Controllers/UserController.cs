using Microsoft.AspNetCore.Mvc;
using CmsHeadless.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CmsHeadlessApi.Controllers
{


    public class UserController : Controller
    {
        private readonly CmsHeadlessDbContext _contextDb;
        private readonly SignInManager<User> _signInManager;
        public UserController(CmsHeadlessDbContext contextDb, SignInManager<User> signInManager)
        {
            _contextDb = contextDb;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<JsonResult> LoginUserAsync(string? mail, string? password)
        {
            //var userManager = CmsManager.GetUserManager();
            //IQueryable<CmsHeadless.Models.User> selectUser;

            if (mail == null)
            {
                return Json("Invalid Login attempt - You must insert your mail address");
            }
            else if (password == null)
            {
                return Json("Invalid login attempt - You must insert your password");
                ;
            }
            else if (mail == null && password == null)
            {
                return Json("Invalid login attempt - You must insert your mail address and password");
            }

            /*var claimForUser2 = new IdentityUserClaim<string>
            {
                UserId = _contextDb.User.Where(c=>c.Email==mail).Select(c=>c.Id).ToList().First(),
                ClaimType = ClaimTypes.Authentication,
                ClaimValue = "NewUser"
            };
            _contextDb.Add(claimForUser2);
            _contextDb.SaveChanges();*/
            //User user = _contextDb.User.Where(c => c.Email == mail).ToList().First();
            var result = await _signInManager.PasswordSignInAsync(mail, password, false, false);
            if (result.Succeeded)
            {
                return Json("ok");
            }

            /* Utilizzo di PasswordSignInAsync*/
            //if(CmsManager.SignInCheck(mail, password))
            //{
            //    return Json("Login Successful");
            //}

            //var temp = (from User in _contextDb.User select User).Where(u => u.Nickname.Equals(username) || u.Email.Equals(username));

            //for (var i = 0; i < temp.ToList().Count; i++)
            //{
            //    var verify = userManager.PasswordHasher.VerifyHashedPassword(temp.ToList()[i], temp.ToList()[i].PasswordHash, password).ToString();
            //    if (verify.Equals("Success"))
            //    {
            //        return Json(temp.ToList()[i]);
            //    }
            //}

            return Json("Invalid Login attempt - Wrong username or password");
        }


        /*[HttpGet]
        public async Task<JsonResult> GetUserAsync(string? mail, string? password)
        {
            if (mail == null || password == null)
            {
                return Json(null);
            }
            var result = await _signInManager.PasswordSignInAsync(mail, password, false, lockoutOnFailure: false);
            return Json(result);
        }*/
    }
}