using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vacaybackend.Models;
using vacaybackend.Services;

namespace vacaybackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TripsController : ControllerBase
  {
    private readonly TripsService _tripsService;

    public TripsController(TripsService tripsService)
    {
      _tripsService = tripsService;
    }

    [HttpGet]
    public ActionResult<List<Trip>> GetTrips()
    {
      try
      {
        var trips = _tripsService.GetTrips();
        return Ok(trips);  
      }
      catch (System.Exception e)
      {          
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{tripId}")]
    public ActionResult<Trip> GetTripById(int tripId)
    {
      try
      {
        var trips = _tripsService.GetTripById(tripId);
        return Ok(trips);  
      }
      catch (System.Exception e)
      {          
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Trip>> PostTrip([FromBody] Trip data)
    {
      try
      {
        Account userInfo =  await HttpContext.GetUserInfoAsync<Account>();
        data.CreatorId = userInfo.Id;
        Trip trip = _tripsService.Post(data);
        trip.Creator = userInfo;
        return Ok(trip);
      }
      catch (System.Exception e)
      {          
        return BadRequest(e.Message);
      }
    }


    [Authorize]
    [HttpPut("{tripId}")]
    public async Task<ActionResult<Trip>> Edit(int tripId, [FromBody] Trip data)
    {
      try
      {
        Account userInfo =  await HttpContext.GetUserInfoAsync<Account>();
        data.CreatorId = userInfo.Id;
        Trip trip = _tripsService.Put(tripId, data);
        trip.Creator = userInfo;
        return Ok(trip);  
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{tripId}")]
    public async Task<ActionResult<string>> Delete(int tripId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _tripsService.Delete(tripId, userInfo.Id);
        return Ok("the trip was deleted");   
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}