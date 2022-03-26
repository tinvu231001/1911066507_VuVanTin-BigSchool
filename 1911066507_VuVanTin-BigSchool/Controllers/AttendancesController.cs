
using _1911066507_VuVanTin_BigSchool.DTOs;
using _1911066507_VuVanTin_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace _1911066507_VuVanTin_BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDTo)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDTo.CourseId))
                return BadRequest("The Attendance already exists!");

            var attendace = new Attendance
            {
                CourseId = attendanceDTo.CourseId,
                AttendeeId = userId
            };

            _dbContext.Attendances.Add(attendace);
            _dbContext.SaveChanges();


            return Ok();
        }
    }
}
