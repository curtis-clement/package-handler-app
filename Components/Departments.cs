using System;
using System.Collections.Generic;

namespace PackageHandlerApp
{
  public class Department
  {
    public string name = "";
    public double maxHandledWeight { get; set; }
    public double valueRequiredForInsurnace { get; set; }
    public List<Package> DepartmentPackages = new List<Package>();
    public void addPackageToDepartment(Package package)
    {
      this.DepartmentPackages.Add(package);
    }
  }
}