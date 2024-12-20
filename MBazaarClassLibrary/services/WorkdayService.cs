﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBazaarClassLibrary.data_access;
using MBazaarClassLibrary.models;
using MySql.Data.MySqlClient;

namespace MBazaarClassLibrary.services
{
    public static class WorkdayService
    {

        public static Workday GetEmployeeWorkday(Employee emp, string date, Employee loggedEmp)
        {
            if (loggedEmp.Role != "Employee Manager" && loggedEmp.Role != "CEO")
            {
                throw new Exception("You are not authorized!");
            }

            return DataAccessWorkday.GetEmpWorkdayQuery(emp, date);
        }
        public static List<DetailedWorkday> GetWorkdays(string date, Employee loggedEmp)
        {
            MySqlConnection connection = new MySqlConnection(Utils.connectionString);

            if (loggedEmp.Role != "Employee Manager" && loggedEmp.Role != "Department Manager" && loggedEmp.Role != "Depot Manager" && loggedEmp.Role != "CEO")
            {
                throw new Exception("You are not authorized");
            }
            if (loggedEmp.Role == "Employee Manager" || loggedEmp.Role == "CEO")
            {
                return DataAccessWorkday.GetAllWorkdaysQuery(date);
            }
            else
            {
                return DataAccessWorkday.GetDepartmentWorkdaysQuery(date, loggedEmp.DepartmentId);
            }
        }
        public static List<Workday> GetOwnWorkweek(Employee loggedEmp)
        {
            DateTime now = Utils.GetSystemDatetime();

            List<Workday> foundDays = DataAccessWorkday.GetEmpWorkdaysBetweenDatesQuery(loggedEmp, now.AddDays(-1), now.AddDays(6));
            List<DateTime> days = new List<DateTime>()
            {
                now.AddDays(-1),
                now,
                now.AddDays(1),
                now.AddDays(2),
                now.AddDays(3),
                now.AddDays(4),
                now.AddDays(5),
                now.AddDays(6)
            };

            List<Workday> workweek = new List<Workday>();

            foreach (DateTime day in days)
            {
                workweek.Add(FindWorkdayInList(day, foundDays));
            }

            return workweek;
        }

        private static Workday FindWorkdayInList(DateTime date, List<Workday> workdays)
        {
            foreach (Workday wd in workdays)
            {
                if (DateTime.Parse(wd.Date).Date == date.Date)
                {
                    return wd;
                }
            }
            return null;
        }

        public static bool AddMultipleWorkdays(List<Workday> workdays) 
        {
            return DataAccessWorkday.AddMultipleWorkdaysQuery(workdays);
        }

        public static bool AddWorkday(Employee emp, Workday workday, Employee loggedEmp)
        {
            if (loggedEmp.Role != "Employee Manager" && loggedEmp.Role != "CEO")
            {
                throw new Exception("You are not authorized!");
            }
            Workday foundDay = DataAccessWorkday.GetEmpWorkdayQuery(emp, workday.Date);

            if (foundDay != null)
            {
                throw new Exception("Shift already exists for current workday. Consider removing it first");
            }
            if (StudentNotWorkingNightShift(emp, workday))
            {
                throw new Exception("This person is a student and can only work an evening shift!");
            }
            if (WorkedEveningShiftPrevDay(emp, workday))
            {
                throw new Exception("You have selected morning shift and the previous day contains an evening shift!");
            }
            if (OverworkingThisWeek(emp, workday))
            {
                throw new Exception("Worktime of employee this week becomes more than 40 hours!");
            }

            return DataAccessWorkday.AddWorkdayQuery(workday);
            
        }
        public static bool MarkAttendance(string workdayId, bool missing, Employee loggedEmp)
        {
            if (loggedEmp.Role != "Employee Manager" && loggedEmp.Role != "Department Manager" && loggedEmp.Role != "CEO")
            {
                throw new Exception("You are not authorized!");
            }
            if (workdayId == null)
            {
                throw new Exception("No workday selected!");
            }
            return DataAccessWorkday.MarkAttendanceQuery(workdayId, missing);
            
        }
        public static bool DeleteWorkday(Workday workday, Employee loggedEmp)
        {
            if (loggedEmp.Role != "Employee Manager" && loggedEmp.Role != "CEO")
            {
                throw new Exception("You are not an Employee manager!");
            }
            return DataAccessWorkday.DeleteWorkdayQuery(workday);
        }
        public static bool WorkedEveningShiftPrevDay(Employee emp, Workday workday)
        {
            DateTime prevDate = DateTime.Parse(workday.Date);
            prevDate = prevDate.AddDays(-1);
            Workday prevWorkday = DataAccessWorkday.GetEmpWorkdayQuery(emp, prevDate.ToString(Utils.DbDateFormat));

            if (workday.Shifts.IndexOf("morning") != -1)
            {
                if (prevWorkday != null && prevWorkday.Shifts.IndexOf("evening") != -1)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool OverworkingThisWeek(Employee emp, Workday workdayToAdd)
        {
            DateTime currDate = DateTime.Parse(workdayToAdd.Date);
            DateTime startWeek;
            DateTime endWeek;

            if (currDate.DayOfWeek == DayOfWeek.Monday)
            {
                startWeek = currDate;
                endWeek = startWeek.AddDays(6);
            }
            else if (currDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                startWeek = currDate.AddDays(-1);
                endWeek = startWeek.AddDays(6);
            }
            else if (currDate.DayOfWeek == DayOfWeek.Wednesday)
            {
                startWeek = currDate.AddDays(-2);
                endWeek = startWeek.AddDays(6);
            }
            else if (currDate.DayOfWeek == DayOfWeek.Thursday)
            {
                startWeek = currDate.AddDays(-3);
                endWeek = startWeek.AddDays(6);
            }
            else if (currDate.DayOfWeek == DayOfWeek.Friday)
            {
                startWeek = currDate.AddDays(-4);
                endWeek = startWeek.AddDays(6);
            }
            else if (currDate.DayOfWeek == DayOfWeek.Saturday)
            {
                startWeek = currDate.AddDays(-5);
                endWeek = startWeek.AddDays(6);
            }
            else
            {
                startWeek = currDate.AddDays(-6);
                endWeek = currDate;
            }

            List<Workday> workdays = DataAccessWorkday.GetEmpWorkdaysBetweenDatesQuery(emp, startWeek, endWeek);

            int totalHours = 0;
            int maxHours = 40;
            foreach (Workday wd in workdays)
            {
                int shifts = wd.Shifts.Split("#").Count();
                totalHours += shifts * 4;
            }
            if ((workdayToAdd.Shifts.Split("#").Count() * 4) + totalHours > maxHours)
            {
                return true;
            }
            return false;
        }
        public static bool StudentNotWorkingNightShift(Employee emp, Workday workday)
        {
            if (emp.IsStudent && (workday.Shifts.Contains("morning") || workday.Shifts.Contains("afternoon")))
            {
                return true;
            }
            return false;
        }


        
    }
}
