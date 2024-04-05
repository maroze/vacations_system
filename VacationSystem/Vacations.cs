using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationSystem
{
    public class Vacations
    {
        /// <summary>
        /// Дата начала отпуска
        /// </summary>
        public DateTime start;

        /// <summary>
        /// Дата окончания отпуска
        /// </summary>
        public DateTime end;

        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employees employee;
        public Vacations(DateTime start, DateTime end, Employees employee)
        {
            this.start = start;
            this.employee = employee;
            this.end = end;
        }
    }
}
