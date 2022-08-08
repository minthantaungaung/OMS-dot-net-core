using OMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSAPI.Manager
{
    public class TrackRecordManager
    {
        OMSContext db = new OMSContext();
        public List<TrackRecord> TrackRecord(string CompanyCode, string Email)
        {
            var product = db.TrackRecord.Where(s => s.IsDeleted != true && s.CompanyCode == CompanyCode && s.Email == Email).OrderByDescending(s => s.Id).ToList();
            return product;
        }
        public string AddTrack(TrackRecord track)
        {
            try
            {
                track.AccessTime = DateTime.UtcNow;
                db.TrackRecord.Add(track);
                db.SaveChanges();
                return "Ok";
            }
            catch
            {
                return "Error";
            }
        }
    }
       
}
