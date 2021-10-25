using System;

namespace vacaybackend.Models
{
  public abstract class IVacation<T>
  {
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}