using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Identity;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Highway.Models;

namespace Highway.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var cities = _appDbContext.City;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return Ok(new { cities, user.UserName });
        }

        [Route("distance/{city1}/{city2}")]
        [HttpGet]
        public async Task<IActionResult> Distance(string city1, string city2)
        {

            var firstCity = _appDbContext.City.FirstOrDefault(x => x.City == city1);
            var secondCity = _appDbContext.City.FirstOrDefault(x => x.City == city2);
            double lat1 = Convert.ToDouble(firstCity.Latitude);
            double lon1 = Convert.ToDouble(firstCity.Longitude);
            double lat2 = Convert.ToDouble(secondCity.Latitude);
            double lon2 = Convert.ToDouble(secondCity.Longitude);

            var d1 = lat1 * (Math.PI / 180.0);
            var num1 = lon1 * (Math.PI / 180.0);
            var d2 = lat2 * (Math.PI / 180.0);
            var num2 = lon2 * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return Ok( Math.Round((6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))))/1000, 2) );
        }


        [Route("options")]
        [HttpPost]
        public async Task<IActionResult> Options([FromBody] OptionsModel details)
        {
            var buses = _appDbContext.Bus.Where(x => x.Route.Contains(details.City1) && x.Route.Contains(details.City2) && x.Active);
            List<BusDb> result = new List<BusDb>();

            foreach (var ele in buses)
            {
                var indexOfCity1 = ele.Route.IndexOf(details.City1);
                var indexOfCity2 = ele.Route.IndexOf(details.City2);
                if(indexOfCity2 > indexOfCity1) result.Add(ele);
            }
            
            return Ok(new { result, details });
        }


        [Route("bookTrip")]
        [HttpPost]
        public async Task<IActionResult> BookTrip([FromBody] TripDb data)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            TripDb temp = new TripDb();
            temp.BusName = data.BusName;
            temp.BusCompany = data.BusCompany;
            temp.Seats = data.Seats;
            temp.From = data.From;
            temp.To = data.To;
            temp.Date = data.Date;
            temp.Price = data.Price;
            temp.UserId = user.Id;
            temp.Username =  user.UserName;

            _appDbContext.Trip.Add(temp);
            _appDbContext.SaveChanges();
            
            return Ok(temp);
        }


        [Route("Trips")]
        [HttpGet]
        public async Task<IActionResult> Trips()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            var trips = _appDbContext.Trip.Where(x => x.UserId == user.Id);
            return Ok(new { trips });
        }

    }
}