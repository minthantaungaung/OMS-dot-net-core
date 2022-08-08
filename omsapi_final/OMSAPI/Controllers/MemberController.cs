using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Manager;
using OMSAPI.Models;

namespace OMSAPI.Controllers
{
    [ApiController]
    public class MemberController : ControllerBase
    {
        [Route("api/Member/AddMember")]
        [HttpPost]
        public ActionResult<string> AddMember(Member mem)
        {
            MemberManager memMgr = new MemberManager();
            Member result = memMgr.Add(mem);
            return Ok(result);
        }

        [Route("api/Member/Login")]
        [HttpGet]
        public ActionResult<Member> Login(string Email, string Pwd)
        {
            MemberManager memMgr = new MemberManager();
            Member result = memMgr.Login(Email, Pwd);
            return Ok(result);
        }

        [Route("api/Member/checkEmail")]
        [HttpGet]
        public ActionResult<string> checkEmail(string Email)
        {
            MemberManager memMgr = new MemberManager();
            string result = memMgr.CheckEmail(Email);
            return Ok(result);
        }
        [Route("api/Member/CheckConfirmationCode")]
        [HttpGet]
        public ActionResult<string> CheckCode(string Email = null,string Code =null)
        {
            MemberManager memMgr = new MemberManager();
            string result = memMgr.CheckCode(Email,Code);
            return Ok(result);
        }
        [Route("api/Member/ResetPwd")]
        [HttpGet]
        public ActionResult<string> ResetPwd(string Pwd = null,string Email = null)
        {
            MemberManager memMgr = new MemberManager();
            string result = memMgr.ResetPwd(Pwd,Email);
            return Ok(result);
        }
    }
}
