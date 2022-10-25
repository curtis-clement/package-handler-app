// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace PackageHandlerApp 
{
  class Program
  {
    static DepartmentService departmentService = new DepartmentService();
    static PackageService packageService = new PackageService();
    static InsuranceService insuranceService = new InsuranceService();
    static void addPackage()
    {
      var package = packageService.createPackage();
      if (insuranceService.performInsuranceCheck(package))
      {
        Console.WriteLine("Your package requires insurance and processing is momentarily suspended.");
      }
      else {
        departmentService.addPackageToDepartment(package);
      }
    }

    static void sortListOfProcessedPackagesByDepartment(List<Package> packages)
    {
      foreach (Package package in packages)
      {
        departmentService.addPackageToDepartment(package);
      }
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Hello! Welcome to the our package handling app!");
      bool closeApp = false;

      do
      {
        Console.WriteLine("What would you like to do? You may choose, 'Add Package', 'Process Insurance Holds', 'Quit'");
        var selectedOption = Console.ReadLine();

        switch (selectedOption)
        {
          case "Add Package":
            addPackage();
            break;
          case "Process Insurance Holds":
            var processedPackages = insuranceService.processPackgesHeldForInsurance();
            sortListOfProcessedPackagesByDepartment(processedPackages);
            break;
          case "Quit":
            if (insuranceService.hasPackagesToProcess())
            {
              Console.WriteLine("Please proccess your insurance holds before quitting!");
              break;
            }

            Console.WriteLine($"You processed {departmentService.totalPackageCount()} packages today!");
            Console.WriteLine("Thanks for using our App! Have a nice day.");
            closeApp = true;
            break;
        }
      }
      while (!closeApp);
    }
  }
}

