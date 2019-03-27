using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsTimeManiac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SysEventLog sysLog = new SysEventLog();

            string todayTime = sysLog.TodayTime().Hours.ToString();
            label_TodayTime.Text = $"Сегодня компьютер начал работать {todayTime}ч. назад., без учёта обеда";

            string yesterdayTime = sysLog.ChoiceDayTime(DateTime.Now.DayOfYear - 1).ToString();
            label_YesterdayTime.Text = $"Вчерашний интервал работы компьютера {yesterdayTime}";

            int daysCount = 0;

            TimeSpan monthTime = sysLog.CurMonthTime(out daysCount);
            string monthTime_str = monthTime.ToString();

            // расчётное количество часов за март
            double planHours = daysCount * 8 - 1;

            // фактическое число часов за месяц
            double factHours = monthTime.TotalHours;

            label_monthTime.Text = 
$@"Время с начала месяца до сегодняшнего дня: {monthTime}, 
всего дней отработано: {daysCount}, 
не хватает часов: {planHours-factHours}, план:{planHours} факт:{factHours}
(данные за месяц c учётом семичасового дня, с вычетом обеденного времени и 10 минут)";
        }
    }
}
