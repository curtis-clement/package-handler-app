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

    public void addPackageToDepartment(Package package)
    {
      if (package.weight <= 1)
      {
        var mailDepartment = AvailableDepartments.Find(item => item.name == "Mail");
        mailDepartment!.addPackageToDepartment(package);
        Console.WriteLine("Your package was added to the Mail department!");
      } else if (package.weight <= 10)
      {
        var regularDepartment = AvailableDepartments.Find(item => item.name == "Regular");
        regularDepartment!.addPackageToDepartment(package);
        Console.WriteLine("Your package was added to the Regular department!");
      } else
      {
        var heavyDepartment = AvailableDepartments.Find(item => item.name == "Heavy");
        heavyDepartment!.addPackageToDepartment(package);
        Console.WriteLine("Your package was added to the Heavy department!");
      }
    }
  }
}