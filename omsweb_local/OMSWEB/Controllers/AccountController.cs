using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OMSWEB.ApiRepo;
using OMSWEB.Models;

namespace OMSWEB.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login(Member member)
        {
            if (!string.IsNullOrEmpty(member.Email) && string.IsNullOrEmpty(member.Password))
            return RedirectToAction("Index");
            string Email = member.Email;
            string Password = member.Password;
            string url = string.Format("api/Member/Login?Email={0}&Pwd={1}", Email, Password);
            Member result = await ApiRequest<Member>.Get(url);
            if (result != null)
            {
               
                    var claims = new List<Claim>()
                {
                    new Claim("Name",result.Name ?? ""),
                    new Claim("Email",Email ?? ""),
                    new Claim("CompanyCode", result.CompanyCode ?? ""),
                    new Claim("CompanyName", result.CompanyName ?? ""),
                    new Claim("Accesstime", result.Accesstime.ToString() ?? ""),
                    new Claim("Remark",result.Remark ?? ""),
                };
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties()
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(50),
                        IssuedUtc = DateTimeOffset.UtcNow
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Unauthorize";
                return View("Index");
            }
            
        }
    }
}