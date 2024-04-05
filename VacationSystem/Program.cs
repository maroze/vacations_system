using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employees employees = new Employees("Тинки") { };
            Employees employees1 = new Employees("Винки") { };
            Employees employees2 = new Employees("Ляля") { };
            Employees employees3 = new Employees("По") { };

            List<Employees> emp = new List<Employees>
            {
                employees1,
                employees2,
                employees3,
                employees
            };

            SystemVacation vacation = new SystemVacation();
            vacation.Create(emp);
            Console.ReadKey();
        }
    }
}
