using System;
using System.Collections.Generic;

namespace PackageHandlerApp
{
  public class InsuranceService
  {
    private string insuranceDepartmentEmployee = "Curtis";
    List<Package> _packagesHeldForInsuranceCheck = new List<Package>();
    List<Package> processedInsurancePackages = new List<Package>();

    const int InsuranceThreshold = 1000;
    private bool insuranceIsRequired(double packageValue)
    {
      return packageValue > InsuranceThreshold;
    }

    public bool performInsuranceCheck(Package package)
    {
      if (insuranceIsRequired(package.value))
      {
        _packagesHeldForInsuranceCheck.Add(package);
        return true;
      } 
      else
      {
        return false;
      }
    }

    public bool hasPackagesToProcess()
    {
      return _packagesHeldForInsuranceCheck.Count > 0;
    }

    public void clearCheckedInsurancePackage(List<Package> packagesToRemove)
    {
      foreach (Package package in packagesToRemove)
      {
        _packagesHeldForInsuranceCheck.Remove(package);
      }
    }
    public List<Package> processPackgesHeldForInsurance()
    {
      List<Package> processedPackages = new List<Package>();
      foreach (Package packageToProcess in _packagesHeldForInsuranceCheck)
      {
        Console.WriteLine
        (
          $"Package with id: {packageToProcess.id}, and weight: {packageToProcess.weight} requires insurance. Please verify your user identity to confirm adding insurance."
        );
        string userNameInput = Console.ReadLine()!;
        if (userNameInput == insuranceDepartmentEmployee)
        {
          processedPackages.Add(packageToProcess);
          Console.WriteLine("Insurance on this package has been verified!");
        }
        else
        {
          Console.WriteLine("Sorry, that user name did not match!");
          break;
        }
      }
      clearCheckedInsurancePackage(processedPackages);

      return processedPackages;
    }
  }
}