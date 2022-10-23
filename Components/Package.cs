using System;
using System.Collections.Generic;

namespace PackageHandlerApp
{
  public class Package
  {
    public Package(int Id, double Weight, double Value)
    {
      id = Id;
      weight = Weight;
      value = Value;
    }
    public int id;
    public double weight {get; set;}
    private double value { get; set; }
    public bool insuranceIsRequired()
    {
      return value > 1000;
    }
  }
}