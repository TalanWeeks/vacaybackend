using System;
using System.Collections.Generic;
using vacaybackend.Models;
using vacaybackend.Repositories;

namespace vacaybackend.Services
{
  public class TripsService
  {
    private readonly TripsRepository _tr;

    public TripsService(TripsRepository tr)
    {
      _tr = tr;
    }

    public List<Trip> GetTrips()
    {
      return _tr.Get();
    }

    public Trip GetTripById(int tripId)
    {
      Trip foundTrip = _tr.Get(tripId);
      if(foundTrip == null)
      {
        throw new Exception("cant find the trip");
      }
      return foundTrip;
    }

    public Trip Post(Trip data)
    {
      return _tr.Create(data);
    }

    public Trip Put(int id, Trip data)
    {
      var trip = GetTripById(id);

      trip.Destination = data.Destination ?? trip.Destination;
      _tr.Edit(id, data);
      return trip;
    }

    public void Delete(int tripId, string userId)
    {
      Trip trip = GetTripById(tripId);
      if (trip.CreatorId != userId)
      {
        throw new  Exception("not authorized");
      }
      _tr.Delete(tripId);
    }
  }
}