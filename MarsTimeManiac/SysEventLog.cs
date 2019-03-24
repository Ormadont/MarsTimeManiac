using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarsTimeManiac
{
    class SysEventLog
    {
        EventLog sysLog;
        IEnumerable<EventLogEntry> Entries;

        public SysEventLog()
        {
            sysLog = new EventLog();
            sysLog.Log = "System";
            Entries = sysLog.Entries.Cast<EventLogEntry>();
            DateTime nowTime = DateTime.Now;
        }

        // сколько сегодня прошло времени с момента включения компьютера
        public TimeSpan TodayTime()
        {
            // время первого события текущего дня
            DateTime startTime =
                (from entry in Entries
                where entry.TimeGenerated.DayOfYear == DateTime.Now.DayOfYear // только события сегодняшнего дня              
                select entry.TimeGenerated)
                .Min();

            return DateTime.Now - startTime;
        }

        // сколько времени прошло вчера между первым и последним событиями журнала
        public TimeSpan YesterdayTime()
        {
            // время первого события вчерашнего дня
            DateTime startTime =
                (from entry in Entries
                 where entry.TimeGenerated.DayOfYear == DateTime.Now.DayOfYear-1 // только события вчерашнего дня              
                 select entry.TimeGenerated)
                .Min();
            // время последнего события вчерашнего дня
            DateTime endTime =
                (from entry in Entries
                 where entry.TimeGenerated.DayOfYear == DateTime.Now.DayOfYear - 1 // только события вчерашнего дня              
                 select entry.TimeGenerated)
                .Max();

            return endTime - startTime;
        }

        // сколько времени прошло в заданный день между первым и последним событиями журнала
        public TimeSpan ChoiceDayTime(int DayOfYear)
        {
            // время первого события 
            DateTime startTime =
                (from entry in Entries
                 where entry.TimeGenerated.DayOfYear == DayOfYear // только события указанного дня              
                 select entry.TimeGenerated)
                .Min();
            // время последнего события 
            DateTime endTime =
                (from entry in Entries
                 where entry.TimeGenerated.DayOfYear == DayOfYear // только события указанного дня              
                 select entry.TimeGenerated)
                .Max();

            return endTime - startTime;
        }

        // количество времени за текущий месяц
        public TimeSpan CurMonthTime()
        {           
            // время первого события текущего месяца
             DateTime startTime =
                (from entry in Entries
                 where entry.TimeGenerated.Month == DateTime.Now.Month // только события вчерашнего дня              
                 select entry.TimeGenerated)
                .Min();

            // номер дня в рамках года для первого дня текущего месяца
            int firstDayOfMonthInYear = startTime.DayOfYear;

            // сложение времени с начала месяца по вчерашний день
            TimeSpan sumTimeOfMonth = TimeSpan.Zero;
            
            for (int i = firstDayOfMonthInYear; i < DateTime.Now.DayOfYear -1; i++)
            {
                sumTimeOfMonth += ChoiceDayTime(i);
                Debug.WriteLine($@"Номер дня: {i}, Общее подсчитанное время: {sumTimeOfMonth.ToString()}");
            }

            Debug.WriteLine($"Общее время за этот месяц: {sumTimeOfMonth.ToString()}");

            return sumTimeOfMonth;
        }


    }


}
