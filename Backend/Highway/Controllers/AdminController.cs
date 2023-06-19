using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Highway.Models;

namespace Highway.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ApplicationDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        [Route("addBus")]
        [HttpPost]
        public async Task<IActionResult> AddBus(BusDb busDetails)
        {
            _appDbContext.Bus.Add(busDetails);
            _appDbContext.SaveChanges();
            
            return Ok("Bus added successfully!!");
        }

        [Route("updateBus")]
        [HttpPatch]
        public async Task<IActionResult> UpdateBus(BusDb busDetails)
        {
            var busToBeUpdated = _appDbContext.Bus.SingleOrDefault(x => x.Id == busDetails.Id);

            _appDbContext.Bus.Update(busToBeUpdated).CurrentValues.SetValues(busDetails);
            _appDbContext.SaveChanges();
            
            return Ok("Bus updated successfully!!");
        }

        [Route("removeBus")]
        [HttpDelete]
        public async Task<IActionResult> RemoveBus(int busId)
        {
            var busToBeDeleted = _appDbContext.Bus.SingleOrDefault(x => x.Id == busId);

            _appDbContext.Bus.Remove(busToBeDeleted);
            _appDbContext.SaveChanges();
            
            return Ok("Bus removed successfully!!");
        }

        [Route("busAvailability")]
        [HttpPost]
        public async Task<IActionResult> BusAvailability(int busId)
        {
            var busToBeEdited = _appDbContext.Bus.SingleOrDefault(x => x.Id == busId);

            if(busToBeEdited.Active == true) busToBeEdited.Active = false;
            else busToBeEdited.Active = true;
            
            _appDbContext.SaveChanges();
            
            return Ok("Bus availability changed successfully!!");
        }

    }
}