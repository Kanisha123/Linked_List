using System;

namespace TestLibrary
{
  /// <summary>
  /// Employee - A class for representing an employee with a first name, last name and EmployeeID.
  /// Assignment:     #1
  /// Course:         ADEV-3001
  /// Date Created:   September. 18, 2019
  /// 
  /// @author: Kanisha Patel
  /// @version 1.0
  /// </summary>
  internal class Employee : IComparable<Employee>
  {
    internal int EmployeeID { get; }
    internal string FirstName { get; }
    internal string LastName { get; }

    /// <summary>
    /// constructor that takes an EmployeeID, firstName, lastName and the default values for firstName and lastName is null.
    /// </summary>
    public Employee(int employeeId, string firstName = null, string lastName = null)
    {
      EmployeeID = employeeId;
      FirstName = firstName;
      LastName = lastName;
    }

    /// <summary>
    /// method to compare EmployeeID.
    /// </summary>
    public int CompareTo(Employee obj1)
    {
      return EmployeeID.CompareTo(obj1.EmployeeID);
    }

    /// <summary>
    /// method that returns string.
    /// </summary>
    public override string ToString()
    {
      return $"{EmployeeID} {FirstName ?? "null"} {LastName ?? "null"}";
    }
  }
}