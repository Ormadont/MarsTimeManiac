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
        int curYear = DateTime.Now.Year;

        public SysEventLog()
        {
            sysLog = new EventLog();
            sysLog.Log = "System";
            Entries = sysLog.Entries.Cast<EventLogEntry>();
            //DateTime nowTime = DateTime.Now;
        }

        // сколько сегодня прошло времени с момента включения компьютера
        public TimeSpan TodayTime()
        {
            // время первого события текущего дня
            DateTime startTime =
                (from entry in Entries
                 where entry.TimeGenerated.DayOfYear == DateTime.Now.DayOfYear // только события сегодняшнего дня
                 && entry.TimeGenerated.Year == curYear
                 select entry.TimeGenerated)
                .Min();

            return DateTime.Now - startTime;
        }

        //// сколько времени прошло вчера между первым и последним событиями журнала
        //public TimeSpan YesterdayTime()
        //{
        //    // время первого события вчерашнего дня
        //    DateTime startTime =
        //        (from entry in Entries
        //         where entry.TimeGenerated.DayOfYear == DateTime.Now.DayOfYear-1 // только события вчерашнего дня              
        //         select entry.TimeGenerated)
        //        .Min();
        //    // время последнего события вчерашнего дня
        //    DateTime endTime =
        //        (from entry in Entries
        //         where entry.TimeGenerated.DayOfYear == DateTime.Now.DayOfYear - 1 // только события вчерашнего дня              
        //         select entry.TimeGenerated)
        //        .Max();

        //    return endTime - startTime;
        //}

        // сколько времени прошло в заданный день между первым и последним событиями журнала
        public TimeSpan ChoiceDayTime(int DayOfYear)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            
            try
            {
                // время первого события 
                startTime =
                    (from entry in Entries
                     where entry.TimeGenerated.DayOfYear == DayOfYear // только события указанного дня  
                     && entry.TimeGenerated.Year == curYear
                     select entry.TimeGenerated)
                    .Min();
                // время последнего события 
                endTime =
                    (from entry in Entries
                     where entry.TimeGenerated.DayOfYear == DayOfYear // только события указанного дня
                     && entry.TimeGenerated.Year == curYear
                     select entry.TimeGenerated)
                    .Max();
            }
            catch (Exception)
            {
                return TimeSpan.Zero;
            }

            return endTime - startTime - TimeSpan.FromHours(1.0) - TimeSpan.FromMinutes(10.0); // отнимаем час как обед и 10 минут за гибкий график
        }

        // количество времени за текущий месяц
        public TimeSpan CurMonthTime( out int daysCount)
        {
            daysCount = 0;
            // время первого события текущего месяца
             DateTime startTime =
                (from entry in Entries
                 where 
                    (entry.TimeGenerated.Month == DateTime.Now.Month) // только события вчерашнего дня
                    && (entry.TimeGenerated.Year == curYear)
                 select entry.TimeGenerated)
                .Min();

            // номер дня в рамках года для первого дня текущего месяца
            int firstDayOfMonthInYear = startTime.DayOfYear;

            // сложение времени с начала месяца по вчерашний день
            TimeSpan sumTimeOfMonth = TimeSpan.Zero;
            
            for (int i = firstDayOfMonthInYear; i < DateTime.Now.DayOfYear; i++)
            {
                TimeSpan curTime = ChoiceDayTime(i);
                if (curTime != TimeSpan.Zero) daysCount++;
                sumTimeOfMonth += curTime;
                Debug.WriteLine($@"Номер дня: {daysCount}, Общее подсчитанное время: {sumTimeOfMonth.ToString()}");
            }

            Debug.WriteLine($"Общее время за этот месяц: {sumTimeOfMonth.ToString()}");

            return sumTimeOfMonth;
        }


    }


}
