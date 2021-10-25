using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bloggr.Repositories;
using Dapper;
using vacaybackend.Interfaces;
using vacaybackend.Models;

namespace vacaybackend.Repositories
{
  public class TripsRepository : DbContext, IRepository<Trip>
  {
    public TripsRepository(IDbConnection db) : base(db)
    {
    }

    public Trip Create(Trip data)
    {
      string sql = @"
      INSERT INTO trips(
        price,
        destination
      )
      VALUES(
        @Price,
        @Destination
      );
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public void Delete(int tripId)
    {
      string sql = "DELETE FROM trips WHERE id = @tripId LIMIT 1;";
      var affectedRows = _db.Execute(sql, new {tripId});
      if(affectedRows == 0)
      {
        throw new Exception("The trip WASNT deleted");
      }
    }

    public Trip Edit(int id, Trip data)
    {
      data.Id = id;
      string sql = @"
      UPDATE trips
      SET
      destination = @Destination
      WHERE
      id = @Id;
      ";
      var rowsAffected  = _db.Execute(sql, data);
      if (rowsAffected > 1)
      {
        throw new System.Exception("SOMEONE GO TELL THE DB ADMIN WE DONE MESSED UP");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
      }
      return data;
    }

    public List<Trip> Get()
    {
      string sql = "SELECT * FROM trips";
      return _db.Query<Trip>(sql).ToList();
    }

    public Trip Get(int tripId)
    {
      string sql = "SELECT * FROM trips WHERE id = @tripId";
      return _db.Query<Trip>(sql, new {tripId}).FirstOrDefault();
    }
  }
}