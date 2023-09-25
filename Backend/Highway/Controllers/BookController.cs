using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Extra;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Highway.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public BookController(ApplicationDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        [Route("{busName}/{busCompany}/{date}")]
        [HttpGet]
        public async Task<IActionResult> Home(string busName, string busCompany, string date)
        {
            var seatsInfo = _appDbContext.Seats.Where(x => x.BusName == busName && x.BusComapny == busCompany && x.Date == date);
            if (seatsInfo != null) return Ok(new { seatsInfo });

            return Ok(new { Message = "No seats are booked on this date till now!" });
        }


        [Route("Booking")]
        [HttpPost]
        public async Task<IActionResult> Booking([FromBody] BookingModel myJsonObj)
        {
            var seatsInfo = _appDbContext.Seats.SingleOrDefault(x => x.BusName == myJsonObj.busName && x.BusComapny == myJsonObj.busCompany && x.Date == myJsonObj.date);

            if (seatsInfo != null)
            {
                var seats = JsonConvert.DeserializeObject<List<string>>(myJsonObj.seatNo);

                SeatsDb temp = new SeatsDb();
                temp.Id = seatsInfo.Id;
                temp.BusComapny = seatsInfo.BusComapny;
                temp.BusName = seatsInfo.BusName;
                temp.Date = seatsInfo.Date;
                temp.LC1 = seats.Contains("LC1") ? true : seatsInfo.LC1;
                temp.LC2 = seats.Contains("LC2") ? true : seatsInfo.LC2;
                temp.LC3 = seats.Contains("LC3") ? true : seatsInfo.LC3;
                temp.LC4 = seats.Contains("LC4") ? true : seatsInfo.LC4;
                temp.LC5 = seats.Contains("LC5") ? true : seatsInfo.LC5;
                temp.LC6 = seats.Contains("LC6") ? true : seatsInfo.LC6;
                temp.LC7 = seats.Contains("LC7") ? true : seatsInfo.LC7;
                temp.LC8 = seats.Contains("LC8") ? true : seatsInfo.LC8;
                temp.LC9 = seats.Contains("LC9") ? true : seatsInfo.LC9;
                temp.LC10 = seats.Contains("LC10") ? true : seatsInfo.LC10;
                temp.LC11 = seats.Contains("LC11") ? true : seatsInfo.LC11;
                temp.LC12 = seats.Contains("LC12") ? true : seatsInfo.LC12;
                temp.LC13 = seats.Contains("LC13") ? true : seatsInfo.LC13;
                temp.LC14 = seats.Contains("LC14") ? true : seatsInfo.LC14;
                temp.LC15 = seats.Contains("LC15") ? true : seatsInfo.LC15;
                temp.LC16 = seats.Contains("LC16") ? true : seatsInfo.LC16;
                temp.LC17 = seats.Contains("LC17") ? true : seatsInfo.LC17;
                temp.LC18 = seats.Contains("LC18") ? true : seatsInfo.LC18;
                temp.LC19 = seats.Contains("LC19") ? true : seatsInfo.LC19;
                temp.LC20 = seats.Contains("LC20") ? true : seatsInfo.LC20;
                temp.LC21 = seats.Contains("LC21") ? true : seatsInfo.LC21;
                temp.LC22 = seats.Contains("LC22") ? true : seatsInfo.LC22;
                temp.LC23 = seats.Contains("LC23") ? true : seatsInfo.LC23;
                temp.LC24 = seats.Contains("LC24") ? true : seatsInfo.LC24;


                _appDbContext.Seats.Update(seatsInfo).CurrentValues.SetValues(temp);
                _appDbContext.SaveChanges();
            }
            else
            {
                var seats = JsonConvert.DeserializeObject<List<string>>(myJsonObj.seatNo);

                SeatsDb temp = new SeatsDb();
                temp.BusComapny = myJsonObj.busCompany;
                temp.BusName = myJsonObj.busName;
                temp.Date = myJsonObj.date;
                temp.LC1 = seats.Contains("LC1") ? true : false;
                temp.LC2 = seats.Contains("LC2") ? true : false;
                temp.LC3 = seats.Contains("LC3") ? true : false;
                temp.LC4 = seats.Contains("LC4") ? true : false;
                temp.LC5 = seats.Contains("LC5") ? true : false;
                temp.LC6 = seats.Contains("LC6") ? true : false;
                temp.LC7 = seats.Contains("LC7") ? true : false;
                temp.LC8 = seats.Contains("LC8") ? true : false;
                temp.LC9 = seats.Contains("LC9") ? true : false;
                temp.LC10 = seats.Contains("LC10") ? true : false;
                temp.LC11 = seats.Contains("LC11") ? true : false;
                temp.LC12 = seats.Contains("LC12") ? true : false;
                temp.LC13 = seats.Contains("LC13") ? true : false;
                temp.LC14 = seats.Contains("LC14") ? true : false;
                temp.LC15 = seats.Contains("LC15") ? true : false;
                temp.LC16 = seats.Contains("LC16") ? true : false;
                temp.LC17 = seats.Contains("LC17") ? true : false;
                temp.LC18 = seats.Contains("LC18") ? true : false;
                temp.LC19 = seats.Contains("LC19") ? true : false;
                temp.LC20 = seats.Contains("LC20") ? true : false;
                temp.LC21 = seats.Contains("LC21") ? true : false;
                temp.LC22 = seats.Contains("LC22") ? true : false;
                temp.LC23 = seats.Contains("LC23") ? true : false;
                temp.LC24 = seats.Contains("LC24") ? true : false;


                _appDbContext.Seats.Add(temp);
                _appDbContext.SaveChanges();
            }
            return Ok(new { Message = "Seats done successfully!" });
        }


        [Route("Cancel")]
        [HttpPost]
        public async Task<IActionResult> Cancel(int tripId)
        {
            var trip = _appDbContext.Trip.SingleOrDefault(x => x.Id == tripId);

            var seatsInfo = _appDbContext.Seats.SingleOrDefault(x => x.BusName == trip.BusName && x.BusComapny == trip.BusCompany && x.Date == trip.Date);

            var seats = JsonConvert.DeserializeObject<List<string>>(trip.Seats);

            SeatsDb temp = new SeatsDb();
            temp.Id = seatsInfo.Id;
            temp.BusComapny = seatsInfo.BusComapny;
            temp.BusName = seatsInfo.BusName;
            temp.Date = seatsInfo.Date;
            temp.LC1 = seats.Contains("LC1") ? false : seatsInfo.LC1;
            temp.LC2 = seats.Contains("LC2") ? false : seatsInfo.LC2;
            temp.LC3 = seats.Contains("LC3") ? false : seatsInfo.LC3;
            temp.LC4 = seats.Contains("LC4") ? false : seatsInfo.LC4;
            temp.LC5 = seats.Contains("LC5") ? false : seatsInfo.LC5;
            temp.LC6 = seats.Contains("LC6") ? false : seatsInfo.LC6;
            temp.LC7 = seats.Contains("LC7") ? false : seatsInfo.LC7;
            temp.LC8 = seats.Contains("LC8") ? false : seatsInfo.LC8;
            temp.LC9 = seats.Contains("LC9") ? false : seatsInfo.LC9;
            temp.LC10 = seats.Contains("LC10") ? false : seatsInfo.LC10;
            temp.LC11 = seats.Contains("LC11") ? false : seatsInfo.LC11;
            temp.LC12 = seats.Contains("LC12") ? false : seatsInfo.LC12;
            temp.LC13 = seats.Contains("LC13") ? false : seatsInfo.LC13;
            temp.LC14 = seats.Contains("LC14") ? false : seatsInfo.LC14;
            temp.LC15 = seats.Contains("LC15") ? false : seatsInfo.LC15;
            temp.LC16 = seats.Contains("LC16") ? false : seatsInfo.LC16;
            temp.LC17 = seats.Contains("LC17") ? false : seatsInfo.LC17;
            temp.LC18 = seats.Contains("LC18") ? false : seatsInfo.LC18;
            temp.LC19 = seats.Contains("LC19") ? false : seatsInfo.LC19;
            temp.LC20 = seats.Contains("LC20") ? false : seatsInfo.LC20;
            temp.LC21 = seats.Contains("LC21") ? false : seatsInfo.LC21;
            temp.LC22 = seats.Contains("LC22") ? false : seatsInfo.LC22;
            temp.LC23 = seats.Contains("LC23") ? false : seatsInfo.LC23;
            temp.LC24 = seats.Contains("LC24") ? false : seatsInfo.LC24;


            _appDbContext.Seats.Update(seatsInfo).CurrentValues.SetValues(temp);
            _appDbContext.Trip.Remove(trip);
            _appDbContext.SaveChanges();

            return Ok(new { Message= "Seats cancelled successfully!!" });
        }
    }
}