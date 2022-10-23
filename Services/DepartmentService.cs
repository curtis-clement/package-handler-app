using System;
using System.Collections.Generic;

namespace PackageHandlerApp
{
  public class DepartmentService
  {
    public DepartmentService()
    {
      AvailableDepartments = new List<Department>()
      {
        new Department()
        {
          name = "Mail",
          maxHandledWeight = 1,
          valueRequiredForInsurnace = 1000,
        },
        new Department()
        {
          name = "Regular",
          maxHandledWeight = 10,
          valueRequiredForInsurnace = 1000,
        },
        new Department()
        {
          name = "Heavy",
          maxHandledWeight = double.PositiveInfinity,
          valueRequiredForInsurnace = 1000,
        },
      };
    }
    public List<Department> AvailableDepartments;
    public int totalPackageCount()
      {
        int totalPacakgeCount = 0;
        foreach (Department department in AvailableDepartments)
        {
          totalPacakgeCount += department.DepartmentPackages.Count;
        }
        return totalPacakgeCount;
      }
  }
}