using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VacationSystem
{
    public class SystemVacation
    {
        /// <summary>
        /// Список со всеми отпусками
        /// </summary>
        public List<Vacations> vacantions = new List<Vacations>() { };

        /// <summary>
        /// Метод с помощью случайных дат, генерирует периоды отпусков
        /// и добавляет в список с отпусками 
        /// </summary>
        /// <param name="employees">Список сотрудников</param>
        public void Create(List<Employees> employees)
        {
            Random rnd = new Random();

            //Перебираем сотрудников
            for (int i = 0; i < employees.Count; i++)
            {
                //Кол-во отпускных дней в году
                int vacationDay = 28;

                //Цикл работает пока отпускные дни не закончатся
                while (vacationDay > 0)
                {
                    int month = rnd.Next(1, 13);
                    int day = rnd.Next(1, DateTime.DaysInMonth(DateTime.Now.Year, month) + 1);

                    //Случайная дата начала отпуска
                    DateTime start = new DateTime(DateTime.Now.Year, month, day);
                    int difference = 0;

                    //Случайным образом выбираем 2-х недельный или недельный отпуск
                    if (vacationDay <= 7)
                    {
                        difference = 7;
                    }
                    else
                    {

                        switch (rnd.Next(2))
                        {
                            case 0:
                                difference = 7;
                                break;
                            case 1:
                                difference = 14;
                                break;
                        }
                    }

                    //Проверка интервала отпуска, в случае успеха
                    //период отпуска добавляется сотруднику в список отпусков
                    //уменьшается кол-во отпускных дней
                    if (!Check(start, start.AddDays(difference)))
                    {
                        vacantions.Add(new Vacations(start, start.AddDays(difference), employees[i]));
                        vacationDay -= difference;
                    }

                }
            }
            //Вывод в консоль сотрудников и интервалов их отпусков
            for (int i = 0; i < vacantions.Count; i++)
            {
                Console.WriteLine($"Сотрудник {vacantions[i].employee.name.ToString()}");
                Console.WriteLine($"Период отпуска: {vacantions[i].start.ToString("D")} - {vacantions[i].end.ToString("D")}");
            }
        }

        /// <summary>
        /// Метод проверяет следующие условия:
        /// Начало отпуска происходит в будний день;
        /// Отпуск формируется в рамках текущего года;
        /// Период отпуска не пересекается с существующими в списке отпусками
        /// </summary>
        /// <param name="start">Дата начала отпуска</param>
        /// <param name="end">Дата окончания отпуска</param>
        /// <returns>Возвращает false если все учловия верны</returns>
        private bool Check(DateTime start, DateTime end)
        {
            bool isWeekend = false;
            bool isNotRange = false;
            bool isExist = false;

            if (start.DayOfWeek.ToString() == "Saturday" || start.DayOfWeek.ToString() == "Sunday")
            {
                return isWeekend = true;
            }
            else if (start < new DateTime(DateTime.Now.Year, 01, 01) || end.CompareTo(new DateTime(DateTime.Now.Year, 12, 31)) > 0)
            {
                return isNotRange = true;
            }
            else if (!isWeekend && !isNotRange)
            {
                bool existstart = vacantions.Any(d => start >= d.start && start <= d.end);
                bool existend = vacantions.Any(d => d.end >= end && end >= d.start);

                if (!existstart && !existend) { return isExist = false; } else { return isExist = true; }
            }
            return true;
        }
    }
}
