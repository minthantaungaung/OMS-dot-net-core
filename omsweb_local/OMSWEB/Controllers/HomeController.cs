using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMSAPI.ViewModels;
using OMSWEB.ApiRepo;
using OMSWEB.Models;
using OMSWEB.ViewModels;
using PagedList.NetCore;

namespace OMSWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHttpContextAccessor accessor;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            this.accessor = accessor;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<string> AddTrack(string Project = null, string Detail = null,string Date = null, string STime = null,string ETime = null,string WorkHr = null, bool Billable = false)
        {
            TrackRecord track = new TrackRecord();
            track.Project = Project;
            track.Detail = Detail;
            track.StartTime = DateTime.Parse(STime);
            track.EndTime = DateTime.Parse(ETime);
            track.WorkingHr = WorkHr;
            track.Date = DateTime.Parse(Date);
            track.PhoneNo = GetPhoneNo();
            track.CompanyCode = GetCompanyCode();
            track.Email = GetEmail();
            track.Billable = Billable;
            track.AccessTime = DateTime.Now;
            var url = "api/TrackRecord/AddTrack";
            TrackRecord result = await ApiRequest<TrackRecord>.Post(url, track);
            if (result == null)
            {
                return "Fail";
            }
            else
            {
                return "Ok";
            }
        }
        public IActionResult _trackRecordForm()
        {
            return PartialView();
        }
        //public async Task<IActionResult> _trackRecord()
        //{
        //    string CompanyCode = GetCompanyCode();
        //    string Email = GetEmail();
        //    int page = 1;
        //    int pageSize = 10;
        //    var url = string.Format("api/TrackRecord/recordlist?page={0}&pageSize={1}&CompanyCode={2}&Email={3}", page, pageSize, CompanyCode,Email);
        //    PagingModel<TrackRecord> result = await ApiRequest<PagingModel<TrackRecord>>.Get(url);
        //    PagedList pagedList = new PaginatedList(result.Result, page, pageSize, result.TotalCount);
        //    var model = new PagedListModel<TrackRecord>();
        //    model.Result = pagedList;
        //    model.nextLink = result.nextLink;
        //    model.prevLink = result.prevLink;
        //    model.TotalCount = result.TotalCount;
        //    return PartialView("_trackRecord",model);
        //}
        public async Task<IActionResult> _trackRecord()
        {
            string CompanyCode = GetCompanyCode();
            string Email = GetEmail();
            var url = string.Format("api/TrackRecord/recordlist?CompanyCode={0}&Email={1}", CompanyCode, Email);
            List<TrackRecord> result = await ApiRequest<List<TrackRecord>>.Get(url);
            return PartialView(result);
        }
        public async Task<string> DeleteRecord(int ID= 0)
        {
           var url = string.Format("api/TrackRecord/DeleteRecord?ID={0}", ID);
           string result = await ApiRequest<string>.Get(url);
           return result;
        }
        public async Task<string> EditRecord(string Value = null,string Name = null,int ID = 0)
        {
            var url = string.Format("api/TrackRecord/EditRecord?Value={0}&Name={1}&ID={2}", Value,Name,ID);
            string result = await ApiRequest<string>.Get(url);
            return result;
        }
        #region SpeedCookie
        private string GetCompanyCode()
        {
            string a = User.FindFirst("CompanyCode")?.Value;
            return a;
        }
        private string GetPhoneNo()
        {
            string a = User.FindFirst("PhoneNo")?.Value;
            return a;
        }
        private string GetEmail()
        {
            string a = User.FindFirst("Email")?.Value;
            return a;
        }
        #endregion
    }
}
