using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Manager;
using OMSAPI.Models;

namespace OMSAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TrackRecordController : ControllerBase
    {
      
        [HttpGet]
        [Route("api/TrackRecord/recordlist")]
        public ActionResult<List<TrackRecord>> TrackRecord(string CompanyCode = null, string Email = null)
        {
            TrackRecordManager trackMgr = new TrackRecordManager();
            List<TrackRecord> result = trackMgr.TrackRecord(CompanyCode, Email);
            return result;
        }
        [Route("api/TrackRecord/AddTrack")]
        public ActionResult<string> AddTrack(TrackRecord track)
        {
            TrackRecordManager trackMgr = new TrackRecordManager();
            string result = trackMgr.AddTrack(track);
            return result;
        }
        //[Route ("api/TrackRecord/AddTrack")]
        //public ActionResult<string> AddTrack (string Detail, string Project, bool Billable, string STime, string ETime, string WorkHr, string Date,string Email,string CompanyCode)
        //{
        //    try
        //    {
        //        TrackRecord a = new TrackRecord();
        //        a.Detail = Detail;
        //        a.Project = Project;
        //        a.Billable = Billable;
        //        a.StartTime = DateTime.Parse(STime);
        //        a.EndTime = DateTime.Parse(ETime);
        //        a.WorkingHr =WorkHr;
        //        a.Date = DateTime.Parse(Date);

        //        db.TrackRecord.Add(a);
        //        db.SaveChanges();
        //        return "OK";
        //    }
        //    catch
        //    {
        //        return "ERROR";
        //    }
        //}
    }
}