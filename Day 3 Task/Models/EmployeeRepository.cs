using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext db;

        public EmployeeRepository(EmployeeDbContext context)
        {
            db = context;
        }

        //implementation codes here..

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees;
        }

        public Employee GetEmployeeByID(int Id)
        {
            return db.Employees.Find(Id);
        }

        public Employee AddEmployee(Employee Emp)
        {
            db.Employees.Add(Emp);
            db.SaveChanges();
            return Emp;
        }

        public Employee UpdateEmployee(Employee eupd)
        {
            var employee = db.Employees.Attach(eupd);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return eupd;
        }

        public Employee DeleteEmployee(int Id)
        {
            Employee e = db.Employees.Find(Id);
            if (e != null)
            {
                db.Employees.Remove(e);
                db.SaveChanges();
            }
            return e;
        }
    }
}
